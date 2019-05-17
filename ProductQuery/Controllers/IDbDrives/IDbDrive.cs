using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IDbDrives
{
    public abstract class IDbDrive
    {
        public abstract bool Insert(Ignition ignition);
        public abstract bool Insert(User user);

        public abstract bool Delete(Ignition ignition);
        public abstract bool Delete(Picture picture);
        public abstract bool Delete(CableDiameter cableDiameter);
        public abstract bool Delete(DcResistance dcResistance);
        public abstract bool Delete(DelayTime delayTime);
        public abstract bool Delete(IgnitionCondition ignitionCondition);
        public abstract bool Delete(InterfaceInformation interfaceInformation);
        public abstract bool Delete(SpeedDetonation speedDetonation);
        public abstract bool Delete(Conventional conventional);
        public abstract bool Delete(User user);

        public abstract bool Udpdate(Ignition ignition);
        public abstract bool Udpdate(User user);

        public abstract List<Ignition> GetAllIgnitions();
        public abstract List<User> GetAllUsers();

        public abstract Ignition FindIgnition(int ignitionid);
        public abstract User FindUser(int userid);

        public abstract List<User> QueryUsers(string username);

        public abstract User AdminLogin(User user);

        public abstract bool Insert(WebsiteStatistical websiteStatistical);
        public abstract bool UdpdateQueryNumber();
        public abstract bool UdpdateAccessNumber();
        public abstract bool FindWebsiteStatistical();
        public abstract List<WebsiteStatistical> GetAllWebsiteStatistical();
    }
}