using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grosu_Andrada_lab.Models;

namespace Grosu_Andrada_lab.Data
{
    public class Grosu_Andrada_labContext : DbContext
    {
        public Grosu_Andrada_labContext (DbContextOptions<Grosu_Andrada_labContext> options)
            : base(options)
        {
        }

        public DbSet<Grosu_Andrada_lab.Models.Book> Book { get; set; } = default!;

        public DbSet<Grosu_Andrada_lab.Models.Publisher>? Publisher { get; set; }

        public DbSet<Grosu_Andrada_lab.Models.Author>? Author { get; set; }

        public DbSet<Grosu_Andrada_lab.Models.Category>? Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Borrowing)
                .WithOne(e => e.Book)
                .HasForeignKey<Borrowing>("BookID");
        }

        public DbSet<Grosu_Andrada_lab.Models.Member>? Member { get; set; }

        public DbSet<Grosu_Andrada_lab.Models.Borrowing>? Borrowing { get; set; }

    }
}
