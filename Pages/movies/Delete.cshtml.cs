#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Pages.movies
{
    public class DeleteModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;

        public DeleteModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movieee Movieee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movieee = await _context.Movieee.FirstOrDefaultAsync(m => m.ID == id);

            if (Movieee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movieee = await _context.Movieee.FindAsync(id);

            if (Movieee != null)
            {
                _context.Movieee.Remove(Movieee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
