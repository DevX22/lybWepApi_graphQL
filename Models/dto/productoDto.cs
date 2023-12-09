using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class productoDto
    {
        public int id { get; set; }
        public string producto { get; set; }
        public string? descripcion { get; set; }
        public int id_proveedor { get; set; }
        public string proveedor { get; set; }
        public int id_categoria { get; set; }
        public string categoria { get; set; }
        public int id_tipoMedida { get; set; }
        public string tipoMedida { get; set; }
        public string? medida { get; set; }
        public string? alto { get; set; }
        public string? ancho { get; set; }
        public string? profundidad { get; set; }
        public decimal precioVenta { get; set; }
        public int? stock { get; set; }
        public bool estado { get; set; }
        public virtual List<colorProductoDto>? colorProducto { get; set; }
        public virtual List<imgProductoDto>? imgProducto { get; set; }
        public virtual List<tallaProductoDto>? TallaProducto { get; set; }

        /*
            -- Crear un índice en la columna id_producto de la tabla colorProducto
            -- CREATE INDEX IDX_ColorProducto_IdProducto ON colorProducto (id_producto)
            -- CREATE INDEX IDX_ImgProducto_IdProducto ON imgProducto (id_producto)
            -- CREATE INDEX IDX_TallaProducto_IdProducto ON tallaProducto (id_producto)
            -- CREATE INDEX IDX_ColorTalla_IdTalla ON tallaColor (id_talla)
         */
    }
}
