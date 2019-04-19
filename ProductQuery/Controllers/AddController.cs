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
        private Conventional conventional;
        List<Conventional> conventionals = new List<Conventional>();
        string s = "";

        public ActionResult AddInformation()
        {
            //List<SelectListItem> listItem = new List<SelectListItem>{
            //    new SelectListItem{Text="ns",Value="ns"},
            //    new SelectListItem{Text="μs",Value="μs"},
            //    new SelectListItem{Text="ms",Value="ms"},
            //    new SelectListItem{Text="s",Value="s"}
            //};
            //ViewBag.TimeList = new SelectList(listItem, "Value", "Text", "");
            
            return View();
        }



        //添加点火装置
        [HttpPost]
        public ActionResult AddInformation(Ignition ignition)
        {
            Response.Write(s);
            for (int i=0;i< conventionals.Count;i++)
            {
                conventional = conventionals[i];
                Response.Write(conventional);
                ignition.Conventionals.Add(conventional);
            }
            db.Ignition.Add(ignition);
            db.SaveChanges();
            return View();
        }

        [HttpPost]
        public void ListAdd(Conventional conventional)
        {
            conventionals.Add(conventional);
            s = conventional.ccmc;
        }

        public ActionResult InformationModule()
        {
            return View();
        }
    }
}