using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Filters
{
    public class DateTimeInRange : Filter
    {
        private DateTime rangeMin;
        private DateTime rangeMax;
        private string fieldName;

        public DateTimeInRange(string fieldName, DateTime rangeMin, DateTime rangeMax)
        {
            this.fieldName = fieldName;
            this.rangeMax = rangeMax;
            this.rangeMin = rangeMin;
        }

        public override bool IsPass(object obj)
        {
            DateTime value = (DateTime)GetPropertyValue(obj, fieldName);
            return value.CompareTo(rangeMin) >= 0 && value.CompareTo(rangeMax) <= 0;
        }
    }
}