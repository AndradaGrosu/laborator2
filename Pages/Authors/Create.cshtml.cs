using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grosu_Andrada_lab.Data;
using Grosu_Andrada_lab.Models;

namespace Grosu_Andrada_lab.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Grosu_Andrada_lab.Data.Grosu_Andrada_labContext _context;

        public CreateModel(Grosu_Andrada_lab.Data.Grosu_Andrada_labContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Author == null || Author == null)
            {
                return Page();
            }

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
