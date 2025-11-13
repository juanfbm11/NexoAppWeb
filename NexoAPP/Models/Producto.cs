using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexoAPP.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;  
        public string Descripcion { get; set; }= string.Empty;
        public decimal Precio { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public int Cantidad { get; set; } = 1;        
        
        
        [Required(ErrorMessage ="La categoria es obligatoria")]
        public int IdCategoria { get; set; }
        /// <summary>
        /// Obtiene o establece el identificador del usuario del producto.
        /// </summary>
        
        public int IdUsuario { get; set; }

    }
}
