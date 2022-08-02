using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Algebra_Seminar_Drdic.Models
{
    public class HelperUser
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Role { get; set; }


    }
}
