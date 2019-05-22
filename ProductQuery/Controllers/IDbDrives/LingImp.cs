using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IDbDrives
{
    public class LingImp : IDbDrive
    {
        ProductQueryDB db = new ProductQueryDB();

        public override bool Delete(Ignition ignition)
        {
            Ignition modle = db.Ignition.FirstOrDefault(m => m.IgnitionId == ignition.IgnitionId);
            if (modle == null)
            {
                return false;
            }
            try
            {
                db.Ignition.Attach(ignition);
                db.Ignition.Remove(ignition);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(User user)
        {
            User modle = db.User.FirstOrDefault(m => m.id == user.id);
            if (modle == null)
            {
                return false;
            }
            try
            {
                //db.User.Attach(user);
                db.User.Remove(modle);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(Ignition ignition)
        {
            try
            {
                db.Ignition.Add(ignition);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(User user)
        {
            try
            {
                db.User.Add(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Udpdate(Ignition ignition)
        {
            try
            {
                db.Ignition.Attach(ignition);
                db.Entry(ignition).State = EntityState.Modified;
                foreach (var pic in ignition.Pictures)
                {
                    db.Picture.Attach(pic);
                    db.Entry(pic).State = EntityState.Modified;
                }
                foreach (var con in ignition.Conventionals) {
                    db.Conventional.Attach(con);
                    db.Entry(con).State = EntityState.Modified;
                }
                foreach (var cab in ignition.CableDiameters)
                {
                    db.CableDiameter.Attach(cab);
                    db.Entry(cab).State = EntityState.Modified;
                }
                foreach (var speed in ignition.SpeedDetonations)
                {
                    db.SpeedDetonation.Attach(speed);
                    db.Entry(speed).State = EntityState.Modified;
                }
                foreach (var inter in ignition.InterfaceInformations)
                {
                    db.InterfaceInformation.Attach(inter);
                    db.Entry(inter).State = EntityState.Modified;
                }
                foreach (var dc in ignition.DcResistances)
                {
                    db.DcResistance.Attach(dc);
                    db.Entry(dc).State = EntityState.Modified;
                }
                foreach (var ign in ignition.IgnitionConditions)
                {
                    db.IgnitionCondition.Attach(ign);
                    db.Entry(ign).State = EntityState.Modified;
                }
                foreach (var delay in ignition.DelayTimes)
                {
                    db.DelayTime.Attach(delay);
                    db.Entry(delay).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Udpdate(User user)
        {
            try
            {
                db.User.Attach(user);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override List<Ignition> GetAllIgnitions()
        {
            List<Ignition> ignitions = new List<Ignition>();
            ignitions = db.Ignition.ToList();
            return ignitions;
        }

        public override List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            users = db.User.ToList();
            return users;
        }

        public override Ignition FindIgnition(int ignitionid)
        {
            return db.Ignition.Find(ignitionid);
        }

        public override User FindUser(int userid)
        {
            return db.User.Find(userid);
        }

        public override User AdminLogin(User user)
        {
            User loginuser = db.User.FirstOrDefault(u => u.name == user.name && u.password == user.password);
            return loginuser;
        }

        public override List<User> QueryUsers(string username)
        {
            List<User> users = new List<User>();
            users = db.User.Where(m => m.name.Contains(username)).ToList();
            return users;
        }

        public override List<User> AccurateQueryUsers(string username)
        {
            List<User> users = new List<User>();
            users = db.User.Where(m => m.name == username).ToList();
            return users;
        }

        public override bool Insert(WebsiteStatistical websiteStatistical)
        {
            try
            {
                db.WebsiteStatistical.Add(websiteStatistical);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool UdpdateQueryNumber()
        {
            WebsiteStatistical websiteStatistical = TodayWeb();
            websiteStatistical.QueryNumber++;
            try
            {
                db.WebsiteStatistical.Attach(websiteStatistical);
                db.Entry(websiteStatistical).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool UdpdateAccessNumber()
        {
            WebsiteStatistical websiteStatistical = TodayWeb();
            websiteStatistical.AccessNumber++;
            try
            {
                db.WebsiteStatistical.Attach(websiteStatistical);
                db.Entry(websiteStatistical).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private WebsiteStatistical TodayWeb()
        {
            DateTime dateTime = DateTime.Now.Date;
            List<WebsiteStatistical> websiteStatisticals = new List<WebsiteStatistical>();
            websiteStatisticals = db.WebsiteStatistical.Where(m => DbFunctions.DiffDays(m.Data, dateTime) == 0).ToList();
            WebsiteStatistical websiteStatistical = new WebsiteStatistical();
            websiteStatistical = websiteStatisticals[0];
            return websiteStatistical;
        }

        public override bool FindWebsiteStatistical()
        {
            if(GetAllWebsiteStatistical().Count == 0) return false;
            WebsiteStatistical website = GetAllWebsiteStatistical()[GetAllWebsiteStatistical().Count-1];
            if (website.Data.Date == DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }

        public override List<WebsiteStatistical> GetAllWebsiteStatistical()
        {
            List<WebsiteStatistical> websiteStatisticals = new List<WebsiteStatistical>();
            websiteStatisticals = db.WebsiteStatistical.ToList();
            return websiteStatisticals;
        }

        public override bool Delete(Picture picture)
        {
            try
            {
                db.Picture.Attach(picture);
                db.Picture.Remove(picture);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(CableDiameter cableDiameter)
        {
            try
            {
                db.CableDiameter.Attach(cableDiameter);
                db.CableDiameter.Remove(cableDiameter);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(DcResistance dcResistance)
        {
            try
            {
                db.DcResistance.Attach(dcResistance);
                db.DcResistance.Remove(dcResistance);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(DelayTime delayTime)
        {
            try
            {
                db.DelayTime.Attach(delayTime);
                db.DelayTime.Remove(delayTime);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(IgnitionCondition ignitionCondition)
        {
            try
            {
                db.IgnitionCondition.Attach(ignitionCondition);
                db.IgnitionCondition.Remove(ignitionCondition);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(InterfaceInformation interfaceInformation)
        {
            try
            {
                db.InterfaceInformation.Attach(interfaceInformation);
                db.InterfaceInformation.Remove(interfaceInformation);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(SpeedDetonation speedDetonation)
        {
            try
            {
                db.SpeedDetonation.Attach(speedDetonation);
                db.SpeedDetonation.Remove(speedDetonation);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Delete(Conventional conventional)
        {
            try
            {
                db.Conventional.Attach(conventional);
                db.Conventional.Remove(conventional);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(Conventional conventional)
        {
            try
            {
                db.Conventional.Add(conventional);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(Picture picture)
        {
            try
            {
                db.Picture.Add(picture);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(CableDiameter cableDiameter)
        {
            try
            {
                db.CableDiameter.Add(cableDiameter);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(DcResistance dcResistance)
        {
            try
            {
                db.DcResistance.Add(dcResistance);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(DelayTime delayTime)
        {
            try
            {
                db.DelayTime.Add(delayTime);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(IgnitionCondition ignitionCondition)
        {
            try
            {
                db.IgnitionCondition.Add(ignitionCondition);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(InterfaceInformation interfaceInformation)
        {
            try
            {
                db.InterfaceInformation.Add(interfaceInformation);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Insert(SpeedDetonation speedDetonation)
        {
            try
            {
                db.SpeedDetonation.Add(speedDetonation);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}