using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnyCore.Services.ApplicationUsers;
using AnyCore.Web.Models.ApplicationUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;

namespace AnyCore.Web.Controllers
{
    public class AccountController : Controller
    {
      
        public readonly IApplicationUserService _applicationUserService;
        private readonly ILogger _logger;


        public AccountController(

            IApplicationUserService applicationUserService,
            ILoggerFactory loggerFactory)
        {

            this._applicationUserService = applicationUserService;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }
        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            //_applicationUserService.InsertApplicationUser(new Core.Domain.ApplicationUser.ApplicationUser { DisplayName = "龙山", Email = "admin@163.com", Password = "123456" });
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                if (model.Email != null)
                {
                    model.Email = model.Email.Trim();
                }
                //var loginResult = _applicationUserService.GetApplicationUserByEmail(model.Email, model.Password);
                var applicationUser = _applicationUserService.GetApplicationUserByEmail(model.Email);

                if (applicationUser == null)
                    return null;
                //check whether a customer is locked out
              
                if (!string.Equals(applicationUser.Password, model.Password))
                {
                    //wrong password
                    applicationUser.FailedLoginAttempts++;
                    //if (_customerSettings.FailedPasswordAllowedAttempts > 0 &&
                    //    applicationUser.FailedLoginAttempts >= _customerSettings.FailedPasswordAllowedAttempts)
                    //{
                    //    //lock out
                    //    applicationUser.CannotLoginUntilDateUtc = DateTime.UtcNow.AddMinutes(_customerSettings.FailedPasswordLockoutMinutes);
                    //    //reset the counter
                    //    applicationUser.FailedLoginAttempts = 0;
                    //}
                    _applicationUserService.UpdateApplicationUser(applicationUser);

                    return View(model);
                }

                //update login details
                applicationUser.FailedLoginAttempts = 0;
                applicationUser.CannotLoginUntilDateUtc = null;
                //applicationUser.RequireReLogin = false;
                applicationUser.LastLoginDateUtc = DateTime.UtcNow;
                _applicationUserService.UpdateApplicationUser(applicationUser);

                return View(model);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #region Helpers

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        #endregion
    }
}