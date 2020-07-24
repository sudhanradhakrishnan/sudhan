using CreditCardPreQualificationBusinessModels.Models;
using CreditCardsPreQualificationBusinessLayer.BusinessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardPreQualificationTestProject
{
    public class CreditCardPreQualificationCheck_BLTestMethso
    {

        ICreditCardPreQualification _creditCardPreQualification;
        ILogger<CreditCardPreQualification> _loggercreditCardPreQualification;


        [SetUp]
        public void Setup()
        {
            var creditCardPreQualificationlogger = LoggerFactory.Create(builder => builder.AddConsole());
            _loggercreditCardPreQualification = creditCardPreQualificationlogger.CreateLogger<CreditCardPreQualification>();

            //Dummy Config
            var myConfiguration = new Dictionary<string, string>
                {
                    {"DBConnection:Connection:PreQualificationconn", "Server=(localdb)\\mssqllocaldb;Database=HDdecisions_DB;Trusted_Connection=True;MultipleActiveResultSets=true"}
                };
            var configuration = new ConfigurationBuilder()
                 .AddInMemoryCollection(myConfiguration)
                .Build();
            _creditCardPreQualification = new CreditCardPreQualification(configuration, _loggercreditCardPreQualification);
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
                DateofBirth =  new DateTime(2016, 4, 02),
                Annualincome = 45000
               
            };
            // Act 
            fakePersonalInfo = _creditCardPreQualification.CalculateAgeAndIncome(fakePersonalInfo);


            //Assert 
            Assert.AreEqual(-1,12 );
        }
    }
}
