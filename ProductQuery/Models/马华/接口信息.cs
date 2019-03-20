using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class 接口信息
    {
        public int interfaceId { get; set; }
        public int mainId { get; set; }
        public double 螺纹 { get; set; }
        public double 螺距 { get; set; }
        public string 公差 { get; set; }
        public double 长度 { get; set; }
    }
}