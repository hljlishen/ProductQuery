using ProductQuery.Controllers.IDbDrives;
using ProductQuery.Models;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace ProductQuery.Controllers
{
    public class AdminUserController : Controller
    {
        IDbDrive dbDrive = new LingImp();

        public ActionResult User_list()
        {
            List<User> users = dbDrive.GetAllUsers();
            return View(users);
        }

        //打开用户添加页面
        [ValidateInput(false)]
        public ActionResult User_add()
        {
            return View();
        }

        //添加用户
        [HttpPost]
        public JsonResult User_add(User user)
        {
            return Json(dbDrive.Insert(user));
        }

        //查询用户
        public ActionResult User_query(string username)
        {
            return View("User_list", dbDrive.QueryUsers(username));
        }

        //打开用户详情页面
        [ValidateInput(false)]
        public ActionResult User_details(int userid)
        {
            User user = dbDrive.FindUser(userid);
            return View(user);
        }

        //打开用户更新页面
        [ValidateInput(false)]
        public ActionResult User_update(int userid)
        {
            User user = dbDrive.FindUser(userid);
            return View(user);
        }

        //更新用户
        [HttpPost]
        public JsonResult User_update(User user)
        {
            return Json(dbDrive.Udpdate(user));
        }

        //删除用户
        [HttpPost]
        public JsonResult User_delete(int userid)
        {
            User user = new User();
            user.id = userid;
            return Json(dbDrive.Delete(user));
        }

        //重置用户密码
        [HttpPost]
        public JsonResult User_resetPassword(int userid)
        {
            User user = dbDrive.FindUser(userid);
            user.password = "admin";
            return Json(dbDrive.Udpdate(user));
        }
    }
}