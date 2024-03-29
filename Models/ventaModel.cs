﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Tools;

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
        public string serieComprobante { get; set; }
        public string numeroComprobante { get; set; }
        public DateTime? fechaPedido { get; set; }
        public TimeSpan? horaPedido { get; set; }
        public int id_tipoPago { get; set; }
        public string tipoPago { get; set; }
        public decimal subTotal { get; set; }
        public decimal igv { get; set; }
        public decimal descuento { get; set; }
        public decimal costoDelivery { get; set; }
        public decimal total { get; set; }
        public int id_proceso { get; set; }
        public string proceso { get; set; }
        public DateTime? fechaVenta { get; set; }
        public TimeSpan? horaVenta { get; set; }

        //[ForeignKey("id_tipoComprobante"),JsonIgnore]
        //public virtual  tipoComprobanteModel Comprobante { get; set; }

        //[ForeignKey("id_proceso"),JsonIgnore]
        //public virtual procesoVentaModel? ProcesoVenta { get; set; }

        //[ForeignKey("id_tipoPago"),JsonIgnore]
        //public virtual  tipoPagoModel? Pago { get; set; }


    }
}
