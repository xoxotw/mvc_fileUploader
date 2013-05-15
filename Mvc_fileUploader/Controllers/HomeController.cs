using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_fileUploader.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Choose a file to upload!";
            return View("FileUpload");
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase fileToUpload)
        {
            
            if (ModelState.IsValid)
            {
                if (fileToUpload != null && fileToUpload.ContentLength > (1024 * 1024 * 1))  // 1MB limit
                {
                    ModelState.AddModelError("fileToUpload", "Your file is to large. Maximum size allowed is 1MB !");
                }

                else
                {
                    string fileName = Path.GetFileName(fileToUpload.FileName);
                    string directory = Server.MapPath("~/fileUploads/");

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    string path = Path.Combine(directory, fileName);
                    fileToUpload.SaveAs(path);

                    ModelState.Clear();
                    ViewBag.Message = "File uploaded successfully!";
                }
            }

                return View("FileUpload");
            
        }
        
        
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
