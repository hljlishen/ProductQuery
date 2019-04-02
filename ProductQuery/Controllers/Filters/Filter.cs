using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ProductQuery.Models;
using ProductQuery.Controllers.IMeasurementConverters;

namespace ProductQuery.Controllers.Filters
{
    public abstract class Filter
    {
        public IMeasurementConverter MeasurementConverter { get; set; } = null;

        public abstract bool IsPass(object obj);

        protected object GetPropertyValue(object obj, string propertyName)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(propertyName);
            return property.GetValue(obj);
        }
    }
}
