using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using studentTamu.Interface;
using studentTamu.Models;
using System.Security.Claims;

namespace studentTamu.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUser _user;
        private readonly ICompany company;

        public AccountsController(IUser user,ICompany _company)
        {
            _user = user;
            company = _company;
        }

        public IActionResult Login()
        {
            var companyList = company.companyData();
            var roleList = company.GetAllRoleList();
            var userList = _user.UserList();

            if (companyList != null && roleList != null && roleList.Any() && userList != null && userList.Any())
            {
                if (HttpContext.Session.GetString("username") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "CompanyCreation");
            }
                      
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountsModel ac)
        {
           
                #region Login
                var result = _user.Login(ac);
                if (result != null)
                {
                    HttpContext.Session.SetInt32("intUserId", result.intUserId);
                    HttpContext.Session.SetInt32("intDeptId", result.intdeptid);
                    HttpContext.Session.SetInt32("intRoleid", result.intRoleid);
                    HttpContext.Session.SetString("username", ac.username);
                    HttpContext.Session.SetString("role", result.role);
                    //HttpContext.Session.SetString("fullName",ac.name);

                    var identity = new ClaimsIdentity(new[] { 
                        new Claim(ClaimTypes.Name,ac.username)
                    },CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.error = "There is no userName and Password";
                    return View();
                }

                #endregion
            

        }

        public async Task <ActionResult> LogOff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.SetString("intUserId","");
            HttpContext.Session.SetString("intdeptid", "");
            HttpContext.Session.SetString("username","");
            HttpContext.Session.SetString("role","");
            HttpContext.Session.Clear();

            HttpContext.Session.Remove("intUserId");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("intdeptid");
            HttpContext.Session.Remove("token");

            return Redirect("Login");
        }

        #region Register User
        public IActionResult RegisterUserIndex()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }
        }

        public JsonResult AddUser(AccountsModel am)
        {
            var data = _user.InsertUser(am);
            return Json(data);
        }
        #endregion

    }
}
