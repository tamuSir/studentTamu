using Microsoft.AspNetCore.Mvc;
using studentTamu.Interface;
using studentTamu.Models;
using System.Diagnostics.CodeAnalysis;

namespace studentTamu.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser user;

        public UserController(IUser _user)
        {
            user = _user;
        }
        public IActionResult Index()
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
        #region user List
        public IActionResult UserList()
        {
            var data = user.UserList();
            return Json(data);
        }

        public IActionResult getUserById(int id)
        {
            var data = user.GetUserId(id);
            return Json(data);
        }

        public IActionResult updateUser(AccountsModel am)
        { 
            var data=user.UpdateUser(am);
            return Json(data);
        }

        public IActionResult DeleteUser(int id) 
        {
            var data=user.DeleteUser(id);
            return Json(data);
        }
        #endregion
    }
}
