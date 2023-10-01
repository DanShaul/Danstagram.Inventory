// using System.Threading.Tasks;
// using Danstagram.Common;
// using Danstagram.Feed.Contracts;
// using Danstagram.Inventory.Service.Entities;
// using MassTransit;

// namespace Danstagram.Inventory.Service.Consumers{
//     public class FeedItemDeletedConsumer : IConsumer<FeedItemDeleted>
//     {
//         private readonly IRepository<FeedItem> repository;
//         public FeedItemDeletedConsumer(IRepository<FeedItem> repository){
//             this.repository = repository;
//         }
//         public async Task Consume(ConsumeContext<FeedItemDeleted> context)
//         {
//             var message = context.Message;

//             var item = await repository.GetAsync(message.ItemId);

//             if(item == null){
//                 return;
//             }
//             else{
//                 await repository.RemoveAsync(message.ItemId);
//             }


//         }
//     }
// }