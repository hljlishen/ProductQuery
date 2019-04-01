using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public class Capacitance : IMeasurementConverter
    {
        public Capacitance(string measurement) : base(measurement)
        {
        }

        public override double ToStandardValue(double value)
        {
            double μf = -1;
            switch (measurement)
            {
                case "pf":
                    μf = value / 1000000;
                    break;
                case "μf":
                    μf = value;
                    break;
            }
            return μf;
        }
    }
}