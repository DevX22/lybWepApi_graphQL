using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("ingresoProducto")]
    public class ingresoProductoModel
    {
        [Key]
        public int id { get; set; }
        public int id_producto {get; set;}
        public string producto {get; set;}
        public int cantidad {get; set;}
        public int id_usuario  {get; set;}
        public DateTime fechaIngreso { get; set; }

        [ForeignKey("id_producto")]
        public virtual productoModel Producto { get; set; }

        //[ForeignKey("id_usuario")]
        //public virtual usuarioModel Usuario { get; set; }


    }
}
