using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class DelayTime
    {
        [ForeignKey("IgnitionID")]
        public virtual Ignition Ignition { get; set; }
        [Display(Name = "点火装置ID")]
        public int IgnitionID { get; set; }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("温度条件")]
        public double 温度条件 { get; set; }
        [DisplayName("延期时间下限")]
        public double 延期时间下限 { get; set; }
        [DisplayName("延期时间上限")]
        public double 延期时间上限 { get; set; }
        [DisplayName("延期时间单位")]
        public string 延期时间单位 { get; set; }
        [DisplayName("延期时间值")]
        public double 延期时间值 { get; set; }
        [DisplayName("延期时间值误差")]
        public double 延期时间值误差 { get; set; }
        [DisplayName("延期时间值误差上限")]
        public double 延期时间值误差上限 { get; set; }
        [DisplayName("延期时间值误差下限")]
        public double 延期时间值误差下限 { get; set; }
        [DisplayName("延期时间备注")]
        public string 延期时间备注 { get; set; }
    }
}