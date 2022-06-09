using System.ComponentModel.DataAnnotations;

namespace Algebra_Seminar_Drdic.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Kategorija")]
        public string Title { get; set; }
    }
}
