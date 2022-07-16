using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{   
    [Table("estadoVenta")]
    public class estadoVentaModel
    {
        [Key]
        public int id { get; set; }
        public string ordenEstado { get; set; }
        public bool estado { get; set; }
    }
}
