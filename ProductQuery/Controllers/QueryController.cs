using ProductQuery.Controllers.Filters;
using ProductQuery.Controllers.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductQuery.Controllers
{
    public class QueryController : Controller
    {
        public ActionResult QueryPage()
        {
            return View();
        }

        //添加点火装置
        [HttpPost]
        public ActionResult QueryPage(List<_Filter> filter)
        {
            Query query = new Query(filter);
            query.Process();
            return View();
        }
    }
}