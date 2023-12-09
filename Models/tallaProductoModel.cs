using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("tallaProducto")]
    public class tallaProductoModel
    {
        [Key]
        public int id { get; set; }
        public int id_producto { get; set; }
        public int? stock { get; set; }
        public string? talla { get; set; }

        [ForeignKey("id_producto"),JsonIgnore]
        public virtual productoModel? producto { get; set; }

        public virtual List<tallaColorModel>? colorTalla { get; set; }
    }
}
