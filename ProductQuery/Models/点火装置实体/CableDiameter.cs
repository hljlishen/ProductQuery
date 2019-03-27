using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class CableDiameter
    {
        [Key]
        [DisplayName("Id")]
        private int Id { get; set; }
        [DisplayName("mainId")]
        private int mainId { get; set; }
        [DisplayName("普通索直径")]
        private double 普通索直径 { get; set; }
    }
}