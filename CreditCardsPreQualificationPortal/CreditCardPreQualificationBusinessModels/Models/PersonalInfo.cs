using System;

namespace CreditCardPreQualificationBusinessModels.Models
{
    public class PersonalInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public float Annualincome { get; set; }
        public int BankId { get; set; }
        public int Age { get; set; }

    }
}