using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_KSP.Models.DbModels
{
    [Table("Tb_Invoices")]
    public class Invoice
    {
        public Invoice()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InvId { get; set; }
        [Required]
        public DateTime InvDate { get; set; }
        [Required]
        public double InvIVA { get; set; } = 0;
        [Required]
        public double InvTotal { get; set; } = 0;

        [ForeignKey("Customer")]
        public Guid CusId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Seller")]
        public Guid SelId { get; set; }
        public virtual Seller Seller { get; set; }

        public virtual ICollection<InvoiceProduct> ProductList { get; set; }
    }

    [Table("Tb_InvoiceProducts")]
    public class InvoiceProduct
    {
        public InvoiceProduct()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IProId { get; set; }
        
        [ForeignKey("Invoice")]
        public Guid InvId { get; set; }
        public virtual Invoice Invoice { get; set; }

        [ForeignKey("Product")]
        public Guid ProId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int IPrAmountProduct { get; set; } = 0;
        [Required]
        public double IPrSalePrice { get; set; } = 0;
    }
}
