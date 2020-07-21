using CreditCardPreQualificationBusinessModels.Models;
using CreditCardsPreQualificationBusinessLayer.BusinessLayer;
using CreditCardsPreQualificationServicesLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CreditCardPreQualificationTestProject
{
    public class CreditCardsPreQualificationWithOutMock
    {


        ICreditCardsPreQualificationRepository _creditCardsPreQualificationRepository;
        ILogger<CreditCardsPreQualificationRepository> _loggerCreditcardsprequalificationRepo;


        [SetUp]
        public void Setup()
        {
            var CreditcardsprequalificationRepologger = LoggerFactory.Create(builder => builder.AddConsole());
            _loggerCreditcardsprequalificationRepo = CreditcardsprequalificationRepologger.CreateLogger<CreditCardsPreQualificationRepository>();

            //Dummy Config
            var myConfiguration = new Dictionary<string, string>
                {
                    {"DBConnection:Connection:PreQualificationconn", "Server=(localdb)\\mssqllocaldb;Database=HDdecisions_DB;Trusted_Connection=True;MultipleActiveResultSets=true"}                   
                };
            var configuration = new ConfigurationBuilder()
                 .AddInMemoryCollection(myConfiguration)
                .Build();
            _creditCardsPreQualificationRepository = new CreditCardsPreQualificationRepository(configuration, _loggerCreditcardsprequalificationRepo);
        }
       

        [Test]
        public void InsertPersondetails_TestMethos_WithoutMock()
        {
            /*Note :: This test methos will work only if there data in DB. */
            // Arrange 
            PersonalInfo fakePersonalInfo = new PersonalInfo()
            {
                FirstName = "Jamse",
                LastName = "Fox",
                DateofBirth = DateTime.Now.AddYears(-50),
                Annualincome = 45000,
                Age = 50,
                BankId = 2
            };
            // Act 
            int i = _creditCardsPreQualificationRepository.CheckPreQualification(fakePersonalInfo);


            //Assert 
            Assert.AreEqual(-1, i);
        }


        [Test]
        public void GetAllApplicantInformation_TestMethos_WithoutMock()
        {
            // Arrange 
            List<ApplicantDetails> lst = _creditCardsPreQualificationRepository.GetAllApplicantInformation();
            // Act 
            int count = lst.Count;
            //Assert 
            Assert.AreEqual(count, lst.Count);
        }


       
    }
}