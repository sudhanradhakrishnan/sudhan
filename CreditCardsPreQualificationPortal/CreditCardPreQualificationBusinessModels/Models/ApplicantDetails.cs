using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardPreQualificationBusinessModels.Models
{
    public class ApplicantDetails
    {
        public string FullName { get; set; }
        public float AnnualIncome { get; set; }
        public string BankDetails { get; set; }
        public DateTime AttemptDate { get; set; }
        public int Age { get; set; }
    }
}
