using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public class Current : IMeasurementConverter
    {
        public Current(string measurement) : base(measurement)
        {
        }

        public override double ToStandardValue(double value)
        {
            double mA = -1;
            switch (measurement)
            {
                case "mA":
                    mA = value;
                    break;
                case "A":
                    mA = value * 1000;
                    break;
            }
            return mA;
        }
    }
}