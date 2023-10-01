// using System.Collections.Generic;
// using System.Net.Http;
// using System.Net.Http.Json;
// using System.Threading.Tasks;
// using Danstagram.Inventory.Service.Dtos;

// namespace Danstagram.Inventory.Service.Clients{
//     public class FeedClient{
//         private readonly HttpClient httpClient;
//         public FeedClient(HttpClient httpClient){
//             this.httpClient = httpClient;
//         }

//         public async Task<IReadOnlyCollection<FeedItemDto>> GetFeedItemsAsync(){
//             var items = await httpClient.GetFromJsonAsync<IReadOnlyCollection<FeedItemDto>>("/items");
//             return items;
//         }
//     }
// }