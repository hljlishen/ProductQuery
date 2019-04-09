using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductQuery.Controllers
{
    public class AddController : Controller
    {
        ProductQueryDB db = new ProductQueryDB();
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        public ActionResult AddInformation()
        {
            List<SelectListItem> listItem = new List<SelectListItem>{
                new SelectListItem{Text="ns",Value="3"},
                new SelectListItem{Text="μs",Value="2"},
                new SelectListItem{Text="ms",Value="1"},
                new SelectListItem{Text="s",Value="0"}
            };
            ViewBag.TimeList = new SelectList(listItem, "Value", "Text", "");
            return View();
        }

        //添加点火装置
        [HttpPost]
        public ActionResult AddInformation(Ignition ignition)
        {
            //db.Ignition.Add(ignition);
            //db.SaveChanges();
            return View();
        }

        public ActionResult InformationModule()
        {
            return View();
        }
    }
}