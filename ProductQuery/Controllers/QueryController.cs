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
        public ActionResult Query_list()
        {
            WebClickNumber webClickNumber = new WebClickNumber();
            webClickNumber.SaveQueryNumber();
            List<Ignition> ignitions = dbDrive.GetAllIgnitions();
            return View(ignitions);
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

        [HttpPost]
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
            return View(ignitions);
        }

        //public ActionResult Query(string jsonstr)
        //{
        //    string jsonText = jsonstr;
        //    jsonText = jsonText.Replace("\"[", "[");
        //    jsonText = jsonText.Replace("]\"", "]");
        //    jsonText = jsonText.Replace("\\\"", "\"");
        //    List<Querys.SelectList> selectLists = new List<Querys.SelectList>();
        //    JObject json = (JObject)JsonConvert.DeserializeObject(jsonText);
        //    JToken token = json["jsonStr"];
        //    for (int i = 0; i < token.Count(); i++)
        //    {
        //        Querys.SelectList selectList = new Querys.SelectList();
        //        selectList.conditionFieldVal = (string)token[i]["conditionFieldVal"];
        //        selectList.conditionValueVal = (string)token[i]["conditionValueVal"]["value"];
        //        selectList.conditionOptionVal = (string)token[i]["conditionOptionVal"];
        //        selectList.conditionValueLeftVal = (string)token[i]["conditionValueLeftVal"]["value"];
        //        selectList.conditionValueRightVal = (string)token[i]["conditionValueRightVal"]["value"];
        //        selectList.conditionValueUnitVal = (string)token[i]["conditionValueUnitVal"]["value"];
        //        selectLists.Add(selectList);
        //    }
        //    Query query = new Query(selectLists);
        //    List<Ignition> ignitions = query.Process();
        //    return View("Query_list", ignitions);
        //}
    }
}