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
    [Table("imgProducto")]
    public class imgProductoModel
    {
        [Key]
        public Int64 id  { get; set; }
        public int id_producto { get; set; }
        public string? nombreImg { get; set; }
        public string? imgUrl { get; set; }

        [ForeignKey("id_producto"),JsonIgnore]
        public virtual productoModel? Producto { get; set; }
    }
}
