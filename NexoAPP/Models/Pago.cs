using System.ComponentModel.DataAnnotations.Schema;

namespace NexoAPP.Models
{
    public class Pago
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdPago { get; set; }
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
       public DateTime FechaPago { get; set;} = DateTime.Now;

    }
}
