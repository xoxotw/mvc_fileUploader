using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_fileUploader.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult UploadDocument()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult FileUpload()
        {
            var fileToUpload = Request.Files[0];

            if (fileToUpload != null && fileToUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(fileToUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/fileUploads/"), fileName);
                fileToUpload.SaveAs(path);
            }

            return RedirectToAction("UploadDocument");
        }

    }
}
