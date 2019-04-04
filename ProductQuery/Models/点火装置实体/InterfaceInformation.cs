using System;
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
        public double lw { get; set; }
        [DisplayName("螺距")]
        public double lj { get; set; }
        [DisplayName("公差")]
        public string gc { get; set; }
        [DisplayName("长度")]
        public double cd { get; set; }
    }
}