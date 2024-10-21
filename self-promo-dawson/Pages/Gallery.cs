using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace self_promo_dawson.Pages;

public class GalleryModel : PageModel
{
    private readonly ILogger<GalleryModel> _logger;

    public GalleryModel(ILogger<GalleryModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
