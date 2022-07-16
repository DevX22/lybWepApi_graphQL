using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("imgProducto")]
    public class imgProductoModel
    {
        [Key]
        public int id  { get; set; }
        public int id_producto { get; set; }
        public string imgNombre { get; set; }
        public string img { get; set; }

        [ForeignKey("id_producto")]
        public virtual productoModel Producto { get; set; }

    }
}
