using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_KSP.Models.DbModels
{
    [Table("Tb_Customers")]
    public class Customer
    {
        public Customer()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CusId { get; set; }
        [Required, MaxLength(200)]
        public string CusName { get; set; }
        [Required, MaxLength(500)]
        public string CusAddress { get; set; }
        [Required, MaxLength(10)]
        public string CusZipCode { get; set; }

        //public bool CusStatus { get; set; } = true;
        public virtual ICollection<Invoice> InvoiceList { get; set; }
    }
}
