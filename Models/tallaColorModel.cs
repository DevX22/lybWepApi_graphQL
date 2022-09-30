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
    [Table("tallaColor")]
    public class tallaColorModel
    {
        [Key]
        public int id { get; set; }
        public int id_talla { get; set; }
        public int stock { get; set; }
        public string colorName { get; set; }
        public string colorCode { get; set; }

        [ForeignKey("id_talla"),JsonIgnore]
        public virtual tallaProductoModel? talla { get; set; }
    }
}
