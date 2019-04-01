using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ProductQuery.Models;

namespace ProductQuery.Controllers.Filters
{
    public class GlobalStringLike : Filter
    {
        private string likeString;

        public GlobalStringLike(string likeString)
        {
            this.likeString = likeString;
        }

        public override bool IsPass(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach(var pro in properties)
            {
                if (pro.PropertyType != typeof(string)) continue;

                string content = (string)pro.GetValue(obj);

                if (string.IsNullOrEmpty(content)) continue;

                if (content.Contains(likeString))
                    return true;
            }
            return false;
        }
    }
}
