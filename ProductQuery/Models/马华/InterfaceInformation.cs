﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class InterfaceInformation
    {
        [Key]
        [DisplayName("Id")]
        private int Id { get; set; }
        [DisplayName("mainId")]
        private int mainId { get; set; }
        [DisplayName("mainId")]
        private double 螺纹 { get; set; }
        [DisplayName("mainId")]
        private double 螺距 { get; set; }
        [DisplayName("mainId")]
        private string 公差 { get; set; }
        [DisplayName("mainId")]
        private double 长度 { get; set; }
    }
}