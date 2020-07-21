using CreditCardPreQualificationBusinessModels.Models;
using CreditCardsPreQualificationBusinessLayer.Helper;
using CreditCardsPreQualificationServicesLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CreditCardsPreQualificationBusinessLayer.BusinessLayer
{
    /// <summary>
    /// This Class is used to implement business layer
    /// Calculate the age and display result based on the age under 18.
    /// </summary>
    public class CreditCardPreQualification : ICreditCardPreQualification
    {
        private readonly ILogger<CreditCardPreQualification> _logger;

        private ICreditCardsPreQualificationRepository _CreditCardsPreQualificationRepository;
        private readonly IConfiguration config;
       
        public CreditCardPreQualification(IConfiguration configuration, ILogger<CreditCardPreQualification> logger)
        {
            _logger = logger;

            ILoggerFactory loggerFactory = new LoggerFactory();
            ILogger<CreditCardsPreQualificationRepository> Repositorylogger = loggerFactory.CreateLogger<CreditCardsPreQualificationRepository>();

            _CreditCardsPreQualificationRepository = new CreditCardsPreQualificationRepository(configuration, Repositorylogger);
            config = configuration;
        }

        /// <summary>
        /// This method is used to Insert Details in DB
        /// </summary>
        /// <param name="personalInfo">Applicant  object PersonalInfo</param>
        /// <returns>Return which Bank Credit Card is Qualified </returns>
        public int CheckPreQualification(PersonalInfo personalInfo)
        {
            try
            {

                personalInfo = CalculateAgeAndIncome(personalInfo);

                int rowidentity = _CreditCardsPreQualificationRepository.CheckPreQualification(personalInfo);

                if (rowidentity == -1)
                {
                    personalInfo.BankId = Utility.DUPLICATE;
                    _logger.LogInformation($"Services Name : Creditcardsprequalificationservice , Method Name : InsertPersondetails ,DUPLICATE Person information checked");
                }
                else
                {
                  _CreditCardsPreQualificationRepository.AddReportInfo(rowidentity, personalInfo.BankId);
                }
                _logger.LogInformation($"Services Name : Creditcardsprequalificationservice , Method Name : InsertPersondetails ,Person information added successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Services Name : Creditcardsprequalificationservice , Method Name : InsertPersondetails Error Message :, {ex.Message }");
                throw ex;
            }
            finally
            {

            }

            return personalInfo.BankId;
        }

        /// <summary>
        /// This method is used to Calculate Age And Income
        /// </summary>
        /// <param name="personalinfo"></param>
        /// <returns></returns>
        public PersonalInfo CalculateAgeAndIncome(PersonalInfo personalinfo)
        {
            DateTime dateOfBirth = (DateTime)personalinfo.DateofBirth;
            int age = UtilityHelper.CalculateAge(dateOfBirth);
            int bankInfo;
            int ageLimit = UtilityHelper.ConvertToInt(config.GetValue<string>("Config:Keyvalues:Age"));
            int incomeLimit = UtilityHelper.ConvertToInt(config.GetValue<string>("Config:Keyvalues:Annualincome")); ;
            if (age > ageLimit)
            {
                if (personalinfo.Annualincome > incomeLimit)
                {
                    bankInfo = Utility.BARCLAYCARD;
                }
                else
                {
                    bankInfo = Utility.VANQUIS;
                }
            }
            else
            {
                bankInfo = Utility.UNDER18;

            }
            personalinfo.BankId = bankInfo;
            personalinfo.Age = age;
            return personalinfo;
        }

        /// <summary>
        /// This method is used to Get the all applicant information to display in report screen 
        /// </summary>
        /// <returns>List of Applicant Details</returns>
        public List<ApplicantDetails> GetAllApplicantInformation()
        {
            List<ApplicantDetails> _applicantlst = new List<ApplicantDetails>();
            try
            {

               _applicantlst = _CreditCardsPreQualificationRepository.GetAllApplicantInformation();

                _logger.LogInformation($"Services Name : Creditcardsprequalificationservice , Method Name : GetAllApplicantInformation ,Pulled all Applicant from DB successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Services Name : Creditcardsprequalificationservice , Method Name : GetAllApplicantInformation Error Message :, {ex.Message }");
                throw ex;
            }
            finally
            {

            }

            return _applicantlst;
        }
    }
}
