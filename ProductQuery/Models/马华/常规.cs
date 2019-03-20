using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class 常规
    {
        public int conventionalId { get; set; }
        public int mainId { get; set; }
        public string 尺寸名称 { get; set; }
        public double 直径 { get; set; }
        public double 长度 { get; set; }
        public double 高度 { get; set; }
        public double 索普通直径 { get; set; }
        public double 爆速上限 { get; set; }
        public double 爆速下限 { get; set; }
        public string 爆速备注 { get; set; }
    }
}