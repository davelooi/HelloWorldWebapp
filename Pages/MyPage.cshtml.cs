using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace HelloWorldWebapp.Pages;

public class MyPageModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public MyPageModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    static readonly HttpClient client = new HttpClient();

    public Rate BtcAud { get; set; } = default!;

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

    public async Task<IActionResult> OnGetAsync()
    {
        var streamTask = client.GetStreamAsync("https://api.pricehub.coinjar.com/rates/BTC/AUD");
        Rate? rate = await JsonSerializer.DeserializeAsync<Rate>(await streamTask);

        // var msg = await client.GetStringAsync("https://api.pricehub.coinjar.com/rates/BTC/AUD");
        // Console.Write(msg);
        BtcAud = rate;
        return Page();
    }
}
