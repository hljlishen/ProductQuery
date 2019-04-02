using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Filters
{
    public class RangeIntersect : Filter
    {
        private double rangeMin;
        private double rangeMax;
        private string fieldName;

        public RangeIntersect(string fieldName, double rangeMin, double rangeMax)
        {
            this.fieldName = fieldName;
            this.rangeMax = rangeMax;
            this.rangeMin = rangeMin;
        }

        public override bool IsPass(object obj)
        {
            double valuemax = (double)GetPropertyValue(obj, fieldName + "上限");
            double valuemin = (double)GetPropertyValue(obj, fieldName + "下限");

            double max = MeasurementConverter == null ? rangeMax : MeasurementConverter.ToStandardValue(rangeMax);
            double min = MeasurementConverter == null ? rangeMin : MeasurementConverter.ToStandardValue(rangeMin);
            return !(valuemin >= max || valuemax <= min);
        }
    }
}