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
            //ViewBag.Message = "Choose a file to upload !";
            return View("starFileUpload");
        }

        [HttpGet]
        public ActionResult starFileUpload()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult FileUpload()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase fileToUpload)
        {
            
            if (ModelState.IsValid)
            {
                if (fileToUpload != null && fileToUpload.ContentLength > (1024 * 1024 * 5))  // 2GB limit
                {
                    ModelState.AddModelError("fileToUpload", "Your file is to large. Maximum size allowed is 2GB !");
                }
                else if (fileToUpload == null)
                {
                    ModelState.AddModelError("fileToUpload", "You didn't pick any file !");
                }

                else
                {
                    string fileName = Path.GetFileName(fileToUpload.FileName);
                    string directory = Server.MapPath("~/Uploaded/fileUploads/");

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    // Check if file already exists or not.
                    string pathToCheck = directory + fileName;
                    string tempFileName = "";
                    if (System.IO.File.Exists(pathToCheck))
                    {
                        int counter = 2;
                        while (System.IO.File.Exists(pathToCheck))
                        {
                            tempFileName = counter.ToString() + fileName;
                            pathToCheck = directory + tempFileName;
                            counter++;
                        }

                        fileName = tempFileName;
                        //directory += fileName;
                        
                    }
                    
                    string path = Path.Combine(directory, fileName);
                    fileToUpload.SaveAs(path);
                    ModelState.Clear();
                    
                    return View("FileUpload");
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
