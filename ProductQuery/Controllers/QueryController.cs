using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductQuery.Controllers
{
    public class QueryController : Controller
    {
        // GET: Query
        public ActionResult QueryPage()
        {
            return View();
        }
    }
}