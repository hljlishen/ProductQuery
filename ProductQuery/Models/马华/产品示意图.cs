using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class 产品示意图
    {
        public int imgId { get; set; }
        public int mainId { get; set; }
        public Image 产品图 { get; set; }
    }
}