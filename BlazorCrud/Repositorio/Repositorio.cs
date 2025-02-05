using BlazorCrud.Data;
using BlazorCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly ApplicationDbContext _context;

        public Repositorio( ApplicationDbContext context)
        {
            _context=context;
        }
        public async Task<Libro> ActualizarLibro(int libroId, Libro actualizarLibro)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(libroId);
                libro.Autor = actualizarLibro.Autor;
                libro.Titulo= actualizarLibro.Titulo;
                libro.Descripcion=actualizarLibro.Descripcion;
                libro.FechaCreacion=actualizarLibro.FechaCreacion;
                libro.Paginas= actualizarLibro.Paginas;
                libro.Precio=actualizarLibro.Precio;
                _context.Libros.Update(libro);
                await _context.SaveChangesAsync();
                return libro;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Libro> CrearLibro(Libro crearLibro)
        {
            try
            {
                if (crearLibro != null) 
                {
                    crearLibro.FechaCreacion=DateTime.Now;
                    await _context.Libros.AddAsync(crearLibro);
                    await _context.SaveChangesAsync();
                    return crearLibro;
                }
                else { throw new ArgumentNullException("parametros nulos"); }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task EliminarLibro(int libroId)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(e=>e.Id==libroId);
            if (libro is null) return;
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
        }

        public async Task<Libro> GetLibroById(int libroId)
        {
            var result = await _context.Libros.FindAsync(libroId);
            return result is null ? new Libro():result; 
        }

        public async Task<List<Libro>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }
    }
}
