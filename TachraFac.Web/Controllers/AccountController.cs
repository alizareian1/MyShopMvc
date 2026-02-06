using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TachraFac.Core.Convertors;
using TachraFac.Core.DTOs;
using TachraFac.Core.Genrator;
using TachraFac.Core.Security;
using TachraFac.Core.senders;
using TachraFac.Core.Services.Interfaces;
using TachraFac.Datalayer.Entities.User;

namespace TachraFac.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IViewRenderService _viewRenderService;
        public AccountController(IUserService userService, IViewRenderService viewRenderService)
        {
            _userService = userService;
            _viewRenderService = viewRenderService;
        }


        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (_userService.IsUserNameExist(register.UserName))
            {
                ModelState.AddModelError("UserName","نام کاربری معتبر نمی باشد");
                return View(register);
            }
            if (_userService.IsEmailExist(FixText.FixEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
                return View(register);
            }

            // Register User
            TachraFac.Datalayer.Entities.User.User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUnicCode(),
                Email = FixText.FixEmail(register.Email),
                IsActive =false,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
                UserAvatar = "UserAvatarDefault.png",
                UserName = register.UserName,
            };
            _userService.AddUser(user);
            // ToDo Add Contact

            #region Send Activation Email
            string body = _viewRenderService.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email,"فعالسازی",body);
            #endregion
            return View("SuccessRegister",user);
        }

        #endregion

        #region Login
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    // Login User
                    var cliams = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(cliams,CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RemmemerMe
                    };
                    HttpContext.SignInAsync(principal, properties);
                    ViewBag.IsSuccess = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("UserName", "حساب کاربری شما فعال نمی باشد");
                }
            }
            ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
            return View(login);
        }
        #endregion

        #region Active Account
        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userService.ActiceAccount(id);
            return View();

        }
        #endregion

        #region Logout
        [Route("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }
        #endregion

        #region ForgotPassword
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }
            TachraFac.Datalayer.Entities.User.User user = _userService.GetUserByUserName(forgot.UserName);
            if (user == null)
            {
                ModelState.AddModelError("Username", "کاربری یافت نشد");
                return View(forgot);
            }
            string bodyEmail = _viewRenderService.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.Email, "بازیابی حساب کاربری", bodyEmail);
            ViewBag.IsSuccess = true;
            return View();
        }
        #endregion

        #region ResetPassword
        public IActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel() 
            {
                ActiveCode = id 
            });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPassword);
            }
            TachraFac.Datalayer.Entities.User.User user = _userService.GetUserByActiveCode(resetPassword.ActiveCode);
            if (user == null)
            {
                return NotFound();
            }
            string hashPassword = PasswordHelper.EncodePasswordMd5(resetPassword.Password);
            resetPassword.Password = hashPassword;
            _userService.UpdateUser(user);
            return Redirect("/Login");
        }

        #endregion
    }
}
