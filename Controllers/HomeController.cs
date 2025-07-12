using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using studentTamu.Interface;
using studentTamu.Models;

namespace studentTamu.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.roleId = HttpContext.Session.GetInt32("intRoleid");
                ViewBag.username = HttpContext.Session.GetString("username").ToString();
                ViewBag.role = HttpContext.Session.GetString("role").ToString();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }


        }

    }
}
