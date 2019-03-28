using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class SpeedDetonation
    {
        [ForeignKey("IgnitionID")]
        public virtual Ignition Ignition { get; set; }
        [Display(Name = "点火装置ID")]
        public int IgnitionID { get; set; }

        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("爆速上限")]
        public double 爆速上限 { get; set; }
        [DisplayName("爆速下限")]
        public double 爆速下限 { get; set; }
        [DisplayName("爆速备注")]
        public string 爆速备注 { get; set; }
    }
}