using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using self_promo_dawson.Data;
using self_promo_dawson.Data;
using Microsoft.AspNetCore.Authorization;

namespace self_promo_dawson.Pages.Admin.Responsibilities
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly self_promo_dawson.Data.SelfieDataContext _context;

        public EditModel(self_promo_dawson.Data.SelfieDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Responsibility Responsibility { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Responsibilities == null)
            {
                return NotFound();
            }

            var responsibility =  await _context.Responsibilities.FirstOrDefaultAsync(m => m.ResponsibilityId == id);
            if (responsibility == null)
            {
                return NotFound();
            }
            Responsibility = responsibility;
           ViewData["ExperienceId"] = new SelectList(_context.Experiences, "ExperienceId", "Company");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Responsibility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponsibilityExists(Responsibility.ResponsibilityId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ResponsibilityExists(int id)
        {
          return (_context.Responsibilities?.Any(e => e.ResponsibilityId == id)).GetValueOrDefault();
        }
    }
}
