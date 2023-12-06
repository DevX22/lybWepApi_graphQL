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
    [Table("detalleVenta")]
    public class detalleVentaModel
    {
        [Key]
        public Int64 id { get; set; }
        public Int64 id_venta { get; set; }
        public int id_producto { get; set; }
        public string? producto { get; set; }
        public string? descripcion { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal? descuento { get; set; }
        public decimal total { get; set; }

        [ForeignKey("id_venta"),JsonIgnore]
        public virtual ventaModel? Venta { get; set; }

        [ForeignKey("id_producto"),JsonIgnore]
        public virtual productoModel? Producto { get; set; }
    }
}
