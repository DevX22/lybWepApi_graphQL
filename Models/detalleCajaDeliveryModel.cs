using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    [Table("detalleCajaDelivery")]
    public class detalleCajaDeliveryModel
    {
        [Key]
        public Int64 id { get; set; }
        public int id_cajaDelivery { get; set; }
        public Int64 id_delivery { get; set; }
        public Int64? id_venta { get; set; }
        public string? cliente { get; set; }
        public decimal total { get; set; }

        [ForeignKey("id_cajaDelivery"),JsonIgnore]
        public virtual cajaDeliveryModel CajaDelivery { get; set; }

        [ForeignKey("id_delivery"),JsonIgnore]
        public virtual deliveryModel Delivery { get; set; }
    }
}
