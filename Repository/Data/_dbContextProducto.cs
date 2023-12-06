using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Repository.Data
{
    public class _dbContextProducto:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string conexion = globalVar.cnn;
            optionsBuilder.UseSqlServer(connectionString: conexion);
        }

        //producto
        public DbSet<tipoMedidaModel> tipoMedida { get; set; }
        public DbSet<categoriaModel> categoria { get; set; }
        public DbSet<imgProductoModel> imgProducto { get; set; }
        public DbSet<inventarioModel> inventario { get; set; }
        public DbSet<colorProductoModel> colorProducto { get; set; }
        public DbSet<tallaProductoModel> tallaProducto { get; set; }
        public DbSet<tallaColorModel> tallaColor { get; set; }
        public DbSet<coloresModel> colores { get; set; }
        public DbSet<productoModel> producto { get; set; }
        public DbSet<ingresoProductoModel> ingresoProducto { get; set; }
        public DbSet<tallasModel> tallas { get; set; }
    }
}
