using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public class Time : IMeasurementConverter
    {
        public Time(string measurement) : base(measurement)
        {
        }

        public override double ToStandardValue(double value)
        {
            double ms = -1;
            switch (measurement)
            {
                case "ns":
                    ms = value / 1000000;
                    break;
                case "μs":
                    ms = value / 1000;
                    break;
                case "ms":
                    ms = value;
                    break;
                case "s":
                    ms = value * 1000;
                    break;
                case "min":
                    ms = value * 60000;
                    break;
            }
            return ms;
        }
    }
}