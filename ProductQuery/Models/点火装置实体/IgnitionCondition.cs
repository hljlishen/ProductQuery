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
        public int qgs { get; set; }
        [DisplayName("发火电压")]
        public double fhdy { get; set; }
        [DisplayName("发火电压下限")]
        public double fhdyxx { get; set; }
        [DisplayName("发火电压上限")]
        public double fhdysx { get; set; }
        [DisplayName("发火电压备注")]
        public string fhdybz { get; set; }
        [DisplayName("发火电容")]
        public double fhdr { get; set; }
        [DisplayName("发火电流")]
        public double fhdl { get; set; }
        [DisplayName("发火电流下限")]
        public double fhdlxx { get; set; }
        [DisplayName("发火电流上限")]
        public double fhdlsx { get; set; }
        [DisplayName("发火电流时间")]
        public double fhdlss { get; set; }
        [DisplayName("电流发火备注")]
        public string dlfhbz { get; set; }
        [DisplayName("锤重")]
        public double cz { get; set; }
        [DisplayName("落高")]
        public double lg { get; set; }
        [DisplayName("击针刺激量")]
        public double jzcjl { get; set; }
        [DisplayName("击针力下限")]
        public double jzlxx { get; set; }
        [DisplayName("击针力上限")]
        public double jzlsx { get; set; }
        [DisplayName("击针突出量下限")]
        public double jztclxx { get; set; }
        [DisplayName("击针突出量上限")]
        public double jztclsx { get; set; }
        [DisplayName("弹簧高度")]
        public double thgd { get; set; }
        [DisplayName("抗力")]
        public double kl { get; set; }
        [DisplayName("能量")]
        public double nl { get; set; }
        [DisplayName("机械发火备注")]
        public double jxfhbz { get; set; }

    }
}