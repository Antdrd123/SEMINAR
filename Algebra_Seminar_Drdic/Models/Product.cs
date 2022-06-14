using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra_Seminar_Drdic.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Proizvod")]
        public string Title { get; set; }


        public string? Description { get; set; }


        [Required]
        [Column(TypeName = "decimal(9,2)")]
        //[Display(Name = "Količina")]
        public decimal Quantity { get; set; }


        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }

        
        [Column(TypeName = "nvarchar(1000)")]
        public string? ImageName { get; set; }
    }
}
