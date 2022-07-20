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
            configurationBuilder = configurationBuilder.AddJsonFile("secrets.json");

            IConfiguration configurationFile = configurationBuilder.Build();
            string conexion = configurationFile.GetConnectionString("db");
            */

            string conexion = globalVar.db;
            optionsBuilder.UseSqlServer(connectionString: conexion);
        }
        #endregion

        public DbSet<avatarModel> avatar { get; set; }
        public DbSet<clienteModel> cliente { get; set; }
        public DbSet<personaModel> persona { get; set; }
        public DbSet<tipoDocumentoModel> tipodocumento { get; set; }
    }
}
