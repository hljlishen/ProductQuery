using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Filters
{
    public class DoubleInRange : Filter
    {
        private double rangeMin;
        private double rangeMax;
        private string fieldName;

        public DoubleInRange(string fieldName, double rangeMin, double rangeMax)
        {
            this.fieldName = fieldName;
            this.rangeMax = rangeMax;
            this.rangeMin = rangeMin;
        }

        public override bool IsPass(object obj)
        {
            double value = (double)GetPropertyValue(obj, fieldName);

            double max = MeasurementConverter == null ? rangeMax : MeasurementConverter.ToStandardValue(rangeMax);
            double min = MeasurementConverter == null ? rangeMin : MeasurementConverter.ToStandardValue(rangeMin);
            return value >= min && value <= max;
        }
    }
}