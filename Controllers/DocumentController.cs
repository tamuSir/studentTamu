using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using studentTamu.Interface;
using studentTamu.Models;
using static System.Net.Mime.MediaTypeNames;

namespace studentTamu.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocument document;
        private readonly IUser user;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DocumentController(IDocument _document,IUser _user, IWebHostEnvironment _webHostEnvironment)
        {
            document = _document;
            user = _user;
            webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.userData = user.UserList();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Accounts");
            }
            
        }

        public string ResizeImage(SixLabors.ImageSharp.Image image, int maxWidth, int maxHeight)
        {
            if (image.Width > maxWidth || image.Height > maxHeight)
            {
                double widthRatio = (double)image.Width / maxWidth;
                double heightRatio = (double)image.Height / maxHeight;
                double ratio = Math.Max(widthRatio, heightRatio);

                int newWidth = (int)(image.Width / ratio);
                int newHeight = (int)(image.Height / ratio);

                return $"{newHeight},{newWidth}";
            }
            else
            {
                return $"{image.Height},{image.Width}";
            }
        }

        #region add document

        public IActionResult AddDocument(DocumentModel dm, IFormFile documentImg)
        {
            var uniqueU = new Guid();
            dynamic filename = "";
            if (documentImg != null && documentImg.Length > 0)
            {
                var file = documentImg;
                string dirUrl = webHostEnvironment.WebRootPath;
                string dirPath = Path.Combine(dirUrl, "image\\document");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                if (file.Length > 0)
                {

                    string filenameU = Path.GetFileName(documentImg.FileName.Trim('"'));
                    filename = uniqueU + filenameU;
                    string fullPath = Path.Combine(dirPath, filename);

                    using (var fileStream = SixLabors.ImageSharp.Image.Load(file.OpenReadStream()))
                    {
                        string newSize = ResizeImage(fileStream, 800, 800);
                        string[] aSize = newSize.Split(',');
                        fileStream.Mutate(a => a.Resize(Convert.ToInt32(aSize[1]), Convert.ToInt32(aSize[0])));
                        fileStream.Save(fullPath);
                    }

                }

                //save in database
                dm.dImage = filename;
                var data = document.InsertDocument(dm);
                return Json(data);
            }
            else
            {
                var data = document.InsertDocument(dm);
                return Json(data);
            }
        }

        #endregion

        #region list

        public IActionResult GetDocumentList()
        {
            var data = document.GetAllDocuments();
            return Json(data);
        }

        #endregion

        public IActionResult getDocumentById(int id)
        {
            var data = document.getDocumentById(id);
            return Json(data);
        }

        #region update

        public IActionResult UpdateDocument(DocumentModel dm, IFormFile documentUpdateImg,string deleteOldImage)
        {
            var uniqueU = new Guid();
            dynamic filename = "";
            if (documentUpdateImg != null && documentUpdateImg.Length > 0)
            {
                var file = documentUpdateImg;
                string dirUrl = webHostEnvironment.WebRootPath;
                string dirPath = Path.Combine(dirUrl, "image\\document");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                // Delete old image if it exists
                if (!string.IsNullOrEmpty(deleteOldImage))
                {
                    string oldImagePath = Path.Combine(dirPath, deleteOldImage);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                if (file.Length > 0)
                {

                    string filenameU = Path.GetFileName(documentUpdateImg.FileName.Trim('"'));
                    filename = uniqueU + filenameU;
                    string fullPath = Path.Combine(dirPath, filename);

                    using (var fileStream = SixLabors.ImageSharp.Image.Load(file.OpenReadStream()))
                    {
                        string newSize = ResizeImage(fileStream, 800, 800);
                        string[] aSize = newSize.Split(',');
                        fileStream.Mutate(a => a.Resize(Convert.ToInt32(aSize[1]), Convert.ToInt32(aSize[0])));
                        fileStream.Save(fullPath);
                    }

                }

                //save in database
                dm.dImage = filename;
                var data = document.UpdateDocument(dm);
                return Json(data);
            }
            else
            {
                var data = document.UpdateDocument(dm);
                return Json(data);
            }
        }

        #endregion

        public IActionResult deleteDocument(int id, string img)
        {
            string dirUrl = webHostEnvironment.WebRootPath;
            string dirPath = Path.Combine(dirUrl, "image\\document\\" + img);

            var targetPath = Path.Combine(dirPath);
            if (System.IO.File.Exists(targetPath.ToString()))
            {
                System.IO.File.Delete(targetPath);
            }
            var data = document.DeleteDocument(id);
            return Json(data);
        }

    }
}
