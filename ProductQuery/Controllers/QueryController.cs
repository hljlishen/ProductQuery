using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductQuery.Controllers.Filters;
using ProductQuery.Controllers.Querys;
using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProductQuery.Controllers
{


    public class QueryController : Controller
    {
        public ActionResult QueryPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Query()
        {
            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            string jsonText = stream;
            jsonText = jsonText.Replace("\"[","[");
            jsonText = jsonText.Replace("]\"", "]");
            jsonText = jsonText.Replace("\\\"", "\"");
            List<Querys.SelectList> selectLists = new List<Querys.SelectList>();
            JObject json = (JObject)JsonConvert.DeserializeObject(jsonText);
            JToken token = json["jsonStr"];
            for (int i = 0; i < token.Count(); i++)
            {
                Querys.SelectList selectList = new Querys.SelectList();
                selectList.conditionFieldVal = (string)token[i]["conditionFieldVal"];
                selectList.conditionValueVal = (string)token[i]["conditionValueVal"]["value"];
                selectList.conditionOptionVal = (string)token[i]["conditionOptionVal"];
                selectList.conditionValueLeftVal = (string)token[i]["conditionValueLeftVal"]["value"];
                selectList.conditionValueRightVal = (string)token[i]["conditionValueRightVal"]["value"];
                selectList.conditionValueUnitVal = (string)token[i]["conditionValueUnitVal"]["value"];
                selectLists.Add(selectList);
            }
            Query query = new Query(selectLists);
            List<Ignition> ignitions = query.Process();
            return RedirectToAction("User_list", "AdminUser");
        }
    }
}