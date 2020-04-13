using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperDigital.IO.Domain.ContaCorrente;
using SuperDigital.IO.Infra.Data.Extensions;
using SuperDigital.IO.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuperDigital.IO.Infra.Data.Context
{
    public class ContaCorrenteContext : DbContext
    {
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ContaCorrenteMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SuperDigital"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
