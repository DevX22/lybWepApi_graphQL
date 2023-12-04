using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class ventaDto
    {
        public Int64 id { get; set; }
        public int? id_cliente { get; set; }
        public string? cliente { get; set; }
        public int? id_usuario { get; set; }
        public string? usuario { get; set; }
        public int? id_tipoComprobante { get; set; }
        public string? tipoComprobante { get; set; }
        public string? serieComprobante { get; set; }
        public string? numeroComprobante { get; set; }
        public DateTime? fechaPedido { get; set; }
        public string horaPedido { get; set; }
        public int? id_tipoPago { get; set; }
        public string? tipoPago { get; set; }
        public decimal? subTotal { get; set; }
        public decimal? igv { get; set; }
        public decimal? descuento { get; set; }
        public decimal? costoDelivery { get; set; }
        public decimal? total { get; set; }
        public int? id_proceso { get; set; }
        public string? proceso { get; set; }
        public DateTime? fechaVenta { get; set; }
        public string horaVenta { get; set; }
    }
}
