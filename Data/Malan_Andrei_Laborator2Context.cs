using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Malan_Andrei_Laborator2.Models;

namespace Malan_Andrei_Laborator2.Data
{
    public class Malan_Andrei_Laborator2Context : DbContext
    {
        public Malan_Andrei_Laborator2Context (DbContextOptions<Malan_Andrei_Laborator2Context> options)
            : base(options)
        {
        }

        public DbSet<Malan_Andrei_Laborator2.Models.Book> Book { get; set; } = default!;

        public DbSet<Malan_Andrei_Laborator2.Models.Publisher> Publisher { get; set; }
    }
}
