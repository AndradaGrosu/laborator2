using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grosu_Andrada_lab.Data;
using Grosu_Andrada_lab.Models;
using Grosu_Andrada_lab.Models.ViewModels;

namespace Grosu_Andrada_lab.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Grosu_Andrada_lab.Data.Grosu_Andrada_labContext _context;

        public IndexModel(Grosu_Andrada_lab.Data.Grosu_Andrada_labContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoriesIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoriesIndexData(); CategoryData.Publishers = await _context.Category.Include(i => i.BookCategories).ThenInclude(c => c.Book.Author).OrderBy(i => i.CategoryName).ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Publishers.Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book).ToList();
            }
        }
    }
}
