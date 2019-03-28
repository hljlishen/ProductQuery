using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class DcResistance
    {
        [ForeignKey("IgnitionID")]
        public virtual Ignition Ignition { get; set; }
        [Display(Name = "点火装置ID")]
        public int IgnitionID { get; set; }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("电阻桥个数")]
        public int 电阻桥个数 { get; set; }
        [DisplayName("电阻单位")]
        public string 电阻单位 { get; set; }
        [DisplayName("电阻范围值上")]
        public double 电阻范围值上 { get; set; }
        [DisplayName("电阻范围值下")]
        public double 电阻范围值下 { get; set; }
        [DisplayName("电阻值")]
        public double 电阻值 { get; set; }
        [DisplayName("电阻公差值")]
        public double 电阻公差值 { get; set; }
        [DisplayName("电阻小于值")]
        public double 电阻小于值 { get; set; }
        [DisplayName("电阻备注")]
        public string 电阻备注 { get; set; }
    }
}