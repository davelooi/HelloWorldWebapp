using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Cloud.Storage.V1;

namespace HelloWorldWebapp.Pages.Buckets;

public class DetailsModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public DetailsModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    // public Google.Api.Gax.PagedEnumerable<Google.Apis.Storage.v1.Data.Objects, Google.Apis.Storage.v1.Data.Object> Objects { get; set; } = default!;
    public Google.Apis.Storage.v1.Data.Object Object { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var client = StorageClient.Create();
        var obj = client.GetObject("dave-proj-bucket", id);
        Object = obj;
        return Page();
    }
}
