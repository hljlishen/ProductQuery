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
        // GET: Add
        public ActionResult AddInformation()
        {
            return View();
        }

        //添加点火装置
        [HttpPost]
        public ActionResult AddInformation(Ignition ignition)
        {


            return View();
        }

    }
}