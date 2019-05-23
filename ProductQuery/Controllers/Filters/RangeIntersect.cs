using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Filters
{
    public class RangeIntersect : _Filter
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
            double valuemax = (double)GetPropertyValue(obj, fieldName + "sx");
            double valuemin = (double)GetPropertyValue(obj, fieldName + "xx");

            double max = MeasurementConverter == null ? rangeMax : MeasurementConverter.ToStandardValue(rangeMax);
            double min = MeasurementConverter == null ? rangeMin : MeasurementConverter.ToStandardValue(rangeMin);
            if (valuemax == max || valuemin == min) return true;
            return !(valuemin >= max || valuemax <= min);
        }
    }
}