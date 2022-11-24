using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("cajaDelivery")]
    public class cajaDeliveryModel
    {
        [Key]
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public decimal total { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public bool estado { get; set; }

        [ForeignKey("id_usuario"),JsonIgnore]
        public virtual usuarioModel? Usuario { get; set; }
    }
}
