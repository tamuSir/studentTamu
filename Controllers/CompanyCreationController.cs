using Microsoft.AspNetCore.Mvc;
using studentTamu.Interface;
using studentTamu.Models;
using System.Collections.Generic;

namespace studentTamu.Controllers
{
    public class CompanyCreationController : Controller
    {
        private readonly ICompany company;

        public CompanyCreationController(ICompany _company)
        {
            company = _company;
        }
        public IActionResult Index()
        {
            ViewBag.companyCheck = company.checkCompany();

            var userCheckAll = company.checkUser();

            if (userCheckAll != null)
            {
                var userCheckAllData = company.checkUser().intRoleid;
                ViewBag.userCheck = userCheckAllData;

            }
            else
            {
                ViewBag.userCheck = 0;
            }
            return View();
        }

        #region add company

        public IActionResult AddCompany(CompanyModel cm)
        { 
            var data =company.InsertCompany(cm);
            return Json(data);
        }

        #endregion

        #region Role 

        public IActionResult CheckedRole()
        { 
            var data= company.checkRole();
            return Json(data);
        }

        public IActionResult AddRole(RoleModel rm)
        {
            dynamic data = string.Empty;

            foreach (var item in rm.roleArrayData)
            {
                rm.intRoleId = item.intRoleId;
                rm.roleName = item.roleName;

                data = company.InsertRole(rm);
            }
            return Json(data);
        }

        public IActionResult deleteRoleData()
        {
            var data = company.deleteRoleAll();
            return Json(data);
        }

        #endregion

    }
}
