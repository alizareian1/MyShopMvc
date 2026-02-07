using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TachraFac.Core.Services.Interfaces;

namespace TachraFac.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(_userService.GetUserByUserName(User.Identity.Name));
        }
    }
}
