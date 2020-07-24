using System;
using System.Collections.Generic;
using System.Globalization;
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
            int age = 0, dayofyr = 0;
            //if leap year and past february 28
            if (DateTime.IsLeapYear(dateOfBirth.Year) && dateOfBirth.DayOfYear >= 60)
            {
                dayofyr = dateOfBirth.DayOfYear - 1;
            }
            else
            {
                dayofyr = dateOfBirth.DayOfYear;
            }
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dayofyr)
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



    public class Age
    {
        public int Years;
        public int Months;
        public int Days;

        public Age(DateTime Bday)
        {
            this.Count(Bday);
        }

        public Age(DateTime Bday, DateTime Cday)
        {
            this.Count(Bday, Cday);
        }

        public Age Count(DateTime Bday)
        {
            return this.Count(Bday, DateTime.Today);
        }

        public Age Count(DateTime Bday, DateTime Cday)
        {
            if ((Cday.Year - Bday.Year) > 0 ||
                (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                  ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Month > Bday.Month)
                {
                    this.Years = Cday.Year - Bday.Year;
                    this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (Cday.Month == Bday.Month)
                {
                    if (Cday.Day >= Bday.Day)
                    {
                        this.Years = Cday.Year - Bday.Year;
                        this.Months = 0;
                        this.Days = Cday.Day - Bday.Day;
                    }
                    else
                    {
                        this.Years = (Cday.Year - 1) - Bday.Year;
                        this.Months = 11;
                        this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                    }
                }
                else
                {
                    this.Years = (Cday.Year - 1) - Bday.Year;
                    this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
            }
            else
            {
                throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return this;
        }
    }

}
