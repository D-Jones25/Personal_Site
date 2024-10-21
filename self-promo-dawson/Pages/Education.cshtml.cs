using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace self_promo_dawson.Pages;

public class EducationModel : PageModel
{
    private readonly ILogger<EducationModel> _logger;

    public EducationModel(ILogger<EducationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
