using Microsoft.EntityFrameworkCore.Migrations;

namespace CORE_KSP.Migrations
{
    public partial class StoredProcedures_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_GetCustomerInvoices
                AS
                BEGIN
	                SELECT cus.CusId, cus.CusName, cus_inv.SelId, cus_inv.SelName
	                FROM Tb_Customers AS cus 
	                LEFT JOIN (
		                SELECT DISTINCT inv.CusId, sel.SelId, sel.SelName 
		                FROM Tb_Invoices inv 
		                INNER JOIN Tb_Sellers sel
		                ON inv.SelId = sel.SelId
	                ) AS cus_inv ON cus_inv.CusId = cus.CusId
	                ORDER BY cus.CusName, cus_inv.SelName
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_GetProducts
				AS
				BEGIN
					DECLARE @monthStartSemester INT = 07,
							@monthEndSemester INT = 12,
							@minDiffCustomers INT = 10

					DECLARE @monthStart DATE = DATEFROMPARTS(YEAR(DATEADD(YY, -1, GETDATE())), 7, 01),
							@monthEnd DATE = DATEADD(DD, -1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1)) 

					SELECT pro.ProId, 
						   pro.ProDescription, 
						   ISNULL(pro.ProPrice, 0) as 'ProPrice', 
						   ISNULL(pro.ProStock, 0) as 'ProStock', 
						   ISNULL(pro.ProMinStock, 0) as 'ProMinStock'
					FROM Tb_Products AS pro
					WHERE pro.ProId IN (SELECT ipr.ProId FROM Tb_InvoiceProducts AS ipr 
										WHERE ipr.InvId IN 
										(
											SELECT inv.InvId
											FROM Tb_Invoices inv
											INNER JOIN Tb_Sellers sel
											ON inv.SelId = sel.SelId
											WHERE inv.InvDate BETWEEN @monthStart AND @monthEnd
											GROUP BY inv.SelId , inv.InvId
											HAVING COUNT(inv.SelId) >= 1
										))
					ORDER BY SUBSTRING(pro.ProDescription, 2, 1)
				END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetCustomerInvoices");
			migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetProducts");
        }
    }
}
