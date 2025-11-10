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
        public int IdCategoria { get; set; }
        public string IdUsuario { get; set; } = string.Empty;
    }
}
