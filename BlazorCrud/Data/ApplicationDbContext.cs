using BlazorCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Libro> Libros { get; set; }
    }
}
