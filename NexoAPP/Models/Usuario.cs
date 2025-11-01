using System.ComponentModel.DataAnnotations;

namespace NexoAPP.Models
{
    public class Usuario
    {
        
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        
        public int Telefono { get; set; }= 0;


        public string Direccion { get; set; } = string.Empty;
        
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;

        
        public string Contrasena { get; set; } = string.Empty;

       public string Correo { get; set; } = string.Empty;

        public string Municipio { get;set; } = string.Empty;

        public int CodigoPostal { get; set; } = 0;
    }
}

