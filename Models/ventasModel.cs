using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    [Table("ventas")]
    public class ventasModel
    {
        [Key]
        private int id { get; set; }
        private int id_cliente { get; set; }
        private int id_usuario { get; set; }
        private int id_tipo_comprobante { get; set; }
        private int serieComprobante { get; set; }
        private int numeroComprobante { get; set; }
        private DateOnly fecha { get; set; }
        private TimeOnly hora { get; set; }
        private int impuesto { get; set; }
        private int total { get; set; }
        private int costo_delivery { get; set; }
        private bool estado { get; set; }

        //[ForeignKey("id_cliente")]
        //public virtual clienteModel Ciente { get; set;
        //[ForeignKey("id_usuario")]
        //public virtual usarioModel Usuario { get; set;

        [ForeignKey("id_tipo_comprobante")]
        public virtual tipoComprobanteModel TipoComprobante { get; set; }
    }
}
