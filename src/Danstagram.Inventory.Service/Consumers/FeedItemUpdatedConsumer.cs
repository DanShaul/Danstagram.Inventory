// using System.Threading.Tasks;
// using Danstagram.Common;
// using Danstagram.Feed.Contracts;
// using Danstagram.Inventory.Service.Entities;
// using MassTransit;

// namespace Danstagram.Inventory.Service.Consumers{
//     public class FeedItemUpdatedConsumer : IConsumer<FeedItemUpdated>
//     {
//         private readonly IRepository<FeedItem> repository;
//         public FeedItemUpdatedConsumer(IRepository<FeedItem> repository){
//             this.repository = repository;
//         }
//         public async Task Consume(ConsumeContext<FeedItemUpdated> context)
//         {
//             var message = context.Message;

//             var item = await repository.GetAsync(message.ItemId);

//             if(item == null){
//                 item = new FeedItem{
//                 Id = message.ItemId,
//                 Image = message.Image,
//                 Caption = message.Caption,
//                 LikeCount = message.LikeCount
//                 };
                
//                 await repository.CreateAsync(item);
//             }
//             else{
//                 item.Caption = message.Caption;
//                 item.LikeCount = message.LikeCount;

//                 await repository.UpdateAsync(item);
//             }


//         }
//     }
// }