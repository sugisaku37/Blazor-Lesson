using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp6.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp6.Data
{
    public class PubsDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=pubs;Persist Security Info=True;User ID=sa;Password=Passw0rd;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Command Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasKey(s => new { s.StoreId, s.OrderNumber, s.TitleId });
            modelBuilder.Entity<TitleAuthor>().HasKey(ta => new { ta.AuthorId, ta.TitleId });
        }
    }
}