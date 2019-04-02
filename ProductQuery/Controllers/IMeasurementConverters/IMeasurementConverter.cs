using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.IMeasurementConverters
{
    public abstract class IMeasurementConverter
    {
        public string measurement;
        public IMeasurementConverter(string measurement) => this.measurement = measurement;
        public abstract double ToStandardValue(double value);
    }
}