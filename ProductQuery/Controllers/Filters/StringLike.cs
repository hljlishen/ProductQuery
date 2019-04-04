using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.Controllers.Filters
{
    public class StringLike : _Filter
    {
        private string str;
        private string fieldName;

        public StringLike(string fieldName, string str)
        {
            this.fieldName = fieldName;
            this.str = str;
        }

        public override bool IsPass(object obj)
        {
            string value = (string)GetPropertyValue(obj, fieldName);

            return value.Contains(str);
        }
    }
}