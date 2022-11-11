using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("delivery")]
    public class deliveryModel
    {
        [Key]
        public Int64 id {get; set;}
        public int id_usuario {get; set;}
        public string usuario { get; set; }
        public DateTime fechaEntrega { get; set; }
        public TimeSpan horaEntrega { get; set; }
        public DateTime fechaInicio { get; set; }
        public TimeSpan horaInicio { get; set; }
        public int id_venta {get; set;}
        public string cliente { get; set; }
        public string direccionOrigin { get; set; }
        public decimal origenLat { get; set; }
        public decimal origenLng { get; set; }
        public string direccionDestino { get; set; }
        public decimal destinoLat { get; set; }
        public decimal destinoLng { get; set; }
        public TimeSpan tiempoEstimado { get; set; }
        public TimeSpan tiempoRecorrido { get; set; }
        public decimal pagoDelivery { get; set; }
        public decimal pagoPedido { get; set; }
        public DateTime fechaFin { get; set; }
        public TimeSpan horaFin { get; set; }
        public int id_proceso { get; set; }
        public string proceso { get; set; }

        [ForeignKey("id_usuario")]
        public virtual usuarioModel? Usuario { get; set; }

        [ForeignKey("id_venta")]
        public virtual ventaModel? Venta { get; set; }

        [ForeignKey("id_proceso")]
        public virtual procesoDeliveryModel? Proceso { get; set; }
    }
}
