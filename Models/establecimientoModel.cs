using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("establecimiento")]
    public class establecimientoModel
    {
        [Key]
        public int id { get; set; }
        public string establecimiento { get; set; }
        public string direccion { get; set; }
        public decimal origenLat { get; set; }
        public decimal origenLng { get; set; }
        public bool estado { get; set; }
    }
}
