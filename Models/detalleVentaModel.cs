using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("detalleVenta")]
    public class detalleVentaModel
    {
        [Key]
        public int id { get; set; }
        public int id_ventas { get; set; }
        public int id_producto { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public int descuento { get; set; }

        [ForeignKey("id_venta")]
        public virtual ventasModel Ventas { get; set; }

        [ForeignKey("id_producto")]
        public virtual productoModel Producto { get; set; }



    }
}
