using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Services.Description;
using Catnado.Models;

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

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                //TODO: Email response to the party organizer
                return View("Thanks", guestResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
        }
    }
}