using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_fileUploader.Models
{
    public class UploadedFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        
        public long Size { get; set; }
        
    }
}