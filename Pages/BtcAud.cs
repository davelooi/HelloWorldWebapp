using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HelloWorldWebapp.Pages;

public class BtcAudModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public BtcAudModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    static readonly HttpClient client = new HttpClient();

    public Rate CurrentRate { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        var rateTask = FetchRateAsync();
        var rate = await rateTask;
        CurrentRate = rate!;
        return Page();
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

    private static async Task<Rate> FetchRateAsync()
    {
        var streamTask = client.GetStreamAsync("https://api.pricehub.coinjar.com/rates/BTC/AUD");
        Rate? rate = await JsonSerializer.DeserializeAsync<Rate>(await streamTask);
        return rate!;
    }
}
