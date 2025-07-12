using Microsoft.AspNetCore.Mvc;
using studentTamu.Interface;
using studentTamu.Models;

namespace studentTamu.Controllers
{
    public class StudentFormController : Controller
    {
        private readonly IStudentForm studentForm;

        public StudentFormController(IStudentForm _studentForm)
        {
            studentForm = _studentForm;
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

        #region Insert personal Detail
        public JsonResult AddPersonalDetailStudent(StudentFormModel sfm)
        {
            var data = studentForm.InsertStudentFormPersonalDetail(sfm);
            return Json(data);
        }
        #endregion

        #region Insert student education
        public JsonResult AddStudentEducation(StudentFormModel sfm)
        {
            dynamic data = string.Empty;

            foreach (var item in sfm.eduArrData)
            {
                sfm.pdID = item.pdID;
                sfm.degreeName = item.degreeName;
                sfm.institutionName = item.institutionName;
                sfm.academicGrading = item.academicGrading;
                sfm.marks = item.marks;
                sfm.dateOfCompletion = item.dateOfCompletion;

                data = studentForm.InsertStudentFormEducation(sfm);
            }
            return Json(data);
        }
        #endregion

        #region Insert student experience
        public JsonResult AddStudentExperience(StudentFormModel sfm)
        {
            dynamic data=string.Empty;

            foreach (var item in sfm.expArrData)
            {
                sfm.pdID = item.pdID;
                sfm.orgName = item.orgName;
                sfm.position = item.position;
                sfm.fromDate = item.fromDate;
                sfm.toDate = item.toDate;
                
                data = studentForm.InsertStudentFormExperience(sfm);
            }
            return Json(data);
        }
        #endregion

        #region Insert evidence of english
        public JsonResult AddStudentEnglishEvidence(StudentFormModel sfm)
        {
            var data = studentForm.InsertStudentFormEnglishEvidence(sfm);
            return Json(data);
        }
        #endregion
    }
}
