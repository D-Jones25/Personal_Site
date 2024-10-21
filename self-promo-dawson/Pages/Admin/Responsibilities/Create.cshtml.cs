using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using self_promo_dawson.Data;
using self_promo_dawson.Data;
using Microsoft.AspNetCore.Authorization;

namespace self_promo_dawson.Pages.Admin.Responsibilities
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly self_promo_dawson.Data.SelfieDataContext _context;

        public CreateModel(self_promo_dawson.Data.SelfieDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExperienceId"] = new SelectList(_context.Experiences, "ExperienceId", "Company");
            return Page();
        }

        [BindProperty]
        public Responsibility Responsibility { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Responsibilities == null || Responsibility == null)
            {
                return Page();
            }

            _context.Responsibilities.Add(Responsibility);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
