using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Reflection;

namespace HelloWorldWebapp.Pages;

public class AudModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public AudModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    static readonly HttpClient client = new HttpClient();

    public ListOfRates CurrentRates { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        var rateTask = FetchRatesAsync();
        var rates = await rateTask;
        CurrentRates = rates!;

        // foreach (Rate rate in rates.rates!)
        // {
        //     Console.WriteLine(rate.id);
        //     foreach (PropertyInfo prop in rate.GetType().GetProperties())
        //     {
        //         Console.WriteLine(prop.Name + ": " + prop.GetValue(rate));
        //     }
        // }

        return Page();
    }

    public class ListOfRates
    {
        public List<Rate>? rates { get; set; }
    }

    public class Rate
    {
        public string? id { get; set; }
        public string? baseCurrency { get; set; }
        public string? counterCurrency { get; set; }
        public string? reference { get; set; }
        public string? bid { get; set; }
        public string? ask { get; set; }
        public string? timestamp { get; set; }
        public string? delta1d { get; set; }
        public string? delta7d { get; set; }
    }

    private static async Task<ListOfRates> FetchRatesAsync()
    {
        var streamTask = client.GetStreamAsync("https://api.pricehub.coinjar.com/rates/AUD");
        ListOfRates? listOfRates = await JsonSerializer.DeserializeAsync<ListOfRates>(await streamTask);

        return listOfRates!;
    }
}
