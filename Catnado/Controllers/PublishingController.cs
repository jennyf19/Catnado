using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string folderPath = Server.MapPath(("~/Files/"));

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));

                    file.SaveAs(path);

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR: " + ex.Message;
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

    }
}