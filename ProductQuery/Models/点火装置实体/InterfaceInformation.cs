﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class InterfaceInformation
    {
        [ForeignKey("IgnitionID")]
        public virtual Ignition Ignition { get; set; }
        [Display(Name = "点火装置ID")]
        public int IgnitionID { get; set; }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("螺纹")]
        public double 螺纹 { get; set; }
        [DisplayName("螺距")]
        public double 螺距 { get; set; }
        [DisplayName("公差")]
        public string 公差 { get; set; }
        [DisplayName("长度")]
        public double 长度 { get; set; }
    }
}