using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Malan_Andrei_Laborator2.Data;
using Malan_Andrei_Laborator2.Models;

namespace Malan_Andrei_Laborator2.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context _context;

        public DetailsModel(Malan_Andrei_Laborator2.Data.Malan_Andrei_Laborator2Context context)
        {
            _context = context;
        }

      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
