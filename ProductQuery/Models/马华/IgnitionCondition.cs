using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class IgnitionCondition
    {
        private int icId { get; set; }
        private int mainId { get; set; }
        private int 电阻桥个数 { get; set; }
        private string 电阻单位 { get; set; }
        private double 电阻范围值上 { get; set; }
        private double 电阻范围值下 { get; set; }
        private double 电阻公差值 { get; set; }
        private double 电阻小于值 { get; set; }
        private string 电阻备注 { get; set; }

        private int 桥个数 { get; set; }
        private double 发火电压 { get; set; }
        private double 发火电压下限 { get; set; }
        private double 发火电压上限 { get; set; }
        private double 发火电容 { get; set; }
        private string 发火电容单位 { get; set; }
        private double 发火电流 { get; set; }
        private double 发火电流下限 { get; set; }
        private double 发火电流上限 { get; set; }
        private string 发火电流单位 { get; set; }
        private double 发火电流时间 { get; set; }
        private string 发火电流时间单位 { get; set; }
        private double 锤重 { get; set; }
        private string 锤重单位 { get; set; }
        private double 落高 { get; set; }
        private string 落高单位 { get; set; }
        private double 击针刺激量 { get; set; }
        private double 击针力下限 { get; set; }
        private double 击针力上限 { get; set; }
        private double 击针突出量下限 { get; set; }
        private double 击针突出量上限 { get; set; }
        private double 弹簧高度 { get; set; }
        private double 抗力 { get; set; }
        private double 能量 { get; set; }
        private string 能量单位 { get; set; }
    }
}