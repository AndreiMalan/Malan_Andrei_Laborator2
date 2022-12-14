using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Malan_Andrei_Laborator2.Data;
using Malan_Andrei_Laborator2.Models;

namespace Malan_Andrei_Laborator2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context _context;

        public IndexModel(Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {

                Book = await _context.Book
                    .Include(b => b.Publisher)
                    .ToListAsync();
            }
        }
    }
}
