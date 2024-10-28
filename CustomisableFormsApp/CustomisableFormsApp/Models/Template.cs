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
        public string? CUSTOM_STRING9_QUESTION { get; set; }
        public string? CUSTOM_STRING9_ANSWER { get; set; }
        public string? CUSTOM_STRING10_QUESTION { get; set; }
        public string? CUSTOM_STRING10_ANSWER { get; set; }
        public string? CUSTOM_STRING11_QUESTION { get; set; }
        public string? CUSTOM_STRING11_ANSWER { get; set; }
        public string? CUSTOM_STRING12_QUESTION { get; set; }
        public string? CUSTOM_STRING12_ANSWER { get; set; }
        public string? CUSTOM_STRING13_QUESTION { get; set; }
        public string? CUSTOM_STRING13_ANSWER { get; set; }
        public string? CUSTOM_STRING14_QUESTION { get; set; }
        public string? CUSTOM_STRING14_ANSWER { get; set; }
        public string? CUSTOM_STRING15_QUESTION { get; set; }
        public string? CUSTOM_STRING15_ANSWER { get; set; }
        public string? CUSTOM_STRING16_QUESTION { get; set; }
        public string? CUSTOM_STRING16_ANSWER { get; set; }
        public string? CUSTOM_STRING17_QUESTION { get; set; }
        public string? CUSTOM_STRING17_ANSWER { get; set; }
        public string? CUSTOM_STRING18_QUESTION { get; set; }
        public string? CUSTOM_STRING18_ANSWER { get; set; }
        public string? CUSTOM_STRING19_QUESTION { get; set; }
        public string? CUSTOM_STRING19_ANSWER { get; set; }
        public string? CUSTOM_STRING20_QUESTION { get; set; }
        public string? CUSTOM_STRING20_ANSWER { get; set; }
        public string? CUSTOM_STRING21_QUESTION { get; set; }
        public string? CUSTOM_STRING21_ANSWER { get; set; }
        public string? CUSTOM_STRING22_QUESTION { get; set; }
        public string? CUSTOM_STRING22_ANSWER { get; set; }
        public string? CUSTOM_STRING23_QUESTION { get; set; }
        public string? CUSTOM_STRING23_ANSWER { get; set; }
        public string? CUSTOM_STRING24_QUESTION { get; set; }
        public string? CUSTOM_STRING24_ANSWER { get; set; }
        public string? CUSTOM_STRING25_QUESTION { get; set; }
        public string? CUSTOM_STRING25_ANSWER { get; set; }
        public string? CUSTOM_STRING26_QUESTION { get; set; }
        public string? CUSTOM_STRING26_ANSWER { get; set; }
        public string? CUSTOM_STRING27_QUESTION { get; set; }
        public string? CUSTOM_STRING27_ANSWER { get; set; }
        public string? CUSTOM_STRING28_QUESTION { get; set; }
        public string? CUSTOM_STRING28_ANSWER { get; set; }
        public string? CUSTOM_STRING29_QUESTION { get; set; }
        public string? CUSTOM_STRING29_ANSWER { get; set; }
        public string? CUSTOM_STRING30_QUESTION { get; set; }
        public string? CUSTOM_STRING30_ANSWER { get; set; }
        public string? CUSTOM_STRING31_QUESTION { get; set; }
        public string? CUSTOM_STRING31_ANSWER { get; set; }
        public string? CUSTOM_STRING32_QUESTION { get; set; }
        public string? CUSTOM_STRING32_ANSWER { get; set; }
        public string? CUSTOM_STRING33_QUESTION { get; set; }
        public string? CUSTOM_STRING33_ANSWER { get; set; }
        public string? CUSTOM_STRING34_QUESTION { get; set; }
        public string? CUSTOM_STRING34_ANSWER { get; set; }
        public string? CUSTOM_STRING35_QUESTION { get; set; }
        public string? CUSTOM_STRING35_ANSWER { get; set; }
        public string? CUSTOM_STRING36_QUESTION { get; set; }
        public string? CUSTOM_STRING36_ANSWER { get; set; }
        public string? CUSTOM_STRING37_QUESTION { get; set; }
        public string? CUSTOM_STRING37_ANSWER { get; set; }
        public string? CUSTOM_STRING38_QUESTION { get; set; }
        public string? CUSTOM_STRING38_ANSWER { get; set; }
        public string? CUSTOM_STRING39_QUESTION { get; set; }
        public string? CUSTOM_STRING39_ANSWER { get; set; }
        public string? CUSTOM_STRING40_QUESTION { get; set; }
        public string? CUSTOM_STRING40_ANSWER { get; set; }
        public string? CUSTOM_STRING41_QUESTION { get; set; }
        public string? CUSTOM_STRING41_ANSWER { get; set; }
        public string? CUSTOM_STRING42_QUESTION { get; set; }
        public string? CUSTOM_STRING42_ANSWER { get; set; }
        public string? CUSTOM_STRING43_QUESTION { get; set; }
        public string? CUSTOM_STRING43_ANSWER { get; set; }
        public string? CUSTOM_STRING44_QUESTION { get; set; }
        public string? CUSTOM_STRING44_ANSWER { get; set; }
        public string? CUSTOM_STRING45_QUESTION { get; set; }
        public string? CUSTOM_STRING45_ANSWER { get; set; }
        public string? CUSTOM_STRING46_QUESTION { get; set; }
        public string? CUSTOM_STRING46_ANSWER { get; set; }
        public string? CUSTOM_STRING47_QUESTION { get; set; }
        public string? CUSTOM_STRING47_ANSWER { get; set; }
        public string? CUSTOM_STRING48_QUESTION { get; set; }
        public string? CUSTOM_STRING48_ANSWER { get; set; }
        public string? CUSTOM_STRING49_QUESTION { get; set; }
        public string? CUSTOM_STRING49_ANSWER { get; set; }
        public string? CUSTOM_STRING50_QUESTION { get; set; }
        public string? CUSTOM_STRING50_ANSWER { get; set; }
    }
}
