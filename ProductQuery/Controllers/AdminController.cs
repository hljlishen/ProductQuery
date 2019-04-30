﻿using ProductQuery.Controllers.IDbDrives;
using ProductQuery.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace ProductQuery.Controllers
{
    public class AdminController : Controller
    {
        IDbDrive dbDrive = new LingImp();

        public ActionResult AdministratorPage()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        //注销
        public ActionResult AdminLoginoff()
        {
            Session.Clear();
            return RedirectToAction("Instrument", "Admin");
        }

        //管理员登录页面
        [HttpPost]
        public ActionResult AdminLogin(User user)
        {
            User loginuser = dbDrive.AdminLogin(user);
            if (loginuser != null)
            {
                Session["User"] = loginuser;
                return RedirectToAction("Instrument", "Admin");
            }
            ModelState.AddModelError("","登陆信息错误，请重新输入！");
            return View();
        }

        public ActionResult AdminIndex()
        {

            return View();
        }

        public ActionResult Instrument()
        {
            return View();
        }

        public ActionResult IgnitionManagement()
        {
            return View();  
        }

        //添加点火装置页面
        public ActionResult AddIgnition()
        {
            return View();
        }

        //删除点火装置页面
        public ActionResult DeleteIgnition(int ignitionid)
        {
            Ignition ignition = new Ignition();
            ignition.IgnitionId = ignitionid;
            dbDrive.Delete(ignition);
            return View();
        }

        public ActionResult Dictionary()
        {
            return View();
        }
    }
}