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
    [Table("detalleIngreso")]
    public class detalleIngresoModel
    {
        [Key]
        public Int64 id { get; set; }
        public Int64 id_ingreso { get; set; }
        public int id_producto { get; set; }
        public string? producto { get; set; }
        public decimal? precioCompra { get; set; }
        public decimal? precioVenta { get; set; }
        public int? cantidad { get; set; }

        [ForeignKey("id_ingreso"),JsonIgnore]
        public virtual ingresoProductoModel? IngresoProducto { get; set; }

        [ForeignKey("id_producto"),JsonIgnore]
        public virtual productoModel? Producto { get; set; }
    }
}
