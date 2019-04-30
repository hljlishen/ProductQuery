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
            try
            {
                db.User.Attach(user);
                db.User.Remove(user);
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
    }
}