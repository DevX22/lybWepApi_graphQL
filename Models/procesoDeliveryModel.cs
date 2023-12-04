using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("procesoDelivery")]
    public class procesoDeliveryModel
    {
        [Key]
        public int id { get; set; }
        public int? ordenProceso { get; set; }
        public string proceso { get; set; }
    }
}
