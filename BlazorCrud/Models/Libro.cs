using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Titulo es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La Descripcion es obligatorio")]

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Autor es obligatorio")]

        public string Autor { get; set; }
        [Required(ErrorMessage = "Cantidad de paginas es obligatorio")]

        public int Paginas { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
