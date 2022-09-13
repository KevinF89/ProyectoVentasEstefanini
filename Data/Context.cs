using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Memory;
using System.IO;
using Data.Entities;
//using Data.Entities;

namespace Data
{
    public class Context : DbContext
    {

        public Context()
        {
        }
        public Context(DbContextOptions<Context> options)
          : base(options)
        {
        }

        public static string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();
            var sampleConnectionString = root.GetConnectionString("Gestionconn");
            return sampleConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var con = GetConnectionString();
                optionsBuilder.UseSqlServer(con);
            }
        }

        #region DataSet 


        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteProducto> ClienteProducto { get; set; }
        public virtual DbSet<MedioDePago> MediosDePago { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoDocumento> TiposDeDocumento { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
