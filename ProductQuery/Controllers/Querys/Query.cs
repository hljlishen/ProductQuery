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
        List<_Filter> filters = new List<_Filter>();

        public Query(List<SelectList> selectLists)
        {
            if (selectLists.Any())
            {
                foreach (var item in selectLists)
                {
                    _Filter filter = Get_Filters(item.conditionFieldVal,item.conditionValueVal,item.conditionValueLeftVal,item.conditionValueRightVal, item.conditionValueUnitVal);
                    filters.Add(filter);
                }
            }
        }


        private IMeasurementConverter GetMeasurementConverter(string UnitType, string unit)
        {
            if(unit.Equals("")) return null;
            IMeasurementConverter measurementConverter = null;
            switch (UnitType)
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


        private _Filter Get_Filters(string FieldVal,string val ,string min, string max,string unit)
        {
            _Filter filter = null;
            String[] StrArray = StringParsing(FieldVal);
            string ChildTableName = StrArray[0];
            string FieldName = StrArray[1];
            string UnitType = StrArray[2];
            string QueryType = StrArray[3];

            if (ChildTableName.Equals("o"))
            {
                filter = GetFilter(FieldName, val, min, max, QueryType);
                filter.MeasurementConverter = GetMeasurementConverter(UnitType, unit);
            }
            else if (!ChildTableName.Equals("o"))
            {
                _Filter filter1 = GetFilter(FieldName, val, min, max, QueryType);
                filter1.MeasurementConverter = GetMeasurementConverter(UnitType, unit);
                filter = new ListPropertyDecorator(ChildTableName, filter1);
            }
            return filter;
        }

        //解析文件名
        private String[] StringParsing(string FieldVal)
        {
            String[] StrArray = FieldVal.Split('-');
            return StrArray;
        }
        
        //获取查询类型
        private _Filter GetFilter(string FieldName, string val, string min, string max, string QueryType)
        {
            _Filter filter = null;
            if (QueryType.Equals("DateTimeInRange"))
            {
                DateTime dtmin = Convert.ToDateTime(min);
                DateTime dtmax = Convert.ToDateTime(max);
                filter = new DateTimeInRange(FieldName, dtmin, dtmax);
                return filter;
            }
            if (QueryType.Equals("DoubleInRange"))
            {
                double _min = double.Parse(min);
                double _max = double.Parse(max);
                filter = new DoubleInRange(FieldName, _min, _max);
                return filter;
            }
            if (QueryType.Equals("IntInRange"))
            {
                int _min = int.Parse(min);
                int _max = int.Parse(max);
                filter = new IntInRange(FieldName, _min, _max);
                return filter;
            }
            if (QueryType.Equals("RangeIntersect"))
            {
                double _min = double.Parse(min);
                double _max = double.Parse(max);
                filter = new RangeIntersect(FieldName, _min, _max);
                return filter;
            }
            if (QueryType.Equals("StringLike"))
            {
                filter = new StringLike(FieldName, val);
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