using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grosu_Andrada_lab.Data;
using Grosu_Andrada_lab.Models;
using Grosu_Andrada_lab.ViewModels;

namespace Grosu_Andrada_lab.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Grosu_Andrada_lab.Data.Grosu_Andrada_labContext _context;

        public IndexModel(Grosu_Andrada_lab.Data.Grosu_Andrada_labContext context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;
        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            {
                PublisherData = new PublisherIndexData();
                PublisherData.Publishers = await _context.Publisher
                .Include(i => i.Books)
                .ThenInclude(c => c.Author)
                .OrderBy(i => i.PublisherName)
                .ToListAsync();
                if (id != null)
                {
                    PublisherID = id.Value;
                    Publisher publisher = PublisherData.Publishers
                    .Where(i => i.ID == id.Value).Single();
                    PublisherData.Books = publisher.Books;
                }
            }
        }
    }
}
