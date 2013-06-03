using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_fileUploader.Models;

namespace Mvc_fileUploader.Controllers
{
    public class UploadedController : Controller
    {
                
        [HttpGet]
        public ActionResult UploadedFiles()
        {
            var uploadedFiles = new List<UploadedFile>();
            
            var files = Directory.GetFiles(Server.MapPath("~/fileUploads/"));

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var uploadedFile = new UploadedFile();
                
                uploadedFile.Name = Path.GetFileName(file);
                uploadedFile.Size = fileInfo.Length;
                uploadedFile.Path = ("~/fileUploads/") + Path.GetFileName(file);
                
                uploadedFiles.Add(uploadedFile);
            }

            return View(uploadedFiles);
        }

    }
}
