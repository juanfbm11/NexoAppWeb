using System.ComponentModel.DataAnnotations;

namespace NexoAPP.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }= string.Empty;

        [Required]
        public string Contrasena { get; set; }= string.Empty;
    }
}
