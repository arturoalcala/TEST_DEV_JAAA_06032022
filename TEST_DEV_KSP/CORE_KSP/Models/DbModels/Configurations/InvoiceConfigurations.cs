using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_KSP.Models.DbModels.Configurations
{
    public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(d => d.Customer)
                   .WithMany(p => p.InvoiceList)
                   .HasForeignKey(d => d.CusId)
                   .HasConstraintName("FK_Tb_Invoices_Tb_Customers");

            builder.HasOne(d => d.Seller)
                   .WithMany(p => p.InvoiceList)
                   .HasForeignKey(d => d.SelId)
                   .HasConstraintName("FK_Tb_Invoices_Tb_Sellers");

            //// definir registros iniciales
            //builder.HasData(
            //    new PersonaFisica
            //    {
            //        IdPersonaFisica = 1,
            //        Nombre = "arturo",
            //        ApellidoPaterno = "alcalá",
            //        ApellidoMaterno = "amaro",
            //        RFC = "AAAA961215A59",
            //        FechaNacimiento = new DateTime(1996, 12, 15),
            //        IdUsuarioAgrega = 1
            //    },
            //    new PersonaFisica
            //    {
            //        IdPersonaFisica = 2,
            //        Nombre = "judith",
            //        ApellidoPaterno = "moreno",
            //        ApellidoMaterno = "enríquez",
            //        RFC = "MOEL001117A59",
            //        FechaNacimiento = new DateTime(2000, 11, 17),
            //        IdUsuarioAgrega = 1
            //    }
            //);
        }
    }

    public class InvoiceProductConfigurations : IEntityTypeConfiguration<InvoiceProduct>
    {
        public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
        {
            builder.HasOne(d => d.Invoice)
                   .WithMany(p => p.ProductList)
                   .HasForeignKey(d => d.InvId)
                   .HasConstraintName("FK_Tb_InvoiceProducts_Tb_Sellers");

            builder.HasOne(d => d.Product)
                   .WithMany(p => p.InvoiceList)
                   .HasForeignKey(d => d.ProId)
                   .HasConstraintName("FK_Tb_InvoiceProducts_Tb_Products");

            //// definir registros iniciales
            //builder.HasData(
            //    new PersonaFisica
            //    {
            //        IdPersonaFisica = 1,
            //        Nombre = "arturo",
            //        ApellidoPaterno = "alcalá",
            //        ApellidoMaterno = "amaro",
            //        RFC = "AAAA961215A59",
            //        FechaNacimiento = new DateTime(1996, 12, 15),
            //        IdUsuarioAgrega = 1
            //    },
            //    new PersonaFisica
            //    {
            //        IdPersonaFisica = 2,
            //        Nombre = "judith",
            //        ApellidoPaterno = "moreno",
            //        ApellidoMaterno = "enríquez",
            //        RFC = "MOEL001117A59",
            //        FechaNacimiento = new DateTime(2000, 11, 17),
            //        IdUsuarioAgrega = 1
            //    }
            //);
        }
    }
}
