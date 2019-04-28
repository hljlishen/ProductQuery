using ProductQuery.Controllers.Filters;
using ProductQuery.Controllers.IMeasurementConverters;
using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Querys
{
    public partial class SelectList
    {
        public string conditionFieldVal { get; set; }

        public string conditionOptionVal { get; set; }

        public string conditionValueVal { get; set; }

        public string conditionValueLeftVal { get; set; }

        public string conditionValueRightVal { get; set; }

        public string conditionValueUnitVal { get; set; }
    }

    public class Query
    {
        List<_Filter> filters;

        public Query(List<SelectList> selectLists)
        {
            if (selectLists.Any())
            {
                foreach (var item in selectLists)
                {
                    IMeasurementConverter measurementConverter = GetMeasurementConverter(item.conditionFieldVal,item.conditionValueUnitVal);
                    _Filter filter = Get_Filters(item.conditionFieldVal,item.conditionValueVal,item.conditionValueLeftVal,item.conditionValueRightVal);
                    filter.MeasurementConverter = measurementConverter;
                    filters.Add(filter);
                }
            }
        }


        private IMeasurementConverter GetMeasurementConverter(string FieldVal,string unit)
        {
            if(unit.Equals("")) return null;
            IMeasurementConverter measurementConverter = null;
            int laststr = FieldVal.LastIndexOf("-");
            string str = FieldVal.Substring(laststr + 1, FieldVal.Length);
            switch (str)
            {
                case "cd":
                    measurementConverter = new Lenght(unit);
                    return measurementConverter;
                case "zl":
                    measurementConverter = new Weight(unit);
                    return measurementConverter;
                case "sj":
                    measurementConverter = new Time(unit);
                    return measurementConverter;
                case "dz":
                    measurementConverter = new Resistance(unit);
                    return measurementConverter;
                case "nl":
                    measurementConverter = new Energy(unit);
                    return measurementConverter;
                case "dl":
                    measurementConverter = new Current(unit);
                    return measurementConverter;
                case "dr":
                    measurementConverter = new Capacitance(unit);
                    return measurementConverter;
            }
            return null;
        }

        private _Filter Get_Filters(string FieldVal,string val ,string min, string max)
        {
            _Filter filter = null;
            int friststr = FieldVal.IndexOf("-");
            int lasttstr = FieldVal.LastIndexOf("-");
            string strzibiao = FieldVal.Substring(0, friststr - 1);
            string strzhubiao = FieldVal.Substring(friststr + 1, lasttstr-1);

            if (strzhubiao == "yzrq" || strzhubiao == "dxrq" || strzhubiao == "gydx")
            {
                DateTime dt1 = Convert.ToDateTime(min);
                DateTime dt2 = Convert.ToDateTime(max);
                filter = new DateTimeInRange(strzhubiao, dt1, dt2);
                return filter;
            }

            if (strzibiao.Equals("0"))
            {
                filter = GetFilter(strzhubiao, val, min, max);
            }
            else if (!strzibiao.Equals("0"))
            {
                _Filter filter1 = GetFilter(strzhubiao, val, min, max);
                filter = new ListPropertyDecorator(strzibiao, filter1);
            }
            return filter;
        }

        private _Filter GetFilter(string FieldVal, string val, string min, string max)
        {
            _Filter filter = null;
            if (val.Equals(""))
            {
                double _min = double.Parse(min);
                double _max = double.Parse(max);
                filter = new DoubleInRange(FieldVal, _min, _max);
                return filter;
            }
            else if (!val.Equals(""))
            {
                filter = new StringLike(FieldVal, val);
                return filter;
            }
            return filter;
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
            foreach (var f in filters)
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