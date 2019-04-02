using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public class Energy : IMeasurementConverter
    {
        public Energy(string measurement) : base(measurement)
        {
        }

        public override double ToStandardValue(double value)
        {
            double J = -1;
            switch (measurement)
            {
                case "J":
                    J = value;
                    break;
                case "mJ":
                    J = value * 1000000;
                    break;
            }
            return J;
        }
    }
}