using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public class Resistance : IMeasurementConverter
    {
        public Resistance(string measurement) : base(measurement)
        {
        }

        public override double ToStandardValue(double value)
        {
            double Ω = -1;
            switch (measurement)
            {
                case "mΩ":
                    Ω = value / 1000;
                    break;
                case "Ω":
                    Ω = value;
                    break;
                case "kΩ":
                    Ω = value * 1000;
                    break;
                case "MΩ":
                    Ω = value * 1000000;
                    break;
            }
            return Ω;
        }
    }
}