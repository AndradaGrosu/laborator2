﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grosu_Andrada_lab.Data;
using Grosu_Andrada_lab.Models;

namespace Grosu_Andrada_lab.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Grosu_Andrada_lab.Data.Grosu_Andrada_labContext _context;

        public DetailsModel(Grosu_Andrada_lab.Data.Grosu_Andrada_labContext context)
        {
            _context = context;
        }

      public Publisher Publisher { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Publisher == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);
            if (publisher == null)
            {
                return NotFound();
            }
            else 
            {
                Publisher = publisher;
            }
            return Page();
        }
    }
}
