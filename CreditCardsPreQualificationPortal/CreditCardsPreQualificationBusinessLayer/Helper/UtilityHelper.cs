using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardsPreQualificationBusinessLayer.Helper
{
    /// <summary>
    /// This class hold all helper method used for Calculate Age and Convert To Int
    /// </summary>
    public static class UtilityHelper
    {
        /// <summary>  
        /// For calculating only age  
        /// </summary>  
        /// <param name="dateOfBirth">Date of birth</param>  
        /// <returns> age e.g. 26</returns>  
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }


        /// <summary>  
        /// For calculating only age  
        /// </summary>  
        /// <param name="dateOfBirth">Date of birth</param>  
        /// <returns> age e.g. 26</returns>  
        public static int ConvertToInt(string inputValue)
        {
            int returnInt = 0;
            int.TryParse(inputValue, out returnInt);
            return returnInt;
        }
    }
}
