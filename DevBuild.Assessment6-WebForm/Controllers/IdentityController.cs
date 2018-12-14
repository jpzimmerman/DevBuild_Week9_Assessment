using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Owin;
using DevBuild.Assessment6_WebForm.Models;

namespace DevBuild.Assessment6_WebForm.Controllers
{
    public class IdentityController : Controller
    {
        private UserManager<IdentityUser> _userManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();
        private IAuthenticationManager _authManager => HttpContext.GetOwinContext().Authentication;

        #region Login/Logout Actions
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid) {
                //var signInManager = new SignInManager<IdentityUser,, IAuthenticationManager>(_userManager, authManager);
                IdentityUser identityUser = new IdentityUser { UserName = loginModel.UserName };

                var user = _userManager.Find(loginModel.UserName, loginModel.Password);

                if (user != null)
                {
                    try
                    {
                        var ident = _userManager.CreateIdentity(user,
                            DefaultAuthenticationTypes.ApplicationCookie);

                        _authManager.SignIn(
                            new AuthenticationProperties { IsPersistent = false }, ident);
                        
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
                }
            }
            return View(loginModel);
        }

        [Authorize]
        public ActionResult Logout()
        {
            _authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Registration Actions

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegistrationModel registrationModel) {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser { UserName = registrationModel.UserName };

                var result = await _userManager.CreateAsync(newUser, registrationModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View();
        }
        #endregion
    }
}