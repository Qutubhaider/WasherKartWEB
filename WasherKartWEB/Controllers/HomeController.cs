using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WasherKartBAL.Repository.IRepository;
using WasherKartBAL.User.Models;
using WasherKartUtility.Utilities;
using WasherKartWEB.Models;
using static WasherKartUtility.Utilities.CommonConstant;

namespace WasherKartWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork moUnitOfWork;
        public HomeController(IUnitOfWork foUnitOfWork)
        {
            moUnitOfWork = foUnitOfWork;
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [Route("partner")]
        public IActionResult Partner()
        {
            return View("~/Views/Home/Partner.cshtml");
        }

        [Route("about-us")]
        public IActionResult About()
        {
            return View("~/Views/Home/About.cshtml");
        }

        [Route("contact-us")]
        public IActionResult ContactUs()
        {
            return View("~/Views/Home/Contact.cshtml");
        }

        public IActionResult Login()
        {            
            return View("~/Views/Home/Login.cshtml");
        }

        [Route("sign-up")]
        public IActionResult SignUp()
        {
            return View("~/Views/Home/SignUp.cshtml");
        }

        [Route("privacy-policy")]
        public IActionResult Privacy()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }

        [Route("our-mission")]
        public IActionResult OurMission()
        {
            return View("~/Views/Home/OurMission.cshtml");
        }

        [Route("our-vision")]
        public IActionResult OurVision()
        {
            return View("~/Views/Home/OurVision.cshtml");
        }

        [Route("terms-and-conditions-for-customer")]
        public IActionResult TermsCustomer()
        {
            return View("~/Views/Home/TermsCustomer.cshtml");
        }

        [Route("terms-and-conditions-for-driver")]
        public IActionResult TermsDriver()
        {
            return View("~/Views/Home/TermsDriver.cshtml");
        }

        [Route("terms-and-conditions-for-shop")]
        public IActionResult TermsShop()
        {
            return View("~/Views/Home/TermsShop.cshtml");
        }

        [Route("support")]
        public IActionResult Support()
        {
            return View("~/Views/Home/Support.cshtml");
        }

        [Route("refund")]
        public IActionResult Refund()
        {
            return View("~/Views/Home/Refund.cshtml");
        }

        [Route("referral")]
        public IActionResult Referral()
        {
            return View("~/Views/Home/Referral.cshtml");
        }

        [Route("promotional-offer-and-coupon")]
        public IActionResult Promotional()
        {
            return View("~/Views/Home/Promotional.cshtml");
        }

        [Route("feature-customer")]
        public IActionResult FeatureCustomer()
        {
            return View("~/Views/Home/FeatureCustomer.cshtml");
        }

        [Route("feature-shop")]
        public IActionResult FeatureShop()
        {
            return View("~/Views/Home/FeatureShop.cshtml");
        }

        [Route("feature-referral")]
        public IActionResult FeatureReferral()
        {
            return View("~/Views/Home/FeatureReferral.cshtml");
        }

        [Route("feature-driver")]
        public IActionResult FeatureDriver()
        {
            return View("~/Views/Home/FeatureDriver.cshtml");
        }

        [Route("opportunities-for-investor")]
        public IActionResult Investor()
        {
            return View("~/Views/Home/Investor.cshtml");
        }

        [Route("coming-soon")]
        public IActionResult ComingSoon()
        {
            return View("~/Views/Home/ComingSoon.html");
        }

        public IActionResult AuthenticateUser(LoginVM foLoginVM)
        {
            try
            {
                UserEmailResult LoginResult = moUnitOfWork.UserRepository.GetUserByEmail(foLoginVM.stEmail);
                if (LoginResult != null)
                {
                    if (foLoginVM.stPassword == LoginResult.stPassword)
                    {
                        if (LoginResult.inStatus == (int)CommonFunctions.UserStatus.InActive)
                        {
                            TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                            TempData["Message"] = string.Format(AlertMessage.UserInactive);
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            var claims = new List<Claim>();
                            claims.Add(new Claim(SessionConstant.stEmail, LoginResult.stEmail));
                            claims.Add(new Claim(SessionConstant.Id, LoginResult.inUserId.ToString()));
                            claims.Add(new Claim(SessionConstant.stUserName, LoginResult.stUsername));
                            claims.Add(new Claim(SessionConstant.unUserId, LoginResult.unUserId.ToString()));
                            claims.Add(new Claim(SessionConstant.RoleId, LoginResult.inRole.ToString()));
                            claims.Add(new Claim(SessionConstant.stName, LoginResult.stName.ToString()));
                            claims.Add(new Claim(SessionConstant.Balance, LoginResult.inBalance.ToString()));
                            ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Login");
                            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24) });
                            if (LoginResult.inRole == (int)CommonConstant.UserType.User || LoginResult.inRole == (int)CommonConstant.UserType.Distributor || LoginResult.inRole == (int)CommonConstant.UserType.Retailer)
                            {
                                TempData["ResultCode"] = CommonFunctions.ActionResponse.SuccessLogin;
                                TempData["Message"] = string.Format("Successfully Login!");
                                return RedirectToAction("Index", "Users", new { area = "Users" });
                            }
                            else if (LoginResult.inRole == (int)CommonConstant.UserType.Admin)
                            {
                                TempData["ResultCode"] = CommonFunctions.ActionResponse.SuccessLogin;
                                TempData["Message"] = string.Format("Successfully Login!");
                                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                            }
                            else
                            {
                                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                                TempData["Message"] = string.Format(AlertMessage.CredentialMisMatch);
                                return RedirectToAction("Login");
                            }
                        }
                    }
                    else
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                        TempData["Message"] = string.Format(AlertMessage.CredentialMisMatch);
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                    TempData["Message"] = string.Format(AlertMessage.UserNotFound);
                    return RedirectToAction("Login");
                }

            }
            catch (Exception ex)
            {
                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                TempData["Message"] = string.Format(AlertMessage.OperationalError, "login");
                return RedirectToAction("Login");
            }
        }


        public IActionResult SaveUser(UserProfile foUserProfile)
        {
            try
            {
                int liSuccess = 0;
                int liUserId = 1;
                if (foUserProfile != null)
                {
                    moUnitOfWork.UserRepository.InserUserProfile(foUserProfile, liUserId, out liSuccess);

                    if (liSuccess == (int)CommonFunctions.ActionResponse.Add)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Add;
                        TempData["Message"] = string.Format(AlertMessage.RecordCreated, "Account");
                        return RedirectToAction("Login");
                    }
                    else if (liSuccess == (int)CommonFunctions.ActionResponse.Exists)
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Exists;
                        TempData["Message"] = string.Format(AlertMessage.MobileExist);
                        return RedirectToAction("SignUp");
                    }
                    else
                    {
                        TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                        TempData["Message"] = string.Format(AlertMessage.OperationalError, "saving user");
                        return RedirectToAction("SignUp");
                    }
                }
                return RedirectToAction("SignUp");
            }
            catch (Exception ex)
            {
                TempData["ResultCode"] = CommonFunctions.ActionResponse.Error;
                TempData["Message"] = string.Format(AlertMessage.OperationalError, "login");
                return RedirectToAction("SignUp");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
