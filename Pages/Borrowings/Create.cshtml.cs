using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Malan_Andrei_Laborator2.Data;
using Malan_Andrei_Laborator2.Models;
using Microsoft.EntityFrameworkCore;

namespace Malan_Andrei_Laborator2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context _context;

        public CreateModel(Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
            .Include(b => b.Author)
            .Select(x => new
            {
                x.ID, BookFullName = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
            });
            ViewData["BookID"] = new SelectList(bookList, "ID", "Book Full Name");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "Full Name");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
