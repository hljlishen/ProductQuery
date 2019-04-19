using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public class Weight : IMeasurementConverter
    {
        public Weight(string measurement) : base(measurement)
        {
        }

        public override double ToStandardValue(double value)
        {
            double g = -1;
            switch (measurement)
            {
                case "g":
                    g = value;
                    break;
                case "kg":
                    g = value * 1000;
                    break;
            }
            return g;
        }
    }
}