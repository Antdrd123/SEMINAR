using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Algebra_Seminar_Drdic.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

    }
}
