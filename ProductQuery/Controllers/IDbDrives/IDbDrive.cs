using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IDbDrives
{
    public abstract class IDbDrive
    {
        public abstract bool Insert(object value);
        public abstract bool Delete(object value);
        public abstract bool Udpdate(object value);
        public abstract bool Select(object value);
    }
}