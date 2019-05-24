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
        public int? dzqgs { get; set; }
        [DisplayName("电阻范围值上限")]
        public double? dzfwzsx { get; set; }
        [DisplayName("电阻范围值下限")]
        public double? dzfwzxx { get; set; }
        [DisplayName("电阻值")]
        public double? dzz { get; set; }
        [DisplayName("电阻公差值")]
        public double? dzgcz { get; set; }
        [DisplayName("电阻小于值")]
        public double? dzxyz { get; set; }
        [DisplayName("电阻备注")]
        public string dzbz { get; set; }
    }
}