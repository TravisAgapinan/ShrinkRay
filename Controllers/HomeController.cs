using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using URLShortener.Models.Domain;
using URLShortener.Services.Interfaces;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {

        [Dependency]
        public IURLService _URLService { get; set; }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Ray(string slug)
        {
            //pass slug into service and get domain model back
           
            URL LongForm = _URLService.GetBySlug(slug);
            //ifstatement if null throw error
            if (LongForm == null)
            {
                return View("URLError"); 
            }
            else
            {
                
              return RedirectToAction("/"+LongForm.Url);

            }
        }
        
        

    }
}
