using CreditCardsPreQualificationBusinessLayer.BusinessLayer;
using CreditCardsPreQualificationWeb.Helper;
using CreditCardsPreQualificationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace CreditCardsPreQualificationWeb.Controllers
{
    /// <summary>
    /// This Controller is used to Check Pre-Qualification of credit cards 
    /// </summary>
    public class CheckEligibilityController : Controller
    {
        private readonly ILogger<CheckEligibilityController> _logger;

        private ICreditCardPreQualification _Creditcardprequalification;

        ///
        public CheckEligibilityController(ICreditCardPreQualification creditcardprequalification, ILogger<CheckEligibilityController> logger)
        {
            _logger = logger;
            _Creditcardprequalification = creditcardprequalification;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This Action is used to post data to DB.
        /// </summary>
        /// <param name="personalInfo">input as PersonalInfo ViewModel</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PersonalInfoViewModel personalInfo)
        {
            string viewName = string.Empty;
            if (ModelState.IsValid)
            {

                try
                {                    
                    int result = _Creditcardprequalification.CheckPreQualification(Utility.ModelMapperForPersonalInfo(personalInfo));
                    _logger.LogInformation($"Controller : CheckEligibilityController , ActionResult : Index , Information Message: Applicant checked for pre-qualification of credit cards.");
                    switch (result)
                    {
                        case 0:
                            return View(Utility.DUPLICATE, personalInfo);
                        case 1:
                            return View(Utility.UNDER18VIEW, personalInfo);
                        case 2:
                            return View(Utility.BARCLAYCARDVIEW, personalInfo);
                        case 3:
                            return View(Utility.VANQUISVIEW, personalInfo);
                        default:
                            return View();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Controller : CheckEligibilityController , ActionResult : Index Error Message :, {ex.Message }");
                    return RedirectToAction(Utility.ERROR);
                }

               
            }
            return View();
        }

        /// <summary>
        /// This IActionResult is used to display the audit records
        /// </summary>
        /// <returns>List of applicant details </returns>

        public IActionResult CheckEligibility()
        {

            try
            {
                return View(Utility.ModelMapperForPersonalInfo(_Creditcardprequalification.GetAllApplicantInformation()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Controller : CheckEligibilityController , ActionResult : CheckEligibility, Error Message : {ex.Message }");
                return RedirectToAction(Utility.ERROR);
            }

        }

    }
}
