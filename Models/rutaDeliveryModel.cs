using Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    [Table("rutaDelivery")]
    public class rutaDeliveryModel
    {
        [Key]
        public Int64 id { get; set; }
        public Int64 id_delivery { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }

        [ForeignKey("id_delivery"),JsonIgnore]
        public virtual deliveryModel? Delivery { get; set; }
    }
}
