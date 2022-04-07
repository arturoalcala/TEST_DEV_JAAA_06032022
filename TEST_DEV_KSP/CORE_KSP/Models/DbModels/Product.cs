using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_KSP.Models.DbModels
{
    [Table("Tb_Products")]
    public class Product
    {
        public Product()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProId { get; set; }
        [Required, MaxLength(500)]
        public string ProDescription { get; set; }
        [Required]
        public double ProPrice { get; set; } = 0;
        [Required]
        public int ProStock{ get; set; } = 0;
        [Required]
        public int ProMinStock { get; set; } = 0;

        //public bool CusStatus { get; set; } = true;
        //public virtual ICollection<PersonaFisica> PersonaFisicas { get; set; }
        public virtual ICollection<InvoiceProduct> InvoiceList { get; set; }

    }
}
