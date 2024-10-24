using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomisableFormsApp.Models
{
    public class Template
    {
        public int ID { get; set; }
        public string? TITLE { get; set; }
        public string? DESCRIPTION { get; set; }

        public string? USER_ID { get; set; }
        [ForeignKey("USER_ID")]
        [ValidateNever]
        public IdentityUser? User { get; set; }

        public string? USER_ID_CANDIDATE { get; set; }
        [ForeignKey("USER_ID_CANDIDATE")]
        [ValidateNever]
        public IdentityUser? User_CANDIDATE { get; set; }

        public string? CUSTOM_STRING1_QUESTION { get; set; }
        public string? CUSTOM_STRING1_ANSWER { get; set; }
        public string? CUSTOM_STRING2_QUESTION { get; set; }
        public string? CUSTOM_STRING2_ANSWER { get; set; }
        public string? CUSTOM_STRING3_QUESTION { get; set; }
        public string? CUSTOM_STRING3_ANSWER { get; set; }
        public string? CUSTOM_STRING4_QUESTION { get; set; }
        public string? CUSTOM_STRING4_ANSWER { get; set; }
        public string? CUSTOM_STRING5_QUESTION { get; set; }
        public string? CUSTOM_STRING5_ANSWER { get; set; }
        public string? CUSTOM_STRING6_QUESTION { get; set; }
        public string? CUSTOM_STRING6_ANSWER { get; set; }
        public string? CUSTOM_STRING7_QUESTION { get; set; }
        public string? CUSTOM_STRING7_ANSWER { get; set; }
        public string? CUSTOM_STRING8_QUESTION { get; set; }
        public string? CUSTOM_STRING8_ANSWER { get; set; }

    }
}
