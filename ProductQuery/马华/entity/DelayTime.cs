using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.马华.entity
{
    public class DelayTime
    {
        public int dtId { get; set; }
        public int mainId { get; set; }
        public double 温度条件 { get; set; }
        public double 延期时间下限 { get; set; }
        public double 延期时间上限 { get; set; }
        public string 延期时间单位 { get; set; }
        public double 延期时间值 { get; set; }
        public double 延期时间值误差 { get; set; }
        public double 延期时间值误差上限 { get; set; }
        public double 延期时间值误差下限 { get; set; }
        public string 延期时间备注 { get; set; }
    }
}