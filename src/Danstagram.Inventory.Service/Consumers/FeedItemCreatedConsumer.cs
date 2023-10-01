// using System.Threading.Tasks;
// using Danstagram.Common;
// using Danstagram.Feed.Contracts;
// using Danstagram.Inventory.Service.Entities;
// using MassTransit;

// namespace Danstagram.Inventory.Service.Consumers{
//     public class FeedItemCreatedConsumer : IConsumer<FeedItemCreated>
//     {
//         private readonly IRepository<FeedItem> repository;
//         public FeedItemCreatedConsumer(IRepository<FeedItem> repository){
//             this.repository = repository;
//         }
//         public async Task Consume(ConsumeContext<FeedItemCreated> context)
//         {
//             var message = context.Message;

//             var item = await repository.GetAsync(message.ItemId);

//             if(item != null){
//                 return;
//             }

//             item = new FeedItem{
//                 Id = message.ItemId,
//                 Image = message.Image,
//                 Caption = message.Caption,
//                 LikeCount = message.LikeCount
//             };

//             await repository.CreateAsync(item);
//         }
//     }
// }