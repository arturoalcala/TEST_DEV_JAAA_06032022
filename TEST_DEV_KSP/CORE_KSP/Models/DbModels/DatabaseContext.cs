using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CORE_KSP.Models.DbModels
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // stablishing connection string
                var connectionString = @"Server=localhost;Database=DB_KSP;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // adding every existing context's configuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region Tables

        public virtual DbSet<Customer> Tb_Customers { get; set; }
        public virtual DbSet<Product> Tb_Products { get; set; }
        public virtual DbSet<Seller> Tb_Sellers { get; set; }
        public virtual DbSet<Invoice> Tb_Invoices { get; set; }
        public virtual DbSet<InvoiceProduct> Tb_InvoiceProducts { get; set; }

        #endregion
    }
}