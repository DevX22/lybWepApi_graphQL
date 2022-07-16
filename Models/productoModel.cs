using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("producto")]
    public class productoModel
    {
        [Key]
        public int id {get; set;}
        public int id_proveedor { get; set; }
        public string producto{get; set;}
        public string descripcion{get; set;}
        public int id_categoria {get; set;}
        public int id_tipo_medida {get; set;}
        public int valor {get; set;}
        public int id_color {get; set;}
        public int precioCompra {get; set;}
        public int precioVenta {get; set;}
        public int stock { get; set; }
        public bool estado { get; set; }
        

        //[ForeignKey("id_proveedor")]
        //public virtual proveedorModel Proveedor { get; set; }

        //[ForeignKey("id_categoria")]
        //public virtual categoriaModel Categoria { get; set; }

        //[ForeignKey("id_tipo_medida")]
        //public virtual tipoMedidaModal TipoMedida { get; set; }

        //[ForeignKey("id_color")]
        //public virtual colorModel Color { get; set; }
    }
}
