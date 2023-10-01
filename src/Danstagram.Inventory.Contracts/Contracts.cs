using System;

namespace Danstagram.Inventory.Contracts{
    public record InventoryItemCreated(Guid ItemId,Guid UserId,byte[] Image,string Caption,int LikeCount,DateTimeOffset CreatedDate);

    public record InventoryItemUpdated(Guid ItemId,Guid UserId,byte[] Image,string Caption,int LikeCount,DateTimeOffset CreatedDate);

    public record InventoryItemDeleted(Guid ItemId);
}