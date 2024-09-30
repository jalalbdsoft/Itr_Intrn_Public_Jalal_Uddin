using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UserManagementApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Position { get; set; }

    [PersonalData]
    [Column(TypeName = "DateTime")]
    public DateTime RegistrationTime { get; set; } = DateTime.Now;

    [PersonalData]
    [Column(TypeName = "DateTime")]
    public DateTime? LastLoginTime { get; set; } //property to store the last login time

    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string Status { get; set; } = "Active";
}

