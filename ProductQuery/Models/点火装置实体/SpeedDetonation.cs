using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class SpeedDetonation
    {
        [Key]
        [DisplayName("Id")]
        private int Id { get; set; }
        [DisplayName("mainId")]
        private int mainId { get; set; }
        [DisplayName("爆速上限")]
        private double 爆速上限 { get; set; }
        [DisplayName("爆速下限")]
        private double 爆速下限 { get; set; }
        [DisplayName("爆速备注")]
        private string 爆速备注 { get; set; }
    }
}