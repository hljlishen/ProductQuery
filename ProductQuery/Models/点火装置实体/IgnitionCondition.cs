using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class IgnitionCondition
    {
        [ForeignKey("IgnitionID")]
        public virtual Ignition Ignition { get; set; }
        [Display(Name = "点火装置ID")]
        public int IgnitionID { get; set; }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("桥个数")]
        public int 桥个数 { get; set; }
        [DisplayName("发火电压")]
        public double 发火电压 { get; set; }
        [DisplayName("发火电压下限")]
        public double 发火电压下限 { get; set; }
        [DisplayName("发火电压上限")]
        public double 发火电压上限 { get; set; }
        [DisplayName("发火电容")]
        public double 发火电容 { get; set; }
        [DisplayName("发火电容单位")]
        public string 发火电容单位 { get; set; }
        [DisplayName("发火电流")]
        public double 发火电流 { get; set; }
        [DisplayName("发火电流下限")]
        public double 发火电流下限 { get; set; }
        [DisplayName("发火电流上限")]
        public double 发火电流上限 { get; set; }
        [DisplayName("发火电流单位")]
        public string 发火电流单位 { get; set; }
        [DisplayName("发火电流时间")]
        public double 发火电流时间 { get; set; }
        [DisplayName("发火电流时间单位")]
        public string 发火电流时间单位 { get; set; }
        [DisplayName("锤重")]
        public double 锤重 { get; set; }
        [DisplayName("锤重单位")]
        public string 锤重单位 { get; set; }
        [DisplayName("落高")]
        public double 落高 { get; set; }
        [DisplayName("落高单位")]
        public string 落高单位 { get; set; }
        [DisplayName("击针刺激量")]
        public double 击针刺激量 { get; set; }
        [DisplayName("击针力下限")]
        public double 击针力下限 { get; set; }
        [DisplayName("击针力上限")]
        public double 击针力上限 { get; set; }
        [DisplayName("击针突出量下限")]
        public double 击针突出量下限 { get; set; }
        [DisplayName("击针突出量上限")]
        public double 击针突出量上限 { get; set; }
        [DisplayName("弹簧高度")]
        public double 弹簧高度 { get; set; }
        [DisplayName("抗力")]
        public double 抗力 { get; set; }
        [DisplayName("能量")]
        public double 能量 { get; set; }
        [DisplayName("能量单位")]
        public string 能量单位 { get; set; }
    }
}