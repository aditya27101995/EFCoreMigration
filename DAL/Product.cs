using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
    [Table("Products", Schema ="dbo")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; } 
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        
        //Navigation Property
        //virtual adding, its is a lazy loading
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
