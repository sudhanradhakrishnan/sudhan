using CreditCardPreQualificationBusinessModels.Models;
using CreditCardsPreQualificationBusinessLayer.BusinessLayer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CreditCardPreQualificationTestProject
{
    public class CreditCardsPreQualificationWithMock
    {


        private Mock<ICreditCardPreQualification> _mockCreditcardsprequalification;


        [SetUp]
        public void Setup()
        {
                    
            _mockCreditcardsprequalification = new Mock<ICreditCardPreQualification>();
        }

        [Test]
        public void GetAllApplicantInformation_TestMethos_WithMock()
        {
            // Arrange 

            List<ApplicantDetails> lst = MockApplicantDetails();


            _mockCreditcardsprequalification.Setup(a => a.GetAllApplicantInformation()).Returns(lst);

            // Act 

            var creditcardsprequalification = _mockCreditcardsprequalification.Object.GetAllApplicantInformation();

         
            //Assert 
            Assert.AreEqual(1, creditcardsprequalification.Count);
        }


        [Test]
        public void GetAllApplicantInformation_TestMethos()
        {
            // Arrange 
            List<ApplicantDetails> lst = MockApplicantDetails();
            // Act 
            Mock<ICreditCardPreQualification> mockRepo = new Mock<ICreditCardPreQualification>();
            mockRepo.Setup(x => x.GetAllApplicantInformation()).Returns(lst);
            //Assert 
            Assert.AreEqual(1, mockRepo.Object.GetAllApplicantInformation().Count);
        }


        [Test]
        public void InsertPersondetails_TestMethod()
        {
            // Arrange 
            PersonalInfo fakePersonalInfo =  MockPersonalInfoObject();
            // Act 
            Mock<ICreditCardPreQualification> mockRepo = new Mock<ICreditCardPreQualification>();
            mockRepo.Setup(x => x.CheckPreQualification(fakePersonalInfo)).Returns(5);

            int returnvalue = mockRepo.Object.CheckPreQualification(fakePersonalInfo);
            //Assert 
            Assert.AreEqual(5, returnvalue);
        }

        [Test]
        public void CalculateAgeandIncome_TestMethod()
        {
            // Arrange 
            PersonalInfo fakePersonalInfo = MockPersonalInfoObject();

            PersonalInfo fakePersonalInfoMoke = MockPersonalInfoObject();
            fakePersonalInfoMoke.Age = 50;
            fakePersonalInfoMoke.BankId = 3;

            // Act 
            Mock<ICreditCardPreQualification> mockRepo = new Mock<ICreditCardPreQualification>();
            mockRepo.Setup(x => x.CalculateAgeAndIncome(fakePersonalInfo)).Returns(fakePersonalInfoMoke);

            PersonalInfo mokPersonalInfo = mockRepo.Object.CalculateAgeAndIncome(fakePersonalInfo);
            //Assert 
            Assert.AreEqual(50, mokPersonalInfo.Age);
        }

        /// <summary>
        /// Mock data for ApplicantDetails
        /// </summary>
        /// <returns></returns>

        private List<ApplicantDetails> MockApplicantDetails()
        {
            List<ApplicantDetails> lst = new List<ApplicantDetails>();
            ApplicantDetails _appdetails = new ApplicantDetails()
            {
                Age = 50,
                AnnualIncome = 35000,
                AttemptDate = DateTime.Now,
                BankDetails = "BARCLAYCARD",
                FullName = "Jamse Fox"

            };
            lst.Add(_appdetails);

            return lst;
        }

        /// <summary>
        /// Mock data for PersonalInfo
        /// </summary>
        /// <returns></returns>
        private PersonalInfo MockPersonalInfoObject()
        {
            PersonalInfo fakePersonalInfo = new PersonalInfo()
            {
                FirstName = "Jamse",
                LastName = "Fox",
                DateofBirth = DateTime.Now.AddYears(-50),
                Annualincome = 45000
            };

            return fakePersonalInfo;
        }
    }
}