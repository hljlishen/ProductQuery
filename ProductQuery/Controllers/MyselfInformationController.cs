using ProductQuery.Controllers.IDbDrives;
using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductQuery.Controllers
{
    public class MyselfInformationController : Controller
    {
        IDbDrive dbDrive = new LingImp();

        public ActionResult User_myself(int userid)
        {
            User user = dbDrive.FindUser(userid);
            return View(user);
        }

        //打开用户更新页面
        [ValidateInput(false)]
        public ActionResult User_UpdatePassword(int userid)
        {
            User user = dbDrive.FindUser(userid);
            ViewData["oldpassword"] = user.password;
            return View(user);
        }
    }
}