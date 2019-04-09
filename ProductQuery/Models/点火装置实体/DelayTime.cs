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
        public double wdtj { get; set; }
        [DisplayName("延期时间下限")]
        public double yqsjxx { get; set; }
        [DisplayName("延期时间上限")]
        public double yqsjsx { get; set; }
        [DisplayName("延期时间值")]
        public double yqsjz { get; set; }
        [DisplayName("延期时间值误差")]
        public double yqsjzwc { get; set; }
        [DisplayName("延期时间备注")]
        public string yqsjbz { get; set; }
    }
}