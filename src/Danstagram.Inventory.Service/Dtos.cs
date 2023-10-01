using System;

namespace Danstagram.Inventory.Service.Dtos
{
    public record ItemDto(Guid Id,Guid UserId,byte[] Image, string Caption, int LikeCount, DateTimeOffset CreatedDate);
    public record PostItemDto(Guid UserId, byte[] Image,string Caption);
    public record UpdateItemDto(string Caption,int LikeCount);


    // public record FeedItemDto(Guid Id, byte[] Image, string Caption, int LikeCount, DateTimeOffset CreatedDate);

    // public record GrantItemsDto(Guid  UserId,Guid FeedItemId);

    // public record InventoryItemDto(Guid FeedItemId,byte[] Image, string Caption, int LikeCount, DateTimeOffset CreatedDate);
}