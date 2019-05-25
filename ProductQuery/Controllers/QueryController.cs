using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductQuery.Controllers.Filters;
using ProductQuery.Controllers.IDbDrives;
using ProductQuery.Controllers.Querys;
using ProductQuery.Controllers.SiteStatistical;
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
        IDbDrive dbDrive = new LingImp();

        public ActionResult Query_index()
        {
            WebClickNumber webClickNumber = new WebClickNumber();
            webClickNumber.SaveQueryNumber();
            List<Ignition> ignitions = dbDrive.GetAllIgnitions();
            ViewData["ignitions"] = ignitions;
            return View();
        }

        //打开查看页面
        [ValidateInput(false)]
        public ActionResult Query_details(int ignitionid)
        {
            Ignition ignition = dbDrive.FindIgnition(ignitionid);
            List<Picture> pictures = ignition.Pictures;
            List<Conventional> conventionals = ignition.Conventionals;
            List<CableDiameter> cableDiameters = ignition.CableDiameters;
            List<SpeedDetonation> speedDetonations = ignition.SpeedDetonations;
            List<InterfaceInformation> interfaceInformation = ignition.InterfaceInformations;
            List<DcResistance> dcResistances = ignition.DcResistances;
            List<IgnitionCondition> ignitionConditions = ignition.IgnitionConditions;
            List<DelayTime> delayTimes = ignition.DelayTimes;
            ViewData["conv"] = conventionals;
            ViewData["img"] = pictures;
            ViewData["ig"] = ignition;
            ViewData["cab"] = cableDiameters;
            ViewData["speed"] = speedDetonations;
            ViewData["interface"] = interfaceInformation;
            ViewData["dc"] = dcResistances;
            ViewData["ignc"] = ignitionConditions;
            ViewData["delay"] = delayTimes;
            return View();
        }
        
        public ActionResult SimpleQuery(string querystring)
        {
            Query query = new Query(querystring);
            List<Ignition> ignitions = query.Process();
            Query query1 = new Query(querystring, "Conventionals");
            List<Ignition> ignitions1 = query1.Process();
            Query query2 = new Query(querystring, "CableDiameters");
            List<Ignition> ignitions2 = query2.Process();
            Query query3 = new Query(querystring, "SpeedDetonations");
            List<Ignition> ignitions3 = query3.Process();
            Query query4 = new Query(querystring, "InterfaceInformations");
            List<Ignition> ignitions4 = query4.Process();
            Query query5 = new Query(querystring, "DcResistances");
            List<Ignition> ignitions5 = query5.Process();
            Query query6 = new Query(querystring, "IgnitionConditions");
            List<Ignition> ignitions6 = query6.Process();
            Query query7 = new Query(querystring, "DelayTimes");
            List<Ignition> ignitions7 = query7.Process();

            List<Ignition> Result = ((((((ignitions1.Union(ignitions2).ToList<Ignition>()).Union(ignitions3).ToList<Ignition>()).Union(ignitions4).ToList<Ignition>()).Union(ignitions5).ToList<Ignition>()).Union(ignitions6).ToList<Ignition>()).Union(ignitions7).ToList<Ignition>()).Union(ignitions).ToList<Ignition>();
            List<Ignition> ign = Result.Where((x, i) => Result.FindIndex(r => r.IgnitionId == x.IgnitionId) == i).ToList();
            ViewData["ignitions"] = ign;
            return PartialView("Query_list", ViewData["ignitions"]);
        }

        public ActionResult Query()
        {
            WebClickNumber webClickNumber = new WebClickNumber();
            webClickNumber.SaveQueryNumber();

            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            string jsonText = stream;
            jsonText = jsonText.Replace("\"[", "[");
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
            ViewData["ignitions"] = ignitions;
            return PartialView("Query_list", ViewData["ignitions"]);
        }
    }
}