using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CORE_KSP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Customers",
                columns: table => new
                {
                    CusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CusName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CusAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CusZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Customers", x => x.CusId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Products",
                columns: table => new
                {
                    ProId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProPrice = table.Column<double>(type: "float", nullable: false),
                    ProStock = table.Column<int>(type: "int", nullable: false),
                    ProMinStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Products", x => x.ProId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Sellers",
                columns: table => new
                {
                    SelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SelAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SelZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Sellers", x => x.SelId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Invoices",
                columns: table => new
                {
                    InvId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvIVA = table.Column<double>(type: "float", nullable: false),
                    InvTotal = table.Column<double>(type: "float", nullable: false),
                    CusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Invoices", x => x.InvId);
                    table.ForeignKey(
                        name: "FK_Tb_Invoices_Tb_Customers",
                        column: x => x.CusId,
                        principalTable: "Tb_Customers",
                        principalColumn: "CusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Invoices_Tb_Sellers",
                        column: x => x.SelId,
                        principalTable: "Tb_Sellers",
                        principalColumn: "SelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_InvoiceProducts",
                columns: table => new
                {
                    IProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IPrAmountProduct = table.Column<int>(type: "int", nullable: false),
                    IPrSalePrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_InvoiceProducts", x => x.IProId);
                    table.ForeignKey(
                        name: "FK_Tb_InvoiceProducts_Tb_Products",
                        column: x => x.ProId,
                        principalTable: "Tb_Products",
                        principalColumn: "ProId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_InvoiceProducts_Tb_Sellers",
                        column: x => x.InvId,
                        principalTable: "Tb_Invoices",
                        principalColumn: "InvId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_InvoiceProducts_InvId",
                table: "Tb_InvoiceProducts",
                column: "InvId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_InvoiceProducts_ProId",
                table: "Tb_InvoiceProducts",
                column: "ProId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Invoices_CusId",
                table: "Tb_Invoices",
                column: "CusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Invoices_SelId",
                table: "Tb_Invoices",
                column: "SelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_InvoiceProducts");

            migrationBuilder.DropTable(
                name: "Tb_Products");

            migrationBuilder.DropTable(
                name: "Tb_Invoices");

            migrationBuilder.DropTable(
                name: "Tb_Customers");

            migrationBuilder.DropTable(
                name: "Tb_Sellers");
        }
    }
}
