using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsTestClassLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string PartNbr { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(30)]
        public string Unit { get; set; }

        [MaxLength(255)]
        public string PhotoPath { get; set; }

        
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }


        public Product() { }
    }
}
