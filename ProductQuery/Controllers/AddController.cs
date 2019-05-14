using ProductQuery.Models;
using System;
using System.Collections.Generic;
using ProductQuery.Controllers.IMeasurementConverters;
using System.Web;
using System.Web.Mvc;
using ProductQuery.Controllers.IDbDrives;
using System.Drawing;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ProductQuery.Controllers.Querys;

namespace ProductQuery.Controllers
{
    public class AddController : Controller
    {
        IDbDrive dbDrive = new LingImp();
        public ActionResult AddInformation()
        {
            return View();
        }

        public ActionResult Information(List<Ignition> ignitions)
        {
            if (ignitions == null)
            {
                List<Ignition> ign = dbDrive.GetAllIgnitions();
                return View(ign);
            }
            return View(ignitions);
        }

        //打开查看页面
        [ValidateInput(false)]
        public ActionResult Ignition_select(int ignitionid)
        {
            Ignition ignition = dbDrive.FindIgnition(ignitionid);
            List<Picture> pictures = ignition.Pictures;
            List<Conventional> conventionals= ignition.Conventionals;
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

        [ValidateInput(false)]
        public ActionResult Ignition_update(int ignitionid)
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

        //添加点火装置
        [HttpPost]
        public ActionResult AddInformation(FormCollection collection,Ignition ignition)
        {
            if (collection["类别"] != "请选择")
                ignition.lb = collection["类别"];
            ignition.cpmc = collection["产品名称"];
            ignition.sjdw = collection["设计单位"];
            ignition.scdw = collection["生产单位"];
            ignition.xh = collection["型号"];
            ignition.th = collection["图号"];
            ignition.dh = collection["代号"];
            //日期转化
            if (collection["研制日期"] != "")
                ignition.yzrq =DateTime.Parse(DateTime.Parse(collection["研制日期"]).ToString("yyyy-MM-dd"));
            if (collection["设计定型日期"] != "")
                ignition.dxrq = DateTime.Parse(DateTime.Parse(collection["设计定型日期"]).ToString("yyyy-MM-dd"));
            if (collection["生产定型日期"] != "")
                ignition.gydx = DateTime.Parse(DateTime.Parse(collection["生产定型日期"]).ToString("yyyy-MM-dd"));
            ignition.yt = collection["用途"];
            ignition.xtzc = collection["系统组成"];
            ignition.mqjd = collection["目前阶段"];
            ignition.jxxn = collection["机械性能"];
            ignition.dxn = collection["电性能"];
            ignition.gn = collection["功能"];
            ignition.hjcs = collection["环境试验"];
            if(collection["桥丝数目"] != "")
                ignition.jssm =int.Parse(collection["桥丝数目"]);
            if (collection["贮存寿命"] != "")
                ignition.zcsm = int.Parse(collection["贮存寿命"]);
            ignition.ccsmbz = collection["贮存寿命备注"];
            ignition.kkd = collection["可靠度"];
            ignition.zyxnzb = collection["主要性能指标"];
            ignition.syhjzsfw = collection["试验环境指标范围"];
            ignition.jbxn = collection["基本性能"];
            if (collection["宽度"] != "")
                ignition.kd =double.Parse( collection["宽度"]);
            if (collection["脚线"] != "")
                ignition.jx = double.Parse(collection["脚线"]);
            if (collection["总长度"] != "")
                ignition.zcd = double.Parse(collection["总长度"]);
            if (collection["隔板厚度"] != "")
                ignition.gbhd = double.Parse(collection["隔板厚度"]);
            if (collection["索直径上限"] != "")
                ignition.szjsx = double.Parse(collection["索直径上限"]);
            if (collection["索直径下限"] != "")
                ignition.szjxx = double.Parse(collection["索直径下限"]);
            if (collection["索MDF（银质）直径"] != "")
                ignition.sMDFyzzj = double.Parse(collection["索MDF（银质）直径"]);
            ignition.sbz = collection["索备注"];
            if (collection["对边"] != "")
                ignition.db = double.Parse(collection["对边"]);
            if (collection["对角线"] != "")
                ignition.djx = double.Parse(collection["对角线"]);
            ignition.lfdjbz = collection["六方对角备注"];
            if (collection["检测电流"] != "")
                ignition.jcdl = double.Parse(collection["检测电流"]);
            if (collection["静电电容"] != "")
                ignition.jddr = double.Parse(collection["静电电容"]);
            if (collection["静电电压"] != "")
                ignition.jddy = double.Parse(collection["静电电压"]);
            if (collection["串联电阻"] != "")
                ignition.cldz = double.Parse(collection["串联电阻"]);
            ignition.jdgdbz = collection["静电感度备注"];
            if (collection["作用时间单位"] != "请选择")
            {
                string unit = collection["作用时间单位"];
                double value = double.Parse(collection["作用时间"]);
                ignition.zysj = TimeUnitConversion(unit, value);
            }
            if (collection["作用时间上限单位"] != "请选择")
            {
                string unit = collection["作用时间上限单位"];
                double value = double.Parse(collection["作用时间上限"]);
                ignition.zysjsx = TimeUnitConversion(unit, value);
            }
            if (collection["作用时间下限单位"] != "请选择")
            {
                string unit = collection["作用时间下限单位"];
                double value = double.Parse(collection["作用时间下限"]);
                ignition.zysjxx = TimeUnitConversion(unit, value);
            }
            ignition.zysjbz = collection["作用时间备注"];
            if (collection["安全电流桥个数"] != "")
                ignition.jgs =int.Parse( collection["安全电流桥个数"]);
            if (collection["安全电流值单位"] != "请选择")
            {
                string unit = collection["安全电流值单位"];
                double value = double.Parse(collection["安全电流值"]);
                ignition.aydlz = CurrentUnitConversion(unit, value);
            }
            if (collection["安全电流值上限单位"] != "请选择")
            {
                string unit = collection["安全电流值上限单位"];
                double value = double.Parse(collection["安全电流值上限"]);
                ignition.aydlzxx = CurrentUnitConversion(unit, value);
            }
            if (collection["安全电流值下限单位"] != "请选择")
            {
                string unit = collection["安全电流值下限单位"];
                double value = double.Parse(collection["安全电流值下限"]);
                ignition.aydlzsx = CurrentUnitConversion(unit, value);
            }
            if (collection["时间值单位"] != "请选择")
            {
                string unit = collection["时间值单位"];
                double value = double.Parse(collection["时间值"]);
                ignition.ssj = TimeUnitConversion(unit, value);
            }
            if (collection["功率值"] != "")
                ignition.glz =double.Parse( collection["功率值"]);
            ignition.aqdlbz = collection["安全电流备注"];
            if (collection["安全电压电压"] != "")
                ignition.aqdydy = double.Parse(collection["安全电压电压"]);
            if (collection["安全电压电容"] != "")
                ignition.aqdydr = double.Parse(collection["安全电压电容"]);
            if (collection["燃烧压力上限"] != "")
                ignition.rsylxx = double.Parse(collection["燃烧压力上限"]);
            if (collection["燃烧压力下限"] != "")
                ignition.rsylsx = double.Parse(collection["燃烧压力下限"]);
            ignition.rsylbz = collection["燃烧压力备注"];
            AddConventionals(collection, ignition);
            AddCableDiameter(collection, ignition);
            AddSpeedDetonation(collection, ignition);
            AddInterfaceInformation(collection, ignition);
            AddDcResistance(collection, ignition);
            AddIgnitionCondition(collection, ignition);
            AddDelayTime(collection, ignition);
            AddImage(collection, ignition);
            dbDrive.Insert(ignition);
            return View();
        }

        //添加图片
        private void AddImage(FormCollection collection, Ignition ignition) {
            for (int i = 1; i <= 5; i++)
            {
                if (collection["file"+i] != null)
                {
                    if (collection["file" + i] != "") {
                        Picture picture = new Picture();
                        string cpy = collection["cp" + i];
                        string[] array = cpy.Split(',');
                        byte[] imageBytes = Convert.FromBase64String(array[1]);
                        picture.cpy = imageBytes;
                        ignition.Pictures.Add(picture);
                    }
                }
            }
        }

        //添加常规
        private void AddConventionals(FormCollection collection, Ignition ignition)
        {
            int s = 0;
            if (collection["常规"] != null)
            {
                if (collection["常规"].Length == 1)
                    s = collection["常规"].Length;
                else
                    s = ((collection["常规"].Length - 1) / 2) + 1;
                for (int i = 1; i <= s; i++)
                {
                    Conventional conventional = new Conventional();
                    conventional.ccmc = collection["尺寸名称" + i];
                    if (collection["直径" + i] != "")
                        conventional.zj = double.Parse(collection["直径" + i]);
                    if (collection["常规长度" + i] != "")
                        conventional.cd = double.Parse(collection["常规长度" + i]);
                    if (collection["高度" + i] != "")
                        conventional.gd = double.Parse(collection["高度" + i]);
                    ignition.Conventionals.Add(conventional);
                }
            }
        }

        //索普通直径
        private void AddCableDiameter(FormCollection collection ,Ignition ignition)
        {
            int s = 0;
            if (collection["索普通直径"] != null)
            {
                if (collection["索普通直径"].Length == 1)
                    s = collection["索普通直径"].Length;
                else
                    s = ((collection["索普通直径"].Length - 1) / 2) + 1;
                for (int i = 1; i <= s; i++)
                {
                    CableDiameter cableDiameter = new CableDiameter();
                    if(collection["索普通直径" + i] != "")
                        cableDiameter.ptszj = double.Parse(collection["索普通直径" + i]);
                    ignition.CableDiameters.Add(cableDiameter);
                }
            }
        }

        //爆速
        private void AddSpeedDetonation(FormCollection collection, Ignition ignition)
        {
            int s = 0;
            if (collection["爆速"] != null)
            {
                if (collection["爆速"].Length == 1)
                    s = collection["爆速"].Length;
                else
                    s = ((collection["爆速"].Length - 1) / 2) + 1;
                for (int i = 1; i <= s; i++)
                {
                    SpeedDetonation speedDetonation = new SpeedDetonation();
                    if (collection["爆速上限" + i] != "")
                        speedDetonation.bssx = double.Parse(collection["爆速上限" + i]);
                    if (collection["爆速下限" + i] != "")
                        speedDetonation.bsxx = double.Parse(collection["爆速下限" + i]);
                    speedDetonation.bsbz = collection["爆速备注" + i];
                    ignition.SpeedDetonations.Add(speedDetonation);
                }
            }
        }

        //接口信息
        private void AddInterfaceInformation(FormCollection collection, Ignition ignition)
        {
            int s = 0;
            if (collection["接口信息"] != null)
            {
                if (collection["接口信息"].Length == 1)
                    s = collection["接口信息"].Length;
                else
                    s = ((collection["接口信息"].Length - 1) / 2) + 1;
                for (int i = 1; i <= s; i++)
                {
                    InterfaceInformation interfaceInformation = new InterfaceInformation();
                    if (collection["螺纹" + i] != "")
                        interfaceInformation.lw = double.Parse(collection["螺纹" + i]);
                    if (collection["螺距" + i] != "")
                        interfaceInformation.lj = double.Parse(collection["螺距" + i]);
                    interfaceInformation.gc = collection["公差" + i];
                    if (collection["接口信息长度" + i] != "")
                        interfaceInformation.cd = double.Parse(collection["接口信息长度" + i]);
                    interfaceInformation.jkxxbz = collection["接口信息备注" + i];
                    ignition.InterfaceInformations.Add(interfaceInformation);
                }
            }
        }

        //直流电阻
        private void AddDcResistance(FormCollection collection, Ignition ignition)
        {
            int s = 0;
            if (collection["直流电阻"] != null)
            {
                if (collection["直流电阻"].Length == 1)
                    s = collection["直流电阻"].Length;
                else
                    s = ((collection["直流电阻"].Length - 1) / 2) + 1;
                for (int i = 1; i <= s; i++)
                {
                    DcResistance dcResistance = new DcResistance();
                    if (collection["直流电阻桥个数" + i] != "")
                        dcResistance.dzqgs = int.Parse(collection["直流电阻桥个数" + i]);
                    if (collection["电阻范围值上单位" + i] != "请选择")
                    {
                        string unit = collection["电阻范围值上单位" + i];
                        double value = double.Parse(collection["电阻范围值上" + i]);
                        dcResistance.dzfwzsx = ResistanceUnitConversion(unit, value);
                    }
                    if (collection["电阻范围值下单位" + i] != "请选择")
                    {
                        string unit = collection["电阻范围值下单位" + i];
                        double value = double.Parse(collection["电阻范围值下" + i]);
                        dcResistance.dzfwzxx = ResistanceUnitConversion(unit, value);
                    }
                    if (collection["电阻小于值单位" + i] != "请选择")
                    {
                        string unit = collection["电阻小于值单位" + i];
                        double value = double.Parse(collection["电阻小于值" + i]);
                        dcResistance.dzxyz = ResistanceUnitConversion(unit, value);
                    }
                    dcResistance.dzbz = collection["电阻备注" + i];
                    ignition.DcResistances.Add(dcResistance);
                }
            }
        }

        //发火条件
        private void AddIgnitionCondition(FormCollection collection, Ignition ignition)
        {
            int s = 0;
            if (collection["发火条件"] != null)
            {
                if (collection["发火条件"].Length == 1)
                    s = collection["发火条件"].Length;
                else
                    s = ((collection["发火条件"].Length - 1) / 2) + 1;
                for (int i = 1; i <= s; i++)
                {
                    IgnitionCondition ignitionCondition = new IgnitionCondition();
                    if (collection["桥个数" + i] != "")
                        ignitionCondition.qgs = int.Parse(collection["桥个数" + i]);
                    if (collection["发火电压" + i] != "")
                        ignitionCondition.fhdy = double.Parse(collection["发火电压" + i]);
                    if (collection["发火电压上限" + i] != "")
                        ignitionCondition.fhdysx = double.Parse(collection["发火电压上限" + i]);
                    if (collection["发火电压下限" + i] != "")
                        ignitionCondition.fhdyxx = double.Parse(collection["发火电压下限" + i]);
                    if (collection["发火电容单位" + i] != "请选择")
                    {
                        string unit = collection["发火电容单位" + i];
                        double value = double.Parse(collection["发火电容" + i]);
                        ignitionCondition.fhdr = CapacitanceUnitConversion(unit, value);
                    }
                    ignitionCondition.fhdybz = collection["电压发火备注" + i];
                    if (collection["发火电流单位" + i] != "请选择")
                    {
                        string unit = collection["发火电流单位" + i];
                        double value = double.Parse(collection["发火电流" + i]);
                        ignitionCondition.fhdl = CurrentUnitConversion(unit, value);
                    }
                    if (collection["发火电流上限单位" + i] != "请选择")
                    {
                        string unit = collection["发火电流上限单位" + i];
                        double value = double.Parse(collection["发火电流上限" + i]);
                        ignitionCondition.fhdlsx = CurrentUnitConversion(unit, value);
                    }
                    if (collection["发火电流下限单位" + i] != "请选择")
                    {
                        string unit = collection["发火电流下限单位" + i];
                        double value = double.Parse(collection["发火电流下限" + i]);
                        ignitionCondition.fhdlxx = CurrentUnitConversion(unit, value);
                    }
                    if (collection["发火电流时间单位" + i] != "请选择")
                    {
                        string unit = collection["发火电流时间单位" + i];
                        double value = double.Parse(collection["发火电流时间" + i]);
                        ignitionCondition.fhdlss = TimeUnitConversion(unit, value);
                    }
                    ignitionCondition.dlfhbz = collection["电流发火备注" + i];
                    if (collection["锤重单位" + i] != "请选择")
                    {
                        string unit = collection["锤重单位" + i];
                        double value = double.Parse(collection["锤重" + i]);
                        ignitionCondition.cz = WeightUnitConversion(unit, value);
                    }
                    if (collection["落高单位" + i] != "请选择")
                    {
                        string unit = collection["落高单位" + i];
                        double value = double.Parse(collection["落高" + i]);
                        ignitionCondition.lg = LenghtUnitConversion(unit, value);
                    }
                    if (collection["击针刺激量" + i] != "")
                        ignitionCondition.jzcjl = double.Parse(collection["击针刺激量" + i]);
                    if (collection["击针力上限" + i] != "")
                        ignitionCondition.jzlsx = double.Parse(collection["击针力上限" + i]);
                    if (collection["击针力下限" + i] != "")
                        ignitionCondition.jzlxx = double.Parse(collection["击针力下限" + i]);
                    if (collection["击针突出量上限" + i] != "")
                        ignitionCondition.jztclsx = double.Parse(collection["击针突出量上限" + i]);
                    if (collection["击针突出量下限" + i] != "")
                        ignitionCondition.jztclxx = double.Parse(collection["击针突出量下限" + i]);
                    if (collection["弹簧高度" + i] != "")
                        ignitionCondition.thgd = double.Parse(collection["弹簧高度" + i]);
                    if (collection["抗力" + i] != "")
                        ignitionCondition.kl = double.Parse(collection["抗力" + i]);
                    ignitionCondition.jxfhbz = collection["机械发火备注" + i];
                    if (collection["能量单位" + i] != "请选择")
                    {
                        string unit = collection["能量单位" + i];
                        double value = double.Parse(collection["能量" + i]);
                        ignitionCondition.nl = EnergyUnitConversion(unit, value);
                    }
                    ignition.IgnitionConditions.Add(ignitionCondition);
                }
            }
        }

        //延期时间
        private void AddDelayTime(FormCollection collection, Ignition ignition)
        {
            int s = 0;
            if (collection["延期时间"] != null)
            {
                if (collection["延期时间"].Length == 1)
                    s = collection["延期时间"].Length;
                else
                    s = ((collection["延期时间"].Length - 1) / 2) + 1;
                for (int i = 1; i <= s; i++)
                {
                    DelayTime delayTime = new DelayTime();
                    if (collection["温度条件" + i] != "")
                        delayTime.wdtj = double.Parse(collection["温度条件" + i]);
                    if (collection["延期时间上限单位" + i] != "请选择")
                    {
                        string unit = collection["延期时间上限单位" + i];
                        double value = double.Parse(collection["延期时间上限" + i]);
                        delayTime.yqsjsx = TimeUnitConversion(unit, value);
                    }
                    if (collection["延期时间下限单位" + i] != "请选择")
                    {
                        string unit = collection["延期时间下限单位" + i];
                        double value = double.Parse(collection["延期时间下限" + i]);
                        delayTime.yqsjxx = TimeUnitConversion(unit, value);
                    }
                    if (collection["延期时间值单位" + i] != "请选择")
                    {
                        string unit = collection["延期时间值单位" + i];
                        double value = double.Parse(collection["延期时间值" + i]);
                        delayTime.yqsjz = TimeUnitConversion(unit, value);
                    }
                    delayTime.yqsjbz= collection["延期时间备注" + i];
                    ignition.DelayTimes.Add(delayTime);
                }
            }
        }

        //时间单位转化
        private double TimeUnitConversion(string unit,double value)
        {
            IMeasurementConverter measurementConverter1 = new Time(unit);
            double TestValue1 = measurementConverter1.ToStandardValue(value);
            return TestValue1;
        }

        //电流单位转化
        private double CurrentUnitConversion(string unit, double value)
        {
            IMeasurementConverter measurementConverter1 = new Current(unit);
            double TestValue1 = measurementConverter1.ToStandardValue(value);
            return TestValue1;
        }

        //电容单位转化
        private double CapacitanceUnitConversion(string unit, double value)
        {
            IMeasurementConverter measurementConverter1 = new Capacitance(unit);
            double TestValue1 = measurementConverter1.ToStandardValue(value);
            return TestValue1;
        }

        //长度单位转化
        private double LenghtUnitConversion(string unit, double value)
        {
            IMeasurementConverter measurementConverter1 = new Lenght(unit);
            double TestValue1 = measurementConverter1.ToStandardValue(value);
            return TestValue1;
        }

        //电阻单位转化
        private double ResistanceUnitConversion(string unit, double value)
        {
            IMeasurementConverter measurementConverter1 = new Resistance(unit);
            double TestValue1 = measurementConverter1.ToStandardValue(value);
            return TestValue1;
        }

        //能量单位转化
        private double EnergyUnitConversion(string unit, double value)
        {
            IMeasurementConverter measurementConverter1 = new Energy(unit);
            double TestValue1 = measurementConverter1.ToStandardValue(value);
            return TestValue1;
        }

        //重量单位转化
        private double WeightUnitConversion(string unit, double value)
        {
            IMeasurementConverter measurementConverter1 = new Weight(unit);
            double TestValue1 = measurementConverter1.ToStandardValue(value);
            return TestValue1;
        }

        //删除火工品
        public ActionResult DeleteInformation(int IgnitionId)
        {
            Ignition ignition = new Ignition();
            ignition.IgnitionId = IgnitionId;
            dbDrive.Delete(ignition);
            return RedirectToAction("Information", "Add");
        }

        public ActionResult QueryInformation(string jsonstr)
        {
            string jsonText = jsonstr;
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
            return View("Information", ignitions);
        }

    }
}