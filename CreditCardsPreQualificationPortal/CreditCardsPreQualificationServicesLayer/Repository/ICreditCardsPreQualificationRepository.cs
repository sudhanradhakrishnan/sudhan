using CreditCardPreQualificationBusinessModels.Models;
using System.Collections.Generic;

namespace CreditCardsPreQualificationServicesLayer.Repository
{
    /// <summary>
    /// Interface for CreditCards PreQualification Repository
    /// </summary>
    public interface ICreditCardsPreQualificationRepository
    {
        /// <summary>
        /// This Method is used to insert details in BD for Audit report
        /// </summary>
        /// <param name="personalInfo">object of PersonalInfo</param>
        /// <returns>return the row number inserted</returns>
        int CheckPreQualification(PersonalInfo personalInfo);

        /// <summary>
        /// This method is used to Add the Bank details for each applicant.
        /// </summary>
        /// <param name="PersonalInfoId">PersonalInfoId id which is received from CheckPreQualification method </param>
        /// <param name="BankDetails">Bank id details</param>
       void AddReportInfo(int PersonalInfoId, int BankDetails);

        /// <summary>
        /// This method is used to Get the Audit report 
        /// <summary>
        /// <returns>List of ApplicantDetails </returns>
        List<ApplicantDetails> GetAllApplicantInformation();
    }
}