using System;
using Danstagram.Inventory.Service.Dtos;
using Danstagram.Inventory.Service.Entities;

namespace Danstagram.Inventory.Service{
    public static class Extensions {
        public static ItemDto AsDto(this InventoryItem item){
            return new ItemDto(item.Id,item.UserId,item.Image,item.Caption,item.LikeCount,item.CreatedDate);
        }
    }
}