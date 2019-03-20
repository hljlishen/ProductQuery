using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class 发火条件
    {
        public int icId { get; set; }
        public int mainId { get; set; }
        public int 电阻桥个数 { get; set; }
        public string 电阻单位 { get; set; }
        public double 电阻范围值上 { get; set; }
        public double 电阻范围值下 { get; set; }
        public double 电阻公差值 { get; set; }
        public double 电阻小于值 { get; set; }
        public string 电阻备注 { get; set; }

        public int 桥个数 { get; set; }
        public double 发火电压 { get; set; }
        public double 发火电压下限 { get; set; }
        public double 发火电压上限 { get; set; }
        public double 发火电容 { get; set; }
        public string 发火电容单位 { get; set; }
        public double 发火电流 { get; set; }
        public double 发火电流下限 { get; set; }
        public double 发火电流上限 { get; set; }
        public string 发火电流单位 { get; set; }
        public double 发火电流时间 { get; set; }
        public string 发火电流时间单位 { get; set; }
        public double 锤重 { get; set; }
        public string 锤重单位 { get; set; }
        public double 落高 { get; set; }
        public string 落高单位 { get; set; }
        public double 击针刺激量 { get; set; }
        public double 击针力下限 { get; set; }
        public double 击针力上限 { get; set; }
        public double 击针突出量下限 { get; set; }
        public double 击针突出量上限 { get; set; }
        public double 弹簧高度 { get; set; }
        public double 抗力 { get; set; }
        public double 能量 { get; set; }
        public string 能量单位 { get; set; }
    }
}