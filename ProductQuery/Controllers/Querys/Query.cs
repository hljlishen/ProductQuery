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
        List<Filter> filter;


        List<Ignition> Process(List<Ignition> ignitions)
        {
            List<Ignition> ret = new List<Ignition>();

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
    }
}