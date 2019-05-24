using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class Conventional
    {
        [ForeignKey("IgnitionID")]
        public virtual Ignition Ignition { get; set; }
        [Display(Name = "点火装置ID")]
        public int IgnitionID { get; set; }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("尺寸名称")]
        public string ccmc { get; set; }
        [DisplayName("直径")]
        public double? zj { get; set; }
        [DisplayName("长度")]
        public double? cd { get; set; }
        [DisplayName("高度")]
        public double? gd { get; set; }
    }
}