﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardsPreQualificationWeb.Models
{
    /// <summary>
    /// This View Model is to display who have checked the pre-qualification of credit card details
    /// </summary>
    public class ApplicantDetailsViewModel
    {
        public string FullName { get; set; }
        public float AnnualIncome { get; set; }
        public string BankDetails { get; set; }
        public DateTime AttemptDate { get; set; }
        public int Age { get; set; }       
    }
}
