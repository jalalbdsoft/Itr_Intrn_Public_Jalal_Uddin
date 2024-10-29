using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomisableFormsApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public DateTime RegistrationTime { get; set; } = DateTime.Now;

        [PersonalData]
        [Column(TypeName = "DateTime")]
        public DateTime? LastLoginTime { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } = "Active";
        public List<string> Roles { get; set; } = new List<string>();
    }
}
