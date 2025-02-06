using BlazorCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Libro>().Property(e=>e.Precio).HasColumnType("decimal(18,2)");
            base.OnModelCreating(builder);
        }
        public DbSet<Libro> Libros { get; set; }
    }
}
