using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class DelayTime
    {
        private int dtId { get; set; }
        private int mainId { get; set; }
        private double 温度条件 { get; set; }
        private double 延期时间下限 { get; set; }
        private double 延期时间上限 { get; set; }
        private string 延期时间单位 { get; set; }
        private double 延期时间值 { get; set; }
        private double 延期时间值误差 { get; set; }
        private double 延期时间值误差上限 { get; set; }
        private double 延期时间值误差下限 { get; set; }
        private string 延期时间备注 { get; set; }
    }
}