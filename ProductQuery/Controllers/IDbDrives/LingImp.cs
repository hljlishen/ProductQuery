using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IDbDrives
{
    public class LingImp : IDbDrive
    {
        ProductQueryDB db = new ProductQueryDB();
        public override bool Delete(object value)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(object value)
        {
            throw new NotImplementedException();
        }

        public override bool Select(object value)
        {
            throw new NotImplementedException();
        }

        public override bool Udpdate(object value)
        {
            throw new NotImplementedException();
        }
    }
}