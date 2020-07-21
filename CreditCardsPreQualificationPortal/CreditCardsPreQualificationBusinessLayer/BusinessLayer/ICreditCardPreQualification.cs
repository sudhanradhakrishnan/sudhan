using CreditCardPreQualificationBusinessModels.Models;
using System.Collections.Generic;

namespace CreditCardsPreQualificationBusinessLayer.BusinessLayer
{
    /// <summary>
    /// Interface for CreditCards PreQualification
    /// </summary>
    public interface ICreditCardPreQualification
    {
        /// <summary>
        /// This method is used to Insert Details in DB
        /// </summary>
        /// <param name="personalInfo">Applicant  object PersonalInfo</param>
        /// <returns>Return which Bank Credit Card is Qualified </returns>
        int CheckPreQualification(PersonalInfo obj);

        /// <summary>
        /// This method is used to Calculate Age And Income
        /// </summary>
        /// <param name="personalinfo"></param>
        /// <returns></returns>
        PersonalInfo CalculateAgeAndIncome(PersonalInfo personalinfo);

        /// <summary>
        /// This method is used to Get the all applicant information to display in report screen 
        /// </summary>
        /// <returns>List of Applicant Details</returns>
        List<ApplicantDetails> GetAllApplicantInformation();
    }
}