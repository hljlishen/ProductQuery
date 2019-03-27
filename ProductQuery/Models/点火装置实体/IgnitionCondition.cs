using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class IgnitionCondition
    {
        [Key]
        [DisplayName("Id")]
        private int Id { get; set; }
        [DisplayName("mainId")]
        private int mainId { get; set; }
        [DisplayName("桥个数")]
        private int 桥个数 { get; set; }
        [DisplayName("发火电压")]
        private double 发火电压 { get; set; }
        [DisplayName("发火电压下限")]
        private double 发火电压下限 { get; set; }
        [DisplayName("发火电压上限")]
        private double 发火电压上限 { get; set; }
        [DisplayName("发火电容")]
        private double 发火电容 { get; set; }
        [DisplayName("发火电容单位")]
        private string 发火电容单位 { get; set; }
        [DisplayName("发火电流")]
        private double 发火电流 { get; set; }
        [DisplayName("发火电流下限")]
        private double 发火电流下限 { get; set; }
        [DisplayName("发火电流上限")]
        private double 发火电流上限 { get; set; }
        [DisplayName("发火电流单位")]
        private string 发火电流单位 { get; set; }
        [DisplayName("发火电流时间")]
        private double 发火电流时间 { get; set; }
        [DisplayName("发火电流时间单位")]
        private string 发火电流时间单位 { get; set; }
        [DisplayName("锤重")]
        private double 锤重 { get; set; }
        [DisplayName("锤重单位")]
        private string 锤重单位 { get; set; }
        [DisplayName("落高")]
        private double 落高 { get; set; }
        [DisplayName("落高单位")]
        private string 落高单位 { get; set; }
        [DisplayName("击针刺激量")]
        private double 击针刺激量 { get; set; }
        [DisplayName("击针力下限")]
        private double 击针力下限 { get; set; }
        [DisplayName("击针力上限")]
        private double 击针力上限 { get; set; }
        [DisplayName("击针突出量下限")]
        private double 击针突出量下限 { get; set; }
        [DisplayName("击针突出量上限")]
        private double 击针突出量上限 { get; set; }
        [DisplayName("弹簧高度")]
        private double 弹簧高度 { get; set; }
        [DisplayName("抗力")]
        private double 抗力 { get; set; }
        [DisplayName("能量")]
        private double 能量 { get; set; }
        [DisplayName("能量单位")]
        private string 能量单位 { get; set; }
    }
}