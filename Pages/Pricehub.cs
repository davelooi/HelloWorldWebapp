// namespace HelloWorldWebapp
// {
//     public class Pricehub
//     {
//         static readonly HttpClient client = new HttpClient();

//         static async Task Main()
//         {
//             try
//             {
//               string responseBody = await client.GetStringAsync("https://api.pricehub.coinjar.com/rates/BTC/AUD");
//             }
//             catch(HttpRequestException e)
//             {
//                 Console.WriteLine("\nException Caught!");
//                 Console.WriteLine("Message :{0} ",e.Message);
//             }
//             // HttpResponseMessage response = await client.GetStringAsync("https://api.pricehub.coinjar.com/rates/BTC/AUD");
//             // response.EnsureSuccessStatusCode();
//             // using var client = new HttpClient();
//             // var response = await client.GetAsync("https://api.pricehub.coinjar.com/rates/BTC/AUD");
//             // response.EnsureSuccessStatusCode();
//         }
//     }
// }
