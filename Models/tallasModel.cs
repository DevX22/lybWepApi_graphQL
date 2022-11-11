using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("tallas")]
    public class tallasModel
    {
        [Key]
        public int id { get; set; }
        [MaxLength(4)]
        public string talla { get; set; }
    }
}
