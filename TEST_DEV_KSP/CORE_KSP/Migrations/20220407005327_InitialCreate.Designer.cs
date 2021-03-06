// <auto-generated />
using System;
using CORE_KSP.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CORE_KSP.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220407005327_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Customer", b =>
                {
                    b.Property<Guid>("CusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CusAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CusName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CusZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CusId");

                    b.ToTable("Tb_Customers");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Invoice", b =>
                {
                    b.Property<Guid>("InvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InvDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("InvIVA")
                        .HasColumnType("float");

                    b.Property<double>("InvTotal")
                        .HasColumnType("float");

                    b.Property<Guid>("SelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InvId");

                    b.HasIndex("CusId");

                    b.HasIndex("SelId");

                    b.ToTable("Tb_Invoices");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.InvoiceProduct", b =>
                {
                    b.Property<int>("IProId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IPrAmountProduct")
                        .HasColumnType("int");

                    b.Property<double>("IPrSalePrice")
                        .HasColumnType("float");

                    b.Property<Guid>("InvId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IProId");

                    b.HasIndex("InvId");

                    b.HasIndex("ProId");

                    b.ToTable("Tb_InvoiceProducts");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Product", b =>
                {
                    b.Property<Guid>("ProId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ProMinStock")
                        .HasColumnType("int");

                    b.Property<double>("ProPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProStock")
                        .HasColumnType("int");

                    b.HasKey("ProId");

                    b.ToTable("Tb_Products");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Seller", b =>
                {
                    b.Property<Guid>("SelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SelAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SelName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SelZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("SelId");

                    b.ToTable("Tb_Sellers");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Invoice", b =>
                {
                    b.HasOne("CORE_KSP.Models.DbModels.Customer", "Customer")
                        .WithMany("InvoiceList")
                        .HasForeignKey("CusId")
                        .HasConstraintName("FK_Tb_Invoices_Tb_Customers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CORE_KSP.Models.DbModels.Seller", "Seller")
                        .WithMany("InvoiceList")
                        .HasForeignKey("SelId")
                        .HasConstraintName("FK_Tb_Invoices_Tb_Sellers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.InvoiceProduct", b =>
                {
                    b.HasOne("CORE_KSP.Models.DbModels.Invoice", "Invoice")
                        .WithMany("ProductList")
                        .HasForeignKey("InvId")
                        .HasConstraintName("FK_Tb_InvoiceProducts_Tb_Sellers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CORE_KSP.Models.DbModels.Product", "Product")
                        .WithMany("InvoiceList")
                        .HasForeignKey("ProId")
                        .HasConstraintName("FK_Tb_InvoiceProducts_Tb_Products")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Customer", b =>
                {
                    b.Navigation("InvoiceList");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Invoice", b =>
                {
                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Product", b =>
                {
                    b.Navigation("InvoiceList");
                });

            modelBuilder.Entity("CORE_KSP.Models.DbModels.Seller", b =>
                {
                    b.Navigation("InvoiceList");
                });
#pragma warning restore 612, 618
        }
    }
}
