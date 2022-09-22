// using System.Text.Json;

// namespace HelloWorldWebapp
// {
//     public class Pricehub
//     {
//         static readonly HttpClient client = new HttpClient();

//         public class Rate
//         {
//             public string? id { get; set; }
//             public string? baseCurrency { get; set; }
//             public string? counterCurrency { get; set; }
//             public string? reference { get; set; }
//             public string? bid { get; set; }
//             public string? ask { get; set; }
//             public string? timestamp { get; set; }
//             public string? delta1d { get; set; }
//             public string? delta7d { get; set; }
//         }

//         static Rate FetchRate()
//         {
//             var streamTask = client.GetStreamAsync("https://api.pricehub.coinjar.com/rates/BTC/AUD");
//             Rate? rate = JsonSerializer.DeserializeAsync<Rate>(streamTask);
//             return new Rate();
//         }
//     }
// }
