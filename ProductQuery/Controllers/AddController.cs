using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductQuery.Controllers.IDbDrives;
using ProductQuery.Controllers.IMeasurementConverters;
using ProductQuery.Controllers.Querys;
using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProductQuery.Controllers
{
    public class AddController : Controller
    {
        IDbDrive dbDrive = new LingImp();
        private static List<Picture> pic;
        private static List<Conventional> conv;
        private static List<CableDiameter> cab;
        private static List<SpeedDetonation> speed;
        private static List<InterfaceInformation> inter;
        private static List<DcResistance> dc;
        private static List<IgnitionCondition> ign;
        private static List<DelayTime> delay;
        bool IsList = false;
        bool Isscope = false;
        bool IsUnitvalue = false;
        bool IsInt = false;
        Ignition updateIgnition = new Ignition();
        Ignition delect = new Ignition();
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
            IsList = true;
            ViewDateGetInter(ignitionid);
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Ignition_update(int ignitionid)
        {
            IsList = false;
            ViewDateGetInter(ignitionid);
            ViewData["id"] = ignitionid;
            return View();
        }

        //查看修改ViewDate获取信息
        private void ViewDateGetInter(int ignitionid)
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
            if (IsList == false)
            {
                pic = new List<Picture>();
                pic = pictures;
                conv = new List<Conventional>();
                conv = conventionals;
                cab = new List<CableDiameter>();
                cab = cableDiameters;
                speed = new List<SpeedDetonation>();
                speed = speedDetonations;
                inter = new List<InterfaceInformation>();
                inter = interfaceInformation;
                dc = new List<DcResistance>();
                dc = dcResistances;
                ign = new List<IgnitionCondition>();
                ign = ignitionConditions;
                delay = new List<DelayTime>();
                delay = delayTimes;
                IsList = true;
            }
        }

        //更新
        [HttpPost]
        public JsonResult Ignition_update(FormCollection collection, Ignition ignition)
        {
            ignition.IgnitionId = int.Parse(collection["ingid"]);
            Information(collection, ignition, ignition.IgnitionId);
            if (!Isscope && !IsUnitvalue)
                AddImages(collection, ignition, ignition.IgnitionId);
            List<bool> c = new List<bool>();
            if (Isscope)
            {
                c.Add(false);
                c.Add(true);
                return Json(c);
            }
            if (IsUnitvalue)
            {
                c.Add(false);
                c.Add(false);
                return Json(c);
            }
            if (IsInt)
            {
                c.Add(false);
                c.Add(false);
                c.Add(true);
            }
            if (dbDrive.Udpdate(ignition))
                c.Add(true);
            AddImage();
            DelectImage();
            AddConventional();
            DelectConventional();
            AddCableDiameter();
            DelectCableDiameter();
            AddSpeedDetonation();
            DelectSpeedDetonation();
            AddInterfaceInformation();
            DelectInterfaceInformation();
            AddDcResistance();
            DelectDcResistance();
            AddIgnitionCondition();
            DelectIgnitionCondition();
            AddDelay();
            DelectDelay();
            return Json(c);
        }

        private void Information(FormCollection collection, Ignition ignition,int id)
        {
            Isscope = false;
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
                ignition.yzrq = DateTime.Parse(DateTime.Parse(collection["研制日期"]).ToString("yyyy-MM-dd"));
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
            if (collection["桥丝数目"] != "")
            {
                try {
                    ignition.jssm = int.Parse(collection["桥丝数目"]);
                }
                catch (Exception)
                {
                    IsInt = true;
                    return;
                }
            }

            if (collection["贮存寿命"] != "")
            {
                try
                {
                    ignition.zcsm = double.Parse(collection["贮存寿命"]);
                }
                catch (Exception)
                {
                    IsInt = true;
                    return;
                }
            }
            ignition.ccsmbz = collection["贮存寿命备注"];
            ignition.kkd = collection["可靠度"];
            ignition.zyxnzb = collection["主要性能指标"];
            ignition.syhjzsfw = collection["试验环境指标范围"];
            ignition.jbxn = collection["基本性能"];
            if (collection["宽度"] != "")
                ignition.kd = double.Parse(collection["宽度"]);
            if (collection["脚线"] != "")
                ignition.jx = double.Parse(collection["脚线"]);
            if (collection["总长度"] != "")
                ignition.zcd = double.Parse(collection["总长度"]);
            if (collection["隔板厚度"] != "")
                ignition.gbhd = double.Parse(collection["隔板厚度"]);

            if (collection["索直径上限"] != "" && collection["索直径下限"] != "") {
                ignition.szjsx = double.Parse(collection["索直径上限"]);
                ignition.szjxx = double.Parse(collection["索直径下限"]);
                if (ignition.szjsx < ignition.szjxx)
                    Isscope = true;
            }
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
            {
                string unit = "pf";
                double value = double.Parse(collection["静电电容"]);
                ignition.jddr = CapacitanceUnitConversion(unit, value);
            }

            if (collection["静电电压"] != "")
                ignition.jddy = double.Parse(collection["静电电压"]);
            if (collection["串联电阻"] != "")
                ignition.cldz = double.Parse(collection["串联电阻"]);
            ignition.jdgdbz = collection["静电感度备注"];

            if (collection["作用时间"] != "" && collection["作用时间单位"] != "请选择")
            {
                string unit = collection["作用时间单位"];
                double value = double.Parse(collection["作用时间"]);
                ignition.zysj = TimeUnitConversion(unit, value);
            }
            else if (collection["作用时间"] == "" && collection["作用时间单位"] != "请选择")
                IsUnitvalue = true;
            else if(collection["作用时间"] != "" && collection["作用时间单位"] == "请选择")
                IsUnitvalue = true;

            if (collection["作用时间上限单位"] != "请选择" && collection["作用时间下限单位"] != "请选择" && collection["作用时间上限"] != "" && collection["作用时间下限"] != "")
            {
                string unit = collection["作用时间上限单位"];
                double value = double.Parse(collection["作用时间上限"]);
                ignition.zysjsx = TimeUnitConversion(unit, value);
                string unit2 = collection["作用时间下限单位"];
                double value2 = double.Parse(collection["作用时间下限"]);
                ignition.zysjxx = TimeUnitConversion(unit2, value2);
                if (ignition.zysjsx < ignition.zysjxx)
                    Isscope = true;
            }
            else if (collection["作用时间上限单位"] == "请选择" && collection["作用时间下限单位"] == "请选择" && collection["作用时间上限"] == "" && collection["作用时间下限"] == "")
            { }
            else
                IsUnitvalue = true;
            ignition.zysjbz = collection["作用时间备注"];
            if (collection["安全电流桥个数"] != "")
            {
                try
                {
                    ignition.jgs = int.Parse(collection["安全电流桥个数"]);
                }
                catch (Exception)
                {
                    IsInt = true;
                    return;
                }
            }
            if (collection["安全电流值单位"] != "请选择" && collection["安全电流值"]!="")
            {
                string unit = collection["安全电流值单位"];
                double value = double.Parse(collection["安全电流值"]);
                ignition.aydlz = CurrentUnitConversion(unit, value);
            }
            else if (collection["安全电流值"] == "" && collection["安全电流值单位"] != "请选择")
                IsUnitvalue = true;
            else if (collection["安全电流值"] != "" && collection["安全电流值单位"] == "请选择")
                IsUnitvalue = true;
            if (collection["安全电流值上限单位"] != "请选择" && collection["安全电流值下限单位"] != "请选择" && collection["安全电流值上限"] != "" && collection["安全电流值下限"] != "")
            {
                string unit = collection["安全电流值上限单位"];
                double value = double.Parse(collection["安全电流值上限"]);
                ignition.aydlzsx = CurrentUnitConversion(unit, value);
                string unit2 = collection["安全电流值下限单位"];
                double value2 = double.Parse(collection["安全电流值下限"]);
                ignition.aydlzxx = CurrentUnitConversion(unit2, value2);
                if (ignition.aydlzsx < ignition.aydlzxx)
                    Isscope = true;
            }
            else if (collection["安全电流值上限单位"] == "请选择" && collection["安全电流值下限单位"] == "请选择" && collection["安全电流值上限"] == "" && collection["安全电流值下限"] == "")
            { }
            else
                IsUnitvalue = true;
            if (collection["时间值单位"] != "请选择" && collection["时间值"]!= "")
            {
                string unit = collection["时间值单位"];
                double value = double.Parse(collection["时间值"]);
                ignition.ssj = TimeUnitConversion(unit, value);
            }
            else if (collection["时间值"] == "" && collection["时间值单位"] != "请选择")
                IsUnitvalue = true;
            else if (collection["时间值"] != "" && collection["时间值单位"] == "请选择")
                IsUnitvalue = true;
            if (collection["功率值"] != "")
                ignition.glz = double.Parse(collection["功率值"]);
            ignition.aqdlbz = collection["安全电流备注"];
            if (collection["安全电压电压"] != "")
                ignition.aqdydy = double.Parse(collection["安全电压电压"]);
            if (collection["安全电压电容单位"] != "请选择" && collection["安全电压电容"] != "")
            {
                string unit = collection["安全电压电容单位"];
                double value = double.Parse(collection["安全电压电容"]);
                ignition.aqdydr = CapacitanceUnitConversion(unit, value);
            }
            else if (collection["安全电压电容"] == "" && collection["安全电压电容单位"] != "请选择")
                IsUnitvalue = true;
            else if (collection["安全电压电容"] != "" && collection["安全电压电容单位"] == "请选择")
                IsUnitvalue = true;
            ignition.aqdydrbz = collection["安全电压电容备注"];
            if (collection["燃烧压力上限"] != "" && collection["燃烧压力下限"] != "")
            {
                ignition.rsylsx = double.Parse(collection["燃烧压力上限"]);
                ignition.rsylxx = double.Parse(collection["燃烧压力下限"]);
                if (ignition.rsylsx < ignition.rsylxx)
                    Isscope = true;
            }
            ignition.rsylbz = collection["燃烧压力备注"];
            AddConventionals(collection, ignition, id);
            AddCableDiameters(collection, ignition, id);
            AddSpeedDetonations(collection, ignition, id);
            AddInterfaceInformations(collection, ignition, id);
            AddDcResistances(collection, ignition, id);
            AddIgnitionConditions(collection, ignition, id);
            AddDelayTimes(collection, ignition, id);
        }

        //添加点火装置
        [HttpPost]
        public JsonResult AddInformation(FormCollection collection,Ignition ignition)
        {
            int id = -1;
            Information(collection, ignition,id);
            AddImage(collection, ignition);
            List<bool> c = new List<bool>();
            if (Isscope)
            {
                c.Add(false);
                c.Add(true);
                return Json(c);
            }
            if (IsUnitvalue)
            {
                c.Add(false);
                c.Add(false);
                return Json(c);
            }
            if (IsInt)
            {
                c.Add(false);
                c.Add(false);
                c.Add(true);
            }
            if (dbDrive.Insert(ignition))
                c.Add(true);
            return Json(c);
        }

        //添加图片
        private void AddImage(FormCollection collection, Ignition ignition) {
            for (int i = 1; i <= 10; i++)
            {
                if (collection["cp"+i] != null)
                {
                    if (collection["cp" + i] != "") {
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

        //修改图片
        private void AddImages(FormCollection collection, Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                if (collection["cp" + "-" + i] != null)
                {
                    if (collection["cp" + "-" + i] != "")
                    {
                        Picture picture = new Picture();
                        string cpy = collection["cp" + "-" + i];
                        string[] array = cpy.Split(',');
                        byte[] imageBytes = Convert.FromBase64String(array[1]);
                        picture.cpy = imageBytes;
                        if (collection["产品示意图id" + i] != null)
                        {
                            picture.Id = int.Parse(collection["产品示意图id" + i]);
                            picture.IgnitionID = id;
                            list1.Add(picture.Id);
                            ignition.Pictures.Add(picture);
                        }
                    }
                }
            }
            for (int i = 1; i <= 10; i++)
            {
                if (collection["cp" + "_" + i] != null)
                {
                    if (collection["cp" + "_" + i] != "")
                    {
                        Picture picture = new Picture();
                        string cpy = collection["cp" + "_" + i];
                        string[] array = cpy.Split(',');
                        byte[] imageBytes = Convert.FromBase64String(array[1]);
                        picture.cpy = imageBytes;
                        picture.IgnitionID = id;
                        updateIgnition.Pictures.Add(picture);
                    }
                }
            }
            foreach (var dr in pic)
                list2.Add(dr.Id);
            foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
            {
                Picture model = new Picture();
                model.Id = dr;
                delect.Pictures.Add(model);
            }
        }

        //添加图片
        private void AddImage()
        {
            foreach (var dr in updateIgnition.Pictures)
                dbDrive.Insert(dr);
        }

        //删除图片
        private void DelectImage()
        {
            foreach (var dr in delect.Pictures)
                dbDrive.Delete(dr);
        }

        //常规
        private void AddConventionals(FormCollection collection, Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            if (collection["常规"] != null)
            {
                string[] count = collection["常规"].Split(',');
                foreach (var i in count)
                {
                    Conventional conventional = new Conventional();
                    conventional.ccmc = collection["尺寸名称" + i];
                    if (collection["直径" + i] != "")
                        conventional.zj = double.Parse(collection["直径" + i]);
                    if (collection["常规长度" + i] != "")
                        conventional.cd = double.Parse(collection["常规长度" + i]);
                    if (collection["高度" + i] != "")
                        conventional.gd = double.Parse(collection["高度" + i]);
                    conventional.ccbz = collection["尺寸备注" + i];
                    if (id != -1 && collection["常规id" + i] != null)
                    {
                        conventional.Id = int.Parse(collection["常规id" + i]);
                        conventional.IgnitionID = id;
                        list1.Add(conventional.Id);
                        ignition.Conventionals.Add(conventional);
                    }
                    else {
                        conventional.IgnitionID = id;
                        updateIgnition.Conventionals.Add(conventional);
                    }
                    if (id == -1)
                        ignition.Conventionals.Add(conventional);
                }
            }
            if (id != -1) {
                foreach (var dr in conv)
                    list2.Add(dr.Id);
                foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
                {
                    Conventional conventional = new Conventional();
                    conventional.Id = dr;
                    delect.Conventionals.Add(conventional);
                }
            }
        }

        //添加常规
        private void AddConventional()
        {
            foreach (var dr in updateIgnition.Conventionals)
                dbDrive.Insert(dr);
        }

        //删除常规
        private void DelectConventional()
        {
            foreach (var dr in delect.Conventionals)
                dbDrive.Delete(dr);
        }

        //索普通直径
        private void AddCableDiameters(FormCollection collection ,Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            if (collection["索普通直径"] != null)
            {
                string[] count = collection["索普通直径"].Split(',');
                foreach (var i in count)
                {
                    CableDiameter cableDiameter = new CableDiameter();
                    if (collection["索普通直径" + i] != "")
                        cableDiameter.ptszj = double.Parse(collection["索普通直径" + i]);
                    if (id != -1 && collection["索普通直径id" + i] != null)
                    {
                        cableDiameter.Id = int.Parse(collection["索普通直径id" + i]);
                        cableDiameter.IgnitionID = id;
                        list1.Add(cableDiameter.Id);
                        ignition.CableDiameters.Add(cableDiameter);
                    }
                    else
                    {
                        cableDiameter.IgnitionID = id;
                        updateIgnition.CableDiameters.Add(cableDiameter);
                    }
                    if (id == -1)
                        ignition.CableDiameters.Add(cableDiameter);
                }
            }
            if (id != -1)
            {
                foreach (var dr in cab)
                    list2.Add(dr.Id);
                foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
                {
                    CableDiameter model = new CableDiameter();
                    model.Id = dr;
                    delect.CableDiameters.Add(model);
                }
            }
        }

        //添加索普通直径
        private void AddCableDiameter()
        {
            foreach (var dr in updateIgnition.CableDiameters)
                dbDrive.Insert(dr);
        }

        //删除索普通直径
        private void DelectCableDiameter()
        {
            foreach (var dr in delect.CableDiameters)
                dbDrive.Delete(dr);
        }

        //爆速
        private void AddSpeedDetonations(FormCollection collection, Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            if (collection["爆速"] != null)
            {
                string[] count = collection["爆速"].Split(',');
                foreach (var i in count)
                {
                    SpeedDetonation speedDetonation = new SpeedDetonation();
                    if (collection["爆速上限" + i] != "" && collection["爆速下限" + i] != "")
                    {
                        speedDetonation.bssx = double.Parse(collection["爆速上限" + i]);
                        speedDetonation.bsxx = double.Parse(collection["爆速下限" + i]);
                        if (speedDetonation.bssx < speedDetonation.bsxx)
                        {
                            Isscope = true;
                            return;
                        }
                    }; 
                    speedDetonation.bsbz = collection["爆速备注" + i];
                    if (id != -1 && collection["爆速id" + i] != null)
                    {
                        speedDetonation.Id = int.Parse(collection["爆速id" + i]);
                        speedDetonation.IgnitionID = id;
                        list1.Add(speedDetonation.Id);
                        ignition.SpeedDetonations.Add(speedDetonation);
                    }
                    else
                    {
                        speedDetonation.IgnitionID = id;
                        updateIgnition.SpeedDetonations.Add(speedDetonation);
                    }
                    if (id == -1)
                        ignition.SpeedDetonations.Add(speedDetonation);
                }
            }
            if (id != -1)
            {
                foreach (var dr in speed)
                    list2.Add(dr.Id);
                foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
                {
                    SpeedDetonation speedDetonation = new SpeedDetonation();
                    speedDetonation.Id = dr;
                    delect.SpeedDetonations.Add(speedDetonation);
                }
            }

        }

        //添加爆速
        private void AddSpeedDetonation()
        {
            foreach (var dr in updateIgnition.SpeedDetonations)
                dbDrive.Insert(dr);
        }

        //删除爆速
        private void DelectSpeedDetonation()
        {
            foreach (var dr in delect.SpeedDetonations)
                dbDrive.Delete(dr);
        }

        //接口信息
        private void AddInterfaceInformations(FormCollection collection, Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            if (collection["接口信息"] != null)
            {
                string[] count = collection["接口信息"].Split(',');
                foreach (var i in count)
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
                    if (id != -1 && collection["接口信息id" + i] != null)
                    {
                        interfaceInformation.Id = int.Parse(collection["接口信息id" + i]);
                        interfaceInformation.IgnitionID = id;
                        list1.Add(interfaceInformation.Id);
                        ignition.InterfaceInformations.Add(interfaceInformation);
                    }
                    else
                    {
                        interfaceInformation.IgnitionID = id;
                        updateIgnition.InterfaceInformations.Add(interfaceInformation);
                    }
                    if(id == -1)
                        ignition.InterfaceInformations.Add(interfaceInformation);
                }
            }
            if (id != -1)
            {
                foreach (var dr in inter)
                    list2.Add(dr.Id);
                foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
                {
                    InterfaceInformation model = new InterfaceInformation();
                    model.Id = dr;
                    delect.InterfaceInformations.Add(model);
                }
            }
        }

        //添加接口信息
        private void AddInterfaceInformation()
        {
            foreach (var dr in updateIgnition.InterfaceInformations)
                dbDrive.Insert(dr);
        }

        //删除接口信息
        private void DelectInterfaceInformation()
        {
            foreach (var dr in delect.InterfaceInformations)
                dbDrive.Delete(dr);
        }

        //直流电阻
        private void AddDcResistances(FormCollection collection, Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            if (collection["直流电阻"] != null)
            {
                string[] count = collection["直流电阻"].Split(',');
                foreach (var i in count)
                {
                    DcResistance dcResistance = new DcResistance();
                    if (collection["直流电阻桥个数" + i] != "")
                    {
                        try
                        {
                            dcResistance.dzqgs = int.Parse(collection["直流电阻桥个数" + i]);
                        }
                        catch (Exception)
                        {
                            IsInt = true;
                            return;
                        }
                    }
                    if (collection["电阻范围值上单位" + " " + i] != "请选择" && collection["电阻范围值下单位" + " " + i] != "请选择" && collection["电阻范围值上" + i] != "" && collection["电阻范围值下" + i] != "")
                    {
                        string unit = collection["电阻范围值上单位" + " " + i];
                        double value = double.Parse(collection["电阻范围值上" + i]);
                        dcResistance.dzfwzsx = ResistanceUnitConversion(unit, value);
                        string unit2 = collection["电阻范围值下单位" + " " + i];
                        double value2 = double.Parse(collection["电阻范围值下" + i]);
                        dcResistance.dzfwzxx = ResistanceUnitConversion(unit2, value2);
                        if (dcResistance.dzfwzsx < dcResistance.dzfwzxx)
                        {
                            Isscope = true;
                            return;
                        }
                    }
                    else if (collection["电阻范围值上单位" + " " + i] == "请选择" && collection["电阻范围值下单位" + " " + i] == "请选择" && collection["电阻范围值上" + i] == "" && collection["电阻范围值下" + i] == "")
                    { }
                    else
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["电阻值单位" + " " + i] != "请选择" && collection["电阻值" + i] != "")
                    {
                        string unit = collection["电阻值单位" + " " + i];
                        double value = double.Parse(collection["电阻值" + i]);
                        dcResistance.dzz = ResistanceUnitConversion(unit, value);
                    }
                    else if (collection["电阻值" + i] == "" && collection["电阻值单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["电阻值" + i] != "" && collection["电阻值单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["电阻公差值单位" + " " + i] != "请选择" && collection["电阻公差值" + i] != "")
                    {
                        string unit = collection["电阻公差值单位" + " " + i];
                        double value = double.Parse(collection["电阻公差值" + i]);
                        dcResistance.dzgcz = ResistanceUnitConversion(unit, value);
                    }
                    else if (collection["电阻公差值" + i] == "" && collection["电阻公差值单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["电阻公差值" + i] != "" && collection["电阻公差值单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["电阻小于值单位" + " " + i] != "请选择" && collection["电阻小于值" + i]!="")
                    {
                        string unit = collection["电阻小于值单位" + " " + i];
                        double value = double.Parse(collection["电阻小于值" + i]);
                        dcResistance.dzxyz = ResistanceUnitConversion(unit, value);
                    }
                    else if (collection["电阻小于值" + i] == "" && collection["电阻小于值单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["电阻小于值" + i] != "" && collection["电阻小于值单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    dcResistance.dzbz = collection["电阻备注" + i];
                    if (id != -1 && collection["直流电阻id" + i] != null)
                    {
                        dcResistance.Id = int.Parse(collection["直流电阻id" + i]);
                        dcResistance.IgnitionID = id;
                        list1.Add(dcResistance.Id);
                        ignition.DcResistances.Add(dcResistance);
                    }
                    else
                    {
                        dcResistance.IgnitionID = id;
                        updateIgnition.DcResistances.Add(dcResistance);
                    }
                    if (id == -1)
                        ignition.DcResistances.Add(dcResistance);
                }
            }
            if (id != -1)
            {
                foreach (var dr in dc)
                    list2.Add(dr.Id);
                foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
                {
                    DcResistance model = new DcResistance();
                    model.Id = dr;
                    delect.DcResistances.Add(model);
                }
            }
        }

        //添加直流电阻
        private void AddDcResistance()
        {
            foreach (var dr in updateIgnition.DcResistances)
                dbDrive.Insert(dr);
        }

        //删除直流电阻
        private void DelectDcResistance()
        {
            foreach (var dr in delect.DcResistances)
                dbDrive.Delete(dr);
        }

        //发火条件
        private void AddIgnitionConditions(FormCollection collection, Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            if (collection["发火条件"] != null)
            {
                string[] count = collection["发火条件"].Split(',');
                foreach (var i in count)
                {
                    IgnitionCondition ignitionCondition = new IgnitionCondition();
                    if (collection["桥个数" + i] != "")
                    {
                        try
                        {
                            ignitionCondition.qgs = int.Parse(collection["桥个数" + i]);
                        }
                        catch (Exception)
                        {
                            IsInt = true;
                            return;
                        }
                    }
                    if (collection["发火电压" + i] != "")
                        ignitionCondition.fhdy = double.Parse(collection["发火电压" + i]);
                    if (collection["发火电压上限" + i] != "" && collection["发火电压下限" + i] != "")
                    {
                        ignitionCondition.fhdysx = double.Parse(collection["发火电压上限" + i]);
                        ignitionCondition.fhdyxx = double.Parse(collection["发火电压下限" + i]);
                        if (ignitionCondition.fhdysx < ignitionCondition.fhdyxx)
                        {
                            Isscope = true;
                            return;
                        }
                    }
                    if (collection["发火电容单位" + " " + i] != "请选择" && collection["发火电容" + i]!= "")
                    {
                        string unit = collection["发火电容单位" + " " + i];
                        double value = double.Parse(collection["发火电容" + i]);
                        ignitionCondition.fhdr = CapacitanceUnitConversion(unit, value);
                    }
                    else if (collection["发火电容" + i] == "" && collection["发火电容单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["发火电容" + i] != "" && collection["发火电容单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    ignitionCondition.fhdybz = collection["电压发火备注" + i];
                    if (collection["发火电流单位" + " " + i] != "请选择" && collection["发火电流" + i] != "")
                    {
                        string unit = collection["发火电流单位" + " " + i];
                        double value = double.Parse(collection["发火电流" + i]);
                        ignitionCondition.fhdl = CurrentUnitConversion(unit, value);
                    }
                    else if (collection["发火电流" + i] == "" && collection["发火电流单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["发火电流" + i] != "" && collection["发火电流单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["发火电流上限单位" + " " + i] != "请选择" && collection["发火电流下限单位" + " " + i] != "请选择" && collection["发火电流上限" + i] != "" && collection["发火电流下限" + i] != "")
                    {
                        string unit = collection["发火电流上限单位" + " " + i];
                        double value = double.Parse(collection["发火电流上限" + i]);
                        ignitionCondition.fhdlsx = CurrentUnitConversion(unit, value);
                        string unit2 = collection["发火电流下限单位" + " " + i];
                        double value2 = double.Parse(collection["发火电流下限" + i]);
                        ignitionCondition.fhdlxx = CurrentUnitConversion(unit2, value2);
                        if (ignitionCondition.fhdlsx < ignitionCondition.fhdlxx)
                        {
                            Isscope = true;
                            return;
                        }
                    }
                    else if (collection["发火电流上限单位" + " " + i] == "请选择" && collection["发火电流下限单位" + " " + i] == "请选择" && collection["发火电流上限" + i] == "" && collection["发火电流下限" + i] == "")
                    { }
                    else
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["发火电流时间单位" + " " + i] != "请选择" && collection["发火电流时间" + i]!= "")
                    {
                        string unit = collection["发火电流时间单位" + " " + i];
                        double value = double.Parse(collection["发火电流时间" + i]);
                        ignitionCondition.fhdlss = TimeUnitConversion(unit, value);
                    }
                    else if (collection["发火电流时间" + i] == "" && collection["发火电流时间单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["发火电流时间" + i] != "" && collection["发火电流时间单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    ignitionCondition.dlfhbz = collection["电流发火备注" + i];
                    if (collection["锤重单位" + " " + i] != "请选择" && collection["锤重" + i]!="")
                    {
                        string unit = collection["锤重单位" + " " + i];
                        double value = double.Parse(collection["锤重" + i]);
                        ignitionCondition.cz = WeightUnitConversion(unit, value);
                    }
                    else if (collection["锤重" + i] == "" && collection["锤重单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["锤重" + i] != "" && collection["锤重单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["落高单位" + " " + i] != "请选择" && collection["落高" + i]!="")
                    {
                        string unit = collection["落高单位" + " " + i];
                        double value = double.Parse(collection["落高" + i]);
                        ignitionCondition.lg = LenghtUnitConversion(unit, value);
                    }
                    else if (collection["落高" + i] == "" && collection["落高单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["落高" + i] != "" && collection["落高单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["击针刺激量" + i] != "")
                        ignitionCondition.jzcjl = double.Parse(collection["击针刺激量" + i]);
                    if (collection["击针力上限" + i] != "" && collection["击针力下限" + i] != "")
                    {
                        ignitionCondition.jzlsx = double.Parse(collection["击针力上限" + i]);
                        ignitionCondition.jzlxx = double.Parse(collection["击针力下限" + i]);
                        if (ignitionCondition.jzlsx < ignitionCondition.jzlxx)
                            Isscope = true;
                    }
                    if (collection["击针突出量上限" + i] != "" && collection["击针突出量下限" + i] != "")
                    {
                        ignitionCondition.jztclsx = double.Parse(collection["击针突出量上限" + i]);
                        ignitionCondition.jztclxx = double.Parse(collection["击针突出量下限" + i]);
                        if (ignitionCondition.jztclsx < ignitionCondition.jztclxx)
                        {
                            Isscope = true;
                            return;
                        }
                    }
                    if (collection["弹簧高度" + i] != "")
                        ignitionCondition.thgd = double.Parse(collection["弹簧高度" + i]);
                    if (collection["抗力" + i] != "")
                        ignitionCondition.kl = double.Parse(collection["抗力" + i]);
                    ignitionCondition.jxfhbz = collection["机械发火备注" + i];
                    if (collection["能量单位" + " " + i] != "请选择" && collection["能量" + i]!="")
                    {
                        string unit = collection["能量单位" + " " + i];
                        double value = double.Parse(collection["能量" + i]);
                        ignitionCondition.nl = EnergyUnitConversion(unit, value);
                    }
                    else if (collection["能量" + i] == "" && collection["能量单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["能量" + i] != "" && collection["能量单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (id != -1 && collection["发火条件id" + i] != null)
                    {
                        ignitionCondition.Id = int.Parse(collection["发火条件id" + i]);
                        ignitionCondition.IgnitionID = id;
                        list1.Add(ignitionCondition.Id);
                        ignition.IgnitionConditions.Add(ignitionCondition);
                    }
                    else
                    {
                        ignitionCondition.IgnitionID = id;
                        updateIgnition.IgnitionConditions.Add(ignitionCondition);
                    }
                    if (id == -1)
                        ignition.IgnitionConditions.Add(ignitionCondition);
                }
            }
            if (id != -1)
            {
                foreach (var dr in ign)
                    list2.Add(dr.Id);
                foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
                {
                    IgnitionCondition model = new IgnitionCondition();
                    model.Id = dr;
                    delect.IgnitionConditions.Add(model);
                }
            }
        }

        //添加直流电阻
        private void AddIgnitionCondition()
        {
            foreach (var dr in updateIgnition.IgnitionConditions)
                dbDrive.Insert(dr);
        }

        //删除直流电阻
        private void DelectIgnitionCondition()
        {
            foreach (var dr in delect.IgnitionConditions)
                dbDrive.Delete(dr);
        }

        //延期时间
        private void AddDelayTimes(FormCollection collection, Ignition ignition,int id)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            if (collection["延期时间"] != null)
            {
                string[] count = collection["延期时间"].Split(',');
                foreach (var i in count)
                {
                    DelayTime delayTime = new DelayTime();
                    if (collection["温度条件" + i] != "")
                        delayTime.wdtj = double.Parse(collection["温度条件" + i]);
                    if (collection["延期时间上限单位" + " " + i] != "请选择" && collection["延期时间下限单位" + " " + i] != "请选择" && collection["延期时间上限" + i] != "" && collection["延期时间下限" + i] != "")
                    {
                        string unit = collection["延期时间上限单位" + " " + i];
                        double value = double.Parse(collection["延期时间上限" + i]);
                        delayTime.yqsjsx = TimeUnitConversion(unit, value);
                        string unit2 = collection["延期时间下限单位" + " " + i];
                        double value2 = double.Parse(collection["延期时间下限" + i]);
                        delayTime.yqsjxx = TimeUnitConversion(unit2, value2);
                        if (delayTime.yqsjsx < delayTime.yqsjxx)
                        {
                            Isscope = true;
                            return;
                        }
                    }
                    else if (collection["延期时间上限单位" + " " + i] == "请选择" && collection["延期时间下限单位" + " " + i] == "请选择" && collection["延期时间上限" + i] == "" && collection["延期时间下限" + i] == "")
                    { }
                    else
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    if (collection["延期时间值单位" + " " + i] != "请选择" && collection["延期时间值" + i]!="")
                    {
                        string unit = collection["延期时间值单位" + " " + i];
                        double value = double.Parse(collection["延期时间值" + i]);
                        delayTime.yqsjz = TimeUnitConversion(unit, value);
                    }
                    else if (collection["延期时间值" + i] == "" && collection["延期时间值单位" + " " + i] != "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    else if (collection["延期时间值" + i] != "" && collection["延期时间值单位" + " " + i] == "请选择")
                    {
                        IsUnitvalue = true;
                        return;
                    }
                    delayTime.yqsjbz = collection["延期时间备注" + i];
                    if (id != -1 && collection["延期时间id" + i] != null)
                    {
                        delayTime.Id = int.Parse(collection["延期时间id" + i]);
                        delayTime.IgnitionID = id;
                        list1.Add(delayTime.Id);
                        ignition.DelayTimes.Add(delayTime);
                    }
                    else
                    {
                        delayTime.IgnitionID = id;
                        updateIgnition.DelayTimes.Add(delayTime);
                    }
                    if (id == -1)
                        ignition.DelayTimes.Add(delayTime);
                }
            }
            if (id != -1)
            {
                foreach (var dr in delay)
                    list2.Add(dr.Id);
                foreach (var dr in list1.Union(list2).Except(list1.Intersect(list2)))
                {
                    DelayTime model = new DelayTime();
                    model.Id = dr;
                    delect.DelayTimes.Add(model);
                }
            }
        }

        //添加延期时间
        private void AddDelay()
        {
            foreach (var dr in updateIgnition.DelayTimes)
                dbDrive.Insert(dr);
        }

        //删除延期时间
        private void DelectDelay()
        {
            foreach (var dr in delect.DelayTimes)
                dbDrive.Delete(dr);
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
        [HttpPost]
        public JsonResult DeleteInformation(int IgnitionId)
        {
            Ignition ignition = new Ignition();
            ignition.IgnitionId = IgnitionId;
            return Json(dbDrive.Delete(ignition));
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