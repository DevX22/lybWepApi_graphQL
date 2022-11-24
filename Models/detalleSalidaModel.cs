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
    [Table("detalleSalida")]
    public class detalleSalidaModel
    {
        [Key]
        public int id { get; set; }
        public Int64 id_salida { get; set; }
        public int id_producto { get; set; }
        public string producto { get; set; }
        public int id_establecimiento { get; set; }
        public int cantidad { get; set; }

        [ForeignKey("id_salida"),JsonIgnore]
        public virtual salidaProductoModel? SalidaProducto { get; set; }

        [ForeignKey("id_producto"),JsonIgnore]
        public virtual productoModel? Producto { get; set; }

        [ForeignKey("id_establecimiento"),JsonIgnore]
        public virtual establecimientoModel? Establecimiento { get; set; }
    }
}
