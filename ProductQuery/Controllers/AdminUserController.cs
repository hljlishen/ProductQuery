using ProductQuery.Controllers.Errors;
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
        ValidationErrors errors = new ValidationErrors();

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
        public ActionResult User_delete(int userid)
        {
            User user = new User();
            user.id = userid;
            dbDrive.Delete(user);
            return RedirectToAction("User_list", "AdminUser");
        }
    }
}