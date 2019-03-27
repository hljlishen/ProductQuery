using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class DcResistance
    {
        [Key]
        [DisplayName("Id")]
        private int Id { get; set; }
        [DisplayName("mainId")]
        private int mainId { get; set; }
        [DisplayName("电阻桥个数")]
        private int 电阻桥个数 { get; set; }
        [DisplayName("电阻单位")]
        private string 电阻单位 { get; set; }
        [DisplayName("电阻范围值上")]
        private double 电阻范围值上 { get; set; }
        [DisplayName("电阻范围值下")]
        private double 电阻范围值下 { get; set; }
        [DisplayName("电阻值")]
        private double 电阻值 { get; set; }
        [DisplayName("电阻公差值")]
        private double 电阻公差值 { get; set; }
        [DisplayName("电阻小于值")]
        private double 电阻小于值 { get; set; }
        [DisplayName("电阻备注")]
        private string 电阻备注 { get; set; }
    }
}