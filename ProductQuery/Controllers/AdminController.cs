using ProductQuery.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProductQuery.Controllers
{
    public class AdminController : Controller
    {
        ProductQueryDB db = new ProductQueryDB();

        public ActionResult AdministratorPage()
        {
            return View();
        }

        public ActionResult AdminLongin()
        {
            return View();
        }
        
        //管理员登录页面
        [HttpPost]
        public ActionResult AdminLongin(User user)
        {
            db.Users.ToList();
            db.Ignition.ToList();
            db.CableDiameter.ToList();
            db.Conventional.ToList();
            db.InterfaceInformation.ToList();
            db.DelayTime.ToList();
            db.IgnitionCondition.ToList();
            db.Picture.ToList();
            db.SpeedDetonation.ToList();
            var item = db.Users.FirstOrDefault(u => u.name == user.name && u.password == user.password);
            if (item!=null)
            {
                Session["User"] = item;
                return RedirectToAction("Instrument", "Admin");
            }

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

        public ActionResult Dictionary()
        {
            return View();
        }

        public ActionResult AdminUser()
        {
            return View();
        }
    }
}