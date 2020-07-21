using CreditCardPreQualificationBusinessModels.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CreditCardsPreQualificationServicesLayer.Repository
{
    /// <summary>
    /// This Class is used to implement Database layer
    ///Method for Insert PersonalInfo  Details in DB
    ///Get the all applicant information to display in report screen
    /// </summary>
    public class CreditCardsPreQualificationRepository : ICreditCardsPreQualificationRepository
    {
        private readonly ILogger<CreditCardsPreQualificationRepository> _logger;
        private string dbConnection;
        //To Handle connection related activities

       

        public CreditCardsPreQualificationRepository(IConfiguration configuration, ILogger<CreditCardsPreQualificationRepository> logger)
        {
            _logger = logger;
            dbConnection = configuration.GetValue<string>("DBConnection:Connection:PreQualificationconn");
        }

        /// <summary>
        /// This Method is used to insert details in BD for Audit report
        /// </summary>
        /// <param name="personalInfo">object of PersonalInfo</param>
        /// <returns>return the row number inserted</returns>
        public int CheckPreQualification(PersonalInfo personalInfo)
        {
            int identity = 0;
            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                con.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("InsertPersonalInfo", con))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;//@FirstName,@LastName,@DOB,@AnnualIncome
                        sqlCommand.Parameters.AddWithValue("@FirstName", personalInfo.FirstName);
                        sqlCommand.Parameters.AddWithValue("@LastName", personalInfo.LastName);
                        sqlCommand.Parameters.AddWithValue("@DOB", personalInfo.DateofBirth);
                        sqlCommand.Parameters.AddWithValue("@Age", personalInfo.Age);
                        sqlCommand.Parameters.AddWithValue("@BankId", personalInfo.BankId);
                        sqlCommand.Parameters.AddWithValue("@AnnualIncome", personalInfo.Annualincome);
                        sqlCommand.Parameters.Add("@Identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sqlCommand.ExecuteNonQuery();
                        identity = Convert.ToInt32(sqlCommand.Parameters["@Identity"].Value);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Services Name : CreditCardsPreQualificationRepository , Method Name : AddPersonalInfo Error Message :, {ex.Message }");
                    throw ex;
                }
            }

            return identity;
        }

        /// <summary>
        /// This method is used to Add the Bank details for each applicant.
        /// </summary>
        /// <param name="PersonalInfoId">PersonalInfoId id which is received from CheckPreQualification method </param>
        /// <param name="BankDetails">Bank id details</param>
        /// <returns></returns>
        public void AddReportInfo(int PersonalInfoId, int BankDetails)
        {

            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                con.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("InsertAuditReportDetails", con))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@PersonalInfoId", PersonalInfoId);
                        sqlCommand.Parameters.AddWithValue("@BankDetails", BankDetails);
                        sqlCommand.Parameters.Add("@Identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Services Name : CreditCardsPreQualificationRepository , Method Name : AddReportInfo Error Message :, {ex.Message }");
                    throw ex;
                }
            }
        }


        /// <summary>
        /// This method is used to Get the Audit report 
        /// <summary>
        /// <returns>List of ApplicantDetails </returns>
        public List<ApplicantDetails> GetAllApplicantInformation()
        {
            List<ApplicantDetails> lstApplicationDetails = new List<ApplicantDetails>();

            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                con.Open();
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("GetAllApplicantInformation", con))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {

                            ApplicantDetails _ApplicantDetail = new ApplicantDetails();
                            _ApplicantDetail.FullName = reader["FullName"].ToString();
                            _ApplicantDetail.BankDetails = reader["BankDetails"].ToString();
                            _ApplicantDetail.Age = int.Parse(reader["Age"].ToString());
                            _ApplicantDetail.AnnualIncome = float.Parse(reader["AnnualIncome"].ToString());
                            _ApplicantDetail.AttemptDate = DateTime.Parse(reader["AttemptDate"].ToString());
                            lstApplicationDetails.Add(_ApplicantDetail);

                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Services Name : CreditCardsPreQualificationRepository , Method Name : GetAllApplicantInformation Error Message :, {ex.Message }");
                    throw ex;
                }
            }

           
            return lstApplicationDetails;
        }
    }
}


