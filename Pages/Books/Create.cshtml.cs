using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Malan_Andrei_Laborator2.Data;
using Malan_Andrei_Laborator2.Models;

namespace Malan_Andrei_Laborator2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel

    {
        private readonly Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context _context;

        public CreateModel(Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Authors.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            }
           );
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID",
"LastName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = Book;
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }

    }
}
