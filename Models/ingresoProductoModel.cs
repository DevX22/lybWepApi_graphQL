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
    [Table("ingreso")]
    public class ingresoProductoModel
    {
        [Key]
        public Int64 id { get; set; }
        public int id_usuario { get; set; }
        public string? usuario { get; set; }
        public int id_proveedor { get; set; }
        public string? proveedor { get; set; }
        public int? id_tipoComprobante { get; set; }
        public string? tipoComprobante { get; set; }
        public string? serieComprobante { get; set; }
        public string? numeroComprobante { get; set; }
        public DateTime? fecha { get; set; }
        public decimal? subTotal { get; set; }
        public decimal? igv { get; set; }
        public decimal? costoEnvio { get; set; }
        public decimal? total { get; set; }

        [ForeignKey("id_tipoComprobante"),JsonIgnore]
        public virtual tipoComprobanteModel? TipoComprobante { get; set; }

        [ForeignKey("id_proveedor"),JsonIgnore]
        public virtual proveedorModel? Proveedor { get; set; }

        [ForeignKey("id_usuario"),JsonIgnore]
        public virtual usuarioModel? Usuario { get; set; }
    }
}
