using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Filters
{
    public class ListPropertyDecorator : Filter
    {
        string propertyName;
        Filter filter;

        public ListPropertyDecorator(string propertyName, Filter filter)
        {
            this.propertyName = propertyName;
            this.filter = filter;
        }

        public override bool IsPass(object obj)
        {
            object list = GetPropertyValue(obj, propertyName);

            Type objType = list.GetType();
            int count = Convert.ToInt32(objType.GetProperty("Count").GetValue(list, null));

            for (int i = 0; i < count; i++)
            {
                object listItem = objType.GetProperty("Item").GetValue(list, new object[] { i });
                if (filter.IsPass(listItem)) return true;
            }

            return false;
        }
    }
}