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
    [Table("inventarioProducto")]
    public class inventarioModel
    {
        [Key]
        public int id { get; set; }
        public int id_producto { get; set; }
        public string producto { get; set; }
        public int undIngresadas { get; set; }
        public int undVendidas { get; set; }
        public int totalStock { get; set; }

        [ForeignKey("id_producto"),JsonIgnore]
        public virtual productoModel? productoModel { get; set; }
    }
}
