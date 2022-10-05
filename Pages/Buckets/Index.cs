using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Cloud.Storage.V1;

namespace HelloWorldWebapp.Pages.Buckets;

public class IndexModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public IndexModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public Google.Api.Gax.PagedEnumerable<Google.Apis.Storage.v1.Data.Objects, Google.Apis.Storage.v1.Data.Object> Objects { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        var client = StorageClient.Create();
        var objects = client.ListObjects("dave-proj-bucket");
        Objects = objects;
        return Page();
    }
}
