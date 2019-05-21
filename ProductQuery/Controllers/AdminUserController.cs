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
            SelectList select = new SelectList(GetPermissionsList(), "Value", "Text");
            ViewBag.select = select;
            return View();
        }

        private List<SelectListItem> GetPermissionsList()
        {
            List<SelectListItem> itemList = new List<SelectListItem>();
            SelectListItem item0 = new SelectListItem()
            {
                Value = "一级管理员",
                Text = "一级管理员"
            };
            SelectListItem item1 = new SelectListItem()
            {
                Value = "二级管理员",
                Text = "二级管理员"
            };
            SelectListItem item2 = new SelectListItem()
            {
                Value = "三级管理员",
                Text = "三级管理员"
            };
            itemList.Add(item0);
            itemList.Add(item1);
            itemList.Add(item2);
            return itemList;
        }
        //添加用户
        [HttpPost]
        public JsonResult User_add(User user)
        {
            return Json(dbDrive.Insert(user));
        }

        //用户名查重
        [HttpPost]
        public JsonResult User_hasusername(string oldusername, string newusername)
        {
            if(oldusername.Equals(newusername)) return Json(true);
            List<User> userList = dbDrive.AccurateQueryUsers(newusername);
            if (userList != null && userList.Count > 0) return Json(false);
            return Json(true);
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
            SelectList select = new SelectList(GetPermissionsList(), "Value", "Text");
            ViewBag.select = select;
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