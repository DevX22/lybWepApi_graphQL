using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class _dbContext:DbContext
    {
        #region config
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder = configurationBuilder.AddJsonFile("appsettings.json");

            IConfiguration configurationFile = configurationBuilder.Build();
            string conexion = configurationFile.GetConnectionString("conexion");
            optionsBuilder.UseSqlServer(connectionString: conexion);
            */

            string conexion = globalVar.cnn;
            optionsBuilder.UseSqlServer(connectionString: conexion);
        }
        #endregion

        //cliente
        public DbSet<avatarModel> avatar { get; set; }
        public DbSet<clienteModel> cliente { get; set; }
        //dato
        public DbSet<personaModel> persona { get; set; }
        public DbSet<tipoDocumentoModel> tipodocumento { get; set; }
        //usuario
        public DbSet<usuarioModel> usuario { get; set; }
        public DbSet<rolUsuarioModel> rolUsuario { get; set; }
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
        //proveedor
        public DbSet<proveedorModel> proveedor { get; set; }

    }
}
