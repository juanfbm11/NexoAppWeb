using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NexoAPP.Models
{
    public class Usuario
    {

        [System.ComponentModel.DataAnnotations.Key]
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = string.Empty;


        public int Telefono { get; set; } = 0;


        public string Direccion { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; } = DateTime.Now;


        public string Contrasena { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        [ForeignKey("Municipio")]
        public int MunicipioId { get; set; }

    }    
}
      
    


