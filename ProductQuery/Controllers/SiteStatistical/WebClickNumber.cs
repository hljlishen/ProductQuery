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

        public Dictionary<string, int> GetNowWebClickNumber()
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            int querynumber = 0;
            int accessnumber = 0;
            List<WebsiteStatistical> websites = dbDrive.GetAllWebsiteStatistical();
            foreach (var item in websites)
            {
                querynumber += item.QueryNumber;
                accessnumber += item.AccessNumber;
            }
            keyValuePairs.Add("querynumber", querynumber);
            keyValuePairs.Add("accessnumber", accessnumber);
            keyValuePairs.Add("clicknumber", querynumber+ accessnumber);
            return keyValuePairs;
        }

        public int[] GetWebClickNumber(DateTime dateTime)
        {
            int January=0, February=0, March=0, April=0, May=0, June=0, July=0, August=0, September=0, October=0, November=0, December=0;
            List<WebsiteStatistical> websites = dbDrive.GetAllWebsiteStatistical();
            foreach (var item in websites)
            {
                if (item.Data.Year != dateTime.Year) continue;
                if (item.Data.Month == 1) January += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 2) February += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 3) March += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 4) April += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 5) May += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 6) June += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 7) July += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 8) August += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 9) September += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 10) October += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 11) November += item.QueryNumber + item.AccessNumber;
                if (item.Data.Month == 12) December += item.QueryNumber + item.AccessNumber;
            }
            int[] myArray = new int[12] { January, February, March, April, May, June, July, August, September, October, November, December };
            return myArray;
        }
    }
}