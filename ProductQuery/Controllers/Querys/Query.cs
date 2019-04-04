using ProductQuery.Controllers.Filters;
using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Querys
{
    public class Query
    {
        List<_Filter> filter;

        public Query(List<_Filter> filter)
        {
            this.filter = filter;
        }

        public List<Ignition> Process()
        {
            List<Ignition> ret = new List<Ignition>();
            List<Ignition> ignitions = GetAllIgnition();
            foreach (var p in ignitions)
            {
                if (IsMetAllFilter(p))
                    ret.Add(p);
            }
            return ret;
        }

        private bool IsMetAllFilter(Ignition ignition)
        {
            foreach (var f in filter)
            {
                if (!f.IsPass(ignition)) return false;
            }
            return true;
        }

        private List<Ignition> GetAllIgnition()
        {
            ProductQueryDB db = new ProductQueryDB();
            List<Ignition> ignitions = new List<Ignition>();
            ignitions = db.Ignition.ToList();
            return ignitions;
        }
    }
}