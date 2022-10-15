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
    [Table("producto")]
    public class productoModel
    {
        [Key]
        public int id {get; set;}
        public string producto { get; set; }
        public string? descripcion { get; set; }
        public int id_proveedor { get; set; }
        public string proveedor { get; set; }
        public int id_categoria {get; set;}
        public string categoria { get; set; }
        public int id_tipoMedida {get; set;}
        public string tipoMedida { get; set; }
        public string? medida {get; set;}
        public string? alto { get; set; }
        public string? ancho { get; set; }
        public string? profundidad { get; set; }
        public decimal precioCompra {get; set;}
        public decimal precioVenta {get; set;}
        public int? stock { get; set; }
        public bool estado { get; set; }
        

        [ForeignKey("id_proveedor"),JsonIgnore]
        public virtual proveedorModel? proveedorMod { get; set; }

        [ForeignKey("id_categoria"),JsonIgnore]
        public virtual categoriaModel? categoriaMod { get; set; }

        [ForeignKey("id_tipoMedida"),JsonIgnore]
        public virtual tipoMedidaModel? tipoMedidaMod { get; set; }
    }
}
