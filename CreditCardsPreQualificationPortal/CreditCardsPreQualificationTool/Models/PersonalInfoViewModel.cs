using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditCardsPreQualificationWeb.Models
{
    /// <summary>
    /// This View Model is used to capture the input details for checking the pre-qualification of credit card details
    /// </summary>
    public class PersonalInfoViewModel
    {

        [Required(ErrorMessage = "Please enter First Name")]        
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "Please enter Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateofBirth { get; set; }

        [DisplayName("Annual Income")]
        [Required(ErrorMessage = "Please enter Annual income")]
        public float Annualincome { get; set; }

    }
}