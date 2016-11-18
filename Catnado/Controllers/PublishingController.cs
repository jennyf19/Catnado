using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Services.Description;

namespace Catnado.Controllers
{
    public class PublishingController : Controller
    {
        // GET: Publishing
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFile files)
        {
            foreach (string file in Request.Files)
            {

                HttpPostedFileBase hpf = Request.Files[file];
                if (hpf.ContentLength == 0)
                {
                    continue;
                }
                string fileName = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(hpf.FileName));
                hpf.SaveAs(fileName);
               }
            
            return View();
        }

        public FileContentResult File()
        {
            var fullPathToFile = @"/App_Data/uploads";
            var mimeType = "application/pdf";
            var fileContents = System.IO.File.ReadAllBytes(fullPathToFile);

            return new FileContentResult(fileContents, mimeType);
        }
    }
}