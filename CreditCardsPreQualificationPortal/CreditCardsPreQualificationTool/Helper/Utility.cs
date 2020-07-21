using CreditCardPreQualificationBusinessModels.Models;
using CreditCardsPreQualificationWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardsPreQualificationWeb.Helper
{
    public static class Utility
    {
        public const string UNDER18VIEW = "Under18";
        public const string BARCLAYCARDVIEW = "BarclaycardView";
        public const string VANQUISVIEW = "VanquisView";
        public const string ERROR = "Error";
        public const string DUPLICATE = "DuplicateView";

        /// <summary>
        /// This method is used to Map  View model to business model
        /// </summary>
        /// <param name="viewPersonalInfo">PersonalInfoViewModel as Input</param>
        /// <returns>returns business model PersonalInfo</returns>
        public static PersonalInfo ModelMapperForPersonalInfo(PersonalInfoViewModel viewPersonalInfo)
        {
            PersonalInfo _personalInfo = new PersonalInfo()
            {
                FirstName = viewPersonalInfo.FirstName,
                LastName = viewPersonalInfo.LastName,
                DateofBirth = viewPersonalInfo.DateofBirth,
                Annualincome = viewPersonalInfo.Annualincome
            };
            return _personalInfo;
        }

        /// <summary>
        /// This method is used to Map business model to View model 
        /// </summary>
        /// <param name="listofApplicantDetails">business model as listofApplicantDetails</param>
        /// <returns>returns list of ViewModel</returns>
        public static List<ApplicantDetailsViewModel> ModelMapperForPersonalInfo(List<ApplicantDetails> listofApplicantDetails)
        {
            List<ApplicantDetailsViewModel> listofApplicantViews = new List<ApplicantDetailsViewModel>();

            foreach (ApplicantDetails applicantdetails in listofApplicantDetails)
            {
                    ApplicantDetailsViewModel _appdetails = new ApplicantDetailsViewModel()
                    {
                        Age = applicantdetails.Age,
                        AnnualIncome = applicantdetails.AnnualIncome,
                        AttemptDate = applicantdetails.AttemptDate,
                        BankDetails = applicantdetails.BankDetails,
                        FullName = applicantdetails.FullName

                    };
                listofApplicantViews.Add(_appdetails);
            }
            
            return listofApplicantViews;
        }
          
    }
}
