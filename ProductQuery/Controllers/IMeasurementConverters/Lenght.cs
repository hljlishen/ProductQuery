using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public class Lenght : IMeasurementConverter
    {
        public Lenght(string measurement) : base(measurement)
        {
        }

        public override double ToStandardValue(double value)
        {
            double mm = -1;
            switch (measurement)
            {
                case "mm":
                    mm = value;
                    break;
                case "cm":
                    mm = value * 10;
                    break;
                case "m":
                    mm = value * 1000;
                    break;
            }
            return mm;
        }
    }
}