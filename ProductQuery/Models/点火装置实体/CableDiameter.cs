using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class CableDiameter
    {
        [ForeignKey("IgnitionID")]
        public virtual Ignition Ignition { get; set; }
        [Display(Name = "点火装置ID")]
        public int IgnitionID { get; set; }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("普通索直径")]
        public double ptszj { get; set; }
    }
}