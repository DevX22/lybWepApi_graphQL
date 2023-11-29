using Microsoft.EntityFrameworkCore;
using Models;
using Models.err_Models;
using Tools;

namespace Repository.Data
{
    public class _dbContext:DbContext
    {
        #region config_converterDateOnly
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {

            builder.Properties<DateOnly>()
                .HaveConversion<dateOnlyConverter>()
                .HaveColumnType("date");
            builder.Properties<TimeOnly>()
                .HaveConversion<timeOnlyConverter>()
                .HaveColumnType("time");
            base.ConfigureConventions(builder);
        }
        #endregion

        #region config_DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region old_Connection
            /*
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder = configurationBuilder.AddJsonFile("appsettings.json");

            IConfiguration configurationFile = configurationBuilder.Build();
            string conexion = configurationFile.GetConnectionString("db");
            optionsBuilder.UseSqlServer(connectionString: conexion);
            */
            #endregion

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
        public DbSet<ingresoProductoModel> ingresoProducto { get; set; }
        public DbSet<tallasModel> tallas { get; set; }
        //proveedor
        public DbSet<proveedorModel> proveedor { get; set; }
        //venta
        public DbSet<procesoVentaModel> procesoVenta { get; set; }
        public DbSet<ventaModel> venta { get; set; }
        public DbSet<detalleVentaModel> detalleVenta { get; set; }
        //timeToken
        public DbSet<timeTokenModel> timeToken { get; set; }
        //err_back
        public DbSet<err_BackModel> err_back { get; set; }

        //domainUrl
        public DbSet<domainUrlModel> domainUrl { get; set; }

        //establecimiento

        public DbSet<establecimientoModel> establecimiento { get; set; }

        public DbSet<tipoComprobanteModel> tipoComprobante { get; set; }

        public DbSet<tipoPagoModel> tipoPago { get; set;}




    }
}
