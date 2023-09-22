using Microsoft.EntityFrameworkCore;
using System;

namespace MyAspNetCoreApp.Web.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Kutuphane_Sistemi; Trusted_Connection=true");
        }


        public DbSet<Book> Books { get; set; }
    }
}
