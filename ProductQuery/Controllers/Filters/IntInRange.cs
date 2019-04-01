﻿using ProductQuery.Models;

namespace ProductQuery.Controllers.Filters
{
    public class IntInRange : Filter
    {
        private int rangeMin;
        private int rangeMax;
        private string fieldName;

        public IntInRange(string fieldName, int rangeMin, int rangeMax)
        {
            this.fieldName = fieldName;
            this.rangeMax = rangeMax;
            this.rangeMin = rangeMin;
        }

        public override bool IsPass(object obj)
        {
            int value = (int)GetPropertyValue(obj, fieldName);

            int max = (int)(MeasurementConverter == null ? rangeMax : MeasurementConverter.ToStandardValue(rangeMax));
            int min = (int)(MeasurementConverter == null ? rangeMin : MeasurementConverter.ToStandardValue(rangeMin));
            return value >= min && value <= max;
        }
    }
}
