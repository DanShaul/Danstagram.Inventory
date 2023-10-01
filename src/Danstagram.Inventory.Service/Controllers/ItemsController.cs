using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Danstagram.Common;
using Danstagram.Inventory.Contracts;
using Danstagram.Inventory.Service.Dtos;
using Danstagram.Inventory.Service.Entities;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Danstagram.Inventory.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<InventoryItem> inventoryItemsRepository;
        private readonly IPublishEndpoint publishEndpoint;
        //private readonly IRepository<FeedItem> feedItemsRepository;
        public ItemsController(IRepository<InventoryItem> inventoryItemsRepository, IPublishEndpoint publishEndpoint)//IRepository<FeedItem> feedItemsRepository
        {
            this.inventoryItemsRepository = inventoryItemsRepository;
            this.publishEndpoint = publishEndpoint;
            //this.feedItemsRepository = feedItemsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetByUserIdAsync(Guid userId){
            if(userId == Guid.Empty){
                return BadRequest();
            }
            var inventoryItemEntities = await inventoryItemsRepository.GetAllAsync(item => item.UserId == userId);

            // var itemIds = inventoryItemEntities.Select(item => item.FeedItemId);
            // var feedItemEntities = await feedItemsRepository.GetAllAsync(item => itemIds.Contains(item.Id));

            var inventoryItemDtos = inventoryItemEntities.Select(inventoryItem =>
            {
                return inventoryItem.AsDto();
            });

            return Ok(inventoryItemDtos);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(PostItemDto postItemDto){
            var inventoryItem = new InventoryItem
            {
                Id = Guid.NewGuid(),
                UserId = postItemDto.UserId,
                Image = postItemDto.Image,
                Caption = postItemDto.Caption,
                LikeCount = 0,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await inventoryItemsRepository.CreateAsync(inventoryItem);

            await publishEndpoint.Publish(new InventoryItemCreated(inventoryItem.Id,inventoryItem.UserId, inventoryItem.Image, inventoryItem.Caption,inventoryItem.LikeCount,inventoryItem.CreatedDate));

            return CreatedAtAction(nameof(GetByUserIdAsync), new {id = inventoryItem.Id},inventoryItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await inventoryItemsRepository.GetAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            if (updateItemDto.Caption != null)
            {
                existingItem.Caption = updateItemDto.Caption;
            }
            if (updateItemDto.LikeCount != 0)
            {
                existingItem.LikeCount = updateItemDto.LikeCount;
            }

            await inventoryItemsRepository.UpdateAsync(existingItem);

            await publishEndpoint.Publish(new InventoryItemUpdated(existingItem.Id,existingItem.UserId,existingItem.Image, existingItem.Caption, existingItem.LikeCount,existingItem.CreatedDate));

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = await inventoryItemsRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            await inventoryItemsRepository.RemoveAsync(item.Id);

            await publishEndpoint.Publish(new InventoryItemDeleted(item.Id));

            return NoContent();
        }
    }
}