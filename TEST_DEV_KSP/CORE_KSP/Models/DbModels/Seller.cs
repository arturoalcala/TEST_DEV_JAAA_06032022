using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_KSP.Models.DbModels
{
    [Table("Tb_Sellers")]
    public class Seller
    {
        public Seller()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SelId { get; set; }
        [Required, MaxLength(200)]
        public string SelName { get; set; }
        [Required, MaxLength(500)]
        public string SelAddress { get; set; }
        [Required, MaxLength(10)]
        public string SelZipCode { get; set; }

        //public bool CusStatus { get; set; } = true;
        public virtual ICollection<Invoice> InvoiceList { get; set; }
    }
}
