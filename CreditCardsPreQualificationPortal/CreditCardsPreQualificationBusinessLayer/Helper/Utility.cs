using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardsPreQualificationBusinessLayer.Helper
{
    /// <summary>
    /// This Class is to hold const value.
    /// </summary>
    public static class Utility
    {
        public const int DUPLICATE = 0;
        public const int UNDER18 = 1;//1.	If applicant is under 18, show the message ‘no credit cards are available
        public const int BARCLAYCARD = 2;//2.	If applicant is over 18 and has an annual income over £30,000, show a Barclaycard credit card
        public const int VANQUIS = 3;//3.	Otherwise, show a Vanquis card
    }
  
}
