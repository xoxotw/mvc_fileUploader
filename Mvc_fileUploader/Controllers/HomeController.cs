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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpPost]
        public ActionResult FileUpload()
        {
            var fileToUpload = Request.Files[0];

            if (fileToUpload != null && fileToUpload.ContentLength > 0)
            {
                string fileName = Path.GetFileName(fileToUpload.FileName);
                string directory = Server.MapPath("~/fileUploads/");

                if (!Directory.Exists( directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string path = Path.Combine(directory, fileName);
                fileToUpload.SaveAs(path);
            }

            return RedirectToAction("Index");
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
