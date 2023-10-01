using System;
using System.ComponentModel;
using Danstagram.Common;
using MongoDB.Bson.Serialization.Serializers;

namespace Danstagram.Inventory.Service.Entities
{
    public class InventoryItem : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId{ get; set; }
        public byte[] Image{get; set;}
        public string Caption{get; set;}
        public int LikeCount{get; set;}
        public DateTimeOffset CreatedDate{get; set;}

    }
} 