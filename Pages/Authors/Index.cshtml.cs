using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grosu_Andrada_lab.Data;
using Grosu_Andrada_lab.Models;

namespace Grosu_Andrada_lab.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Grosu_Andrada_lab.Data.Grosu_Andrada_labContext _context;

        public IndexModel(Grosu_Andrada_lab.Data.Grosu_Andrada_labContext context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
