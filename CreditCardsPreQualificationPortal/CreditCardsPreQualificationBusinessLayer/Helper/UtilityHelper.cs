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
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;
            Age findage = new Age(dateOfBirth);

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


        /// <summary>
        /// Calculate age in years relative to months and days, for example Peters age is 25 years 2 months and 10 days
        /// </summary>
        /// <param name="startDate">The date when the age started</param>
        /// <param name="endDate">The date when the age ended</param>
        /// <param name="calendar">Calendar used to calculate age</param>
        /// <param name="years">Return number of years, with considering months and days</param>
        /// <param name="months">Return calculated months</param>
        /// <param name="days">Return calculated days</param>
        public static bool GetAge(this DateTime startDate, DateTime endDate, Calendar calendar, out int years, out int months, out int days)
        {
            if (startDate > endDate)
            {
                years = months = days = -1;
                return false;
            }

            years = months = days = 0;
            days += calendar.GetDayOfMonth(endDate) - calendar.GetDayOfMonth(startDate);

            // When negative select days of last month
            if (days < 0)
            {
                days += calendar.GetDaysInMonth(calendar.GetYear(startDate), calendar.GetMonth(startDate));
                months--;
            }

            months += calendar.GetMonth(endDate) - calendar.GetMonth(startDate);

            // when negative select month of last year
            if (months < 0)
            {
                months += calendar.GetMonthsInYear(calendar.GetYear(startDate));
                years--;
            }

            years += calendar.GetYear(endDate) - calendar.GetYear(startDate);

            return true;
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
