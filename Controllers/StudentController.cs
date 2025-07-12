using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using studentTamu.Interface;

namespace studentTamu.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudent student;

        public StudentController(IStudent _student)
        {
            student = _student;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.intRoleid = HttpContext.Session.GetInt32("intRoleid").ToString();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }
        }
        public IActionResult StudentPersonalDetailListData()
        {
            var data = student.StudentPersonalDetailList();
            return Json(data);
        }
        public IActionResult getStudentPersonalId(int studentId)
        {
            var data = student.getstudentPersonalDetail(studentId);
            return Json(data);
        }
        public IActionResult getEnglishListId(int studentId)
        {
            var data = student.evidenceOfEnglishList(studentId);
            return Json(data);
        }
        public IActionResult geEducationListId(int studentId)
        {
            var data = student.studentEducationList(studentId);
            return Json(data);
        }
        public IActionResult getExperienceListId(int id)
        {
            var data = student.studentExperienceLetterList(id);
            return Json(data);
        }
        public IActionResult deleteStudent(int studentId)
        {
            var data = student.DeleteStudent(studentId);
            return Json(data);
        }

    }
}
