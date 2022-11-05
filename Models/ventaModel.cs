using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    [Table("venta")]
    public class ventaModel
    {
        [Key]
        public Int64 id { get; set; }
        public int id_cliente { get; set; }
        public string cliente { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public int id_tipoComprobante { get; set; }
        public string tipoComprobante { get; set; }
        public int serieComprobante { get; set; }
        public int numeroComprobante { get; set; }
        public DateOnly fecha { get; set; }
        public TimeOnly hora { get; set; }
        public int id_tipoPago { get; set; }
        public string tipoPago { get; set; }
        public decimal subTotal { get; set; }
        public decimal igv { get; set; }
        public decimal descuento { get; set; }
        public decimal costoDelivery { get; set; }
        public decimal total { get; set; }
        public int id_proceso { get; set; }
        public string proceso { get; set; }

        [ForeignKey("id_tipoComprobante")]
        public virtual  tipoComprobanteModel Comprobante { get; set; }

        [ForeignKey("id_proceso")]
        public virtual procesoVentaModel? Proceso { get; set; }

        [ForeignKey("id_tipoPago")]
        public virtual  tipoPagoModel? Pago { get; set; }
    }
}
