using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("delivery")]
    public class deliberyMode
    {
        [Key]
        public int id {get; set;}
        public int id_usuario {get; set;}
        public int id_venta {get; set;}
        public int id_estado {get; set;}
        public string id_origen { get; set;}
        public string id_destino { get; set;}
        public int tiempo_estimado { get; set; }


        //[ForeignKey("id_usuario")]
        //public virtual usuarioModel Usuario { get; set; }

        [ForeignKey("id_venta")]
        public virtual ventasModel Ventas { get; set; }

        [ForeignKey("id_estado")]
        public virtual estadosDeliveryModal EstadosDelivery { get; set; }

        [ForeignKey("id_origen")]
        public virtual origenModel Origen { get; set; }

        [ForeignKey("id_destino")]
        public virtual destinoModel Destino { get; set; }

    }
}
