using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class Conventional
    {
        [Key]
        [DisplayName("Id")]
        private int Id { get; set; }
        [DisplayName("mainId")]
        private int mainId { get; set; }
        [DisplayName("尺寸名称")]
        private string 尺寸名称 { get; set; }
        [DisplayName("直径")]
        private double 直径 { get; set; }
        [DisplayName("长度")]
        private double 长度 { get; set; }
        [DisplayName("高度")]
        private double 高度 { get; set; }
    }
}