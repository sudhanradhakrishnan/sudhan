using CreditCardsPreQualificationBusinessLayer.BusinessLayer;
using CreditCardsPreQualificationWeb.Controllers;
using CreditCardsPreQualificationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardPreQualificationTestProject
{
    public class CreditCardsPreQualificationController
    {
        ICreditCardPreQualification _creditCardsPreQualification;
        ILogger<CreditCardPreQualification> _loggerCreditcardsprequalification;

        CheckEligibilityController _controller;

        ILogger<CheckEligibilityController> _loggerCheckEligibilityController;



        [SetUp]
        public void Setup()
        {
            var creditCardPreQualification = LoggerFactory.Create(builder => builder.AddConsole());
            _loggerCreditcardsprequalification = creditCardPreQualification.CreateLogger<CreditCardPreQualification>();

            //Dummy Config
            var creditCardPreQualificationConfiguration = new Dictionary<string, string>
                {
                    {"DBConnection:Connection:PreQualificationconn", "Server=(localdb)\\mssqllocaldb;Database=HDdecisions_DB;Trusted_Connection=True;MultipleActiveResultSets=true"},
                     {"Config:Keyvalues:Age", "18"},
                      {"Config:Keyvalues:Annualincome", "30000"}

                };
            var configuration = new ConfigurationBuilder()
                 .AddInMemoryCollection(creditCardPreQualificationConfiguration)
                .Build();

            _creditCardsPreQualification = new CreditCardPreQualification(configuration, _loggerCreditcardsprequalification);

            var CheckEligibilityController = LoggerFactory.Create(builder => builder.AddConsole());
            _loggerCheckEligibilityController = CheckEligibilityController.CreateLogger<CheckEligibilityController>();

            _controller = new CheckEligibilityController(_creditCardsPreQualification, _loggerCheckEligibilityController);
        }


        /// <summary>
        /// This test Method will pass only first time.
        /// </summary>
        [Test]
        public void CheckEligibilityController_TestMethod_Barclaycard()
        {
            // Arrange   
            string name = MockRandomName();
            PersonalInfoViewModel fakePersonalInfoViewModel = new PersonalInfoViewModel()
            {
                FirstName = name,
                LastName = "Fox",
                DateofBirth = DateTime.Now.AddYears(-50),
                Annualincome = 48000
            };

            // Act
            var result = (ViewResult)_controller.Index(fakePersonalInfoViewModel);

            // Assert

            var resultmodel = (PersonalInfoViewModel)result.Model;
            Assert.AreEqual("BarclaycardView", result.ViewName);
            Assert.AreEqual(name, resultmodel.FirstName);
        }


        [Test]
        public void CheckEligibilityController_TestMethod_DuplicateView()
        {
            // Arrange           
            PersonalInfoViewModel fakePersonalInfoViewModel = new PersonalInfoViewModel()
            {
                FirstName = "Jamse",
                LastName = "Fox",
                DateofBirth = DateTime.Now.AddYears(-50),
                Annualincome = 45000
            };

            // Act
            var result = (ViewResult)_controller.Index(fakePersonalInfoViewModel);

            // Assert

            var resultmodel = (PersonalInfoViewModel)result.Model;
            Assert.AreEqual("DuplicateView", result.ViewName); //
        }

        [Test]
        public void CheckEligibilityController_TestMethod_Under18()
        {
            // Arrange   
            string name = MockRandomName();
            PersonalInfoViewModel fakePersonalInfoViewModel = new PersonalInfoViewModel()
            {
                FirstName = name,
                LastName = "Fox",
                DateofBirth = DateTime.Now.AddYears(-10),
                Annualincome = 45000
            };

            // Act
            var result = (ViewResult)_controller.Index(fakePersonalInfoViewModel);

            // Assert

            var resultmodel = (PersonalInfoViewModel)result.Model;
            Assert.AreEqual("Under18", result.ViewName); //
        }


        [Test]
        public void CheckEligibilityController_TestMethod_VanquisView()
        {
            // Arrange  
            string name = MockRandomName();
            PersonalInfoViewModel fakePersonalInfoViewModel = new PersonalInfoViewModel()
            {
                FirstName = name,
                LastName = "Fox",
                DateofBirth = DateTime.Now.AddYears(-50),
                Annualincome = 25000
            };

            // Act
            var result = (ViewResult)_controller.Index(fakePersonalInfoViewModel);

            // Assert

            var resultmodel = (PersonalInfoViewModel)result.Model;
            Assert.AreEqual("VanquisView", result.ViewName); //
        }


        private string MockRandomName()
        {
            Random random = new Random();
            int length = 3;
            var rString = "Steve";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            return rString;
        }


    }
}
