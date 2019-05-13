using ProductQuery.Controllers.IDbDrives;
using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.SiteStatistical
{
    public class WebClickNumber
    {
        IDbDrive dbDrive = new LingImp();

        public void SaveQueryNumber()
        {
            if (!dbDrive.FindWebsiteStatistical())
            {
                WebsiteStatistical websiteStatistical = new WebsiteStatistical();
                websiteStatistical.Data = DateTime.Now.Date;
                websiteStatistical.QueryNumber = 1;
                websiteStatistical.AccessNumber = 0;
                dbDrive.Insert(websiteStatistical);
                return;
            }
            dbDrive.UdpdateQueryNumber();
        }

        public void SaveAccessNumber()
        {
            if (!dbDrive.FindWebsiteStatistical())
            {
                WebsiteStatistical websiteStatistical = new WebsiteStatistical();
                websiteStatistical.Data = DateTime.Now.Date;
                websiteStatistical.QueryNumber = 0;
                websiteStatistical.AccessNumber = 1;
                dbDrive.Insert(websiteStatistical);
                return;
            }
            dbDrive.UdpdateAccessNumber();
        }

        public int QueryWebClickNumber()
        {
            int ClickNumber = 0;
            List<WebsiteStatistical> websites =  dbDrive.GetAllWebsiteStatistical();

            return ClickNumber;
        }
    }
}