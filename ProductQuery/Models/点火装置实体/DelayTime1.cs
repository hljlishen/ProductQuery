using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class DelayTime1
    {
        [Key]
        [DisplayName("Id")]
        private int Id { get; set; }
        [DisplayName("mainId")]
        private int mainId { get; set; }
        [DisplayName("温度条件")]
        private double 温度条件 { get; set; }
        [DisplayName("延期时间下限")]
        private double 延期时间下限 { get; set; }
        [DisplayName("延期时间上限")]
        private double 延期时间上限 { get; set; }
        [DisplayName("延期时间单位")]
        private string 延期时间单位 { get; set; }
        [DisplayName("延期时间值")]
        private double 延期时间值 { get; set; }
        [DisplayName("延期时间值误差")]
        private double 延期时间值误差 { get; set; }
        [DisplayName("延期时间值误差上限")]
        private double 延期时间值误差上限 { get; set; }
        [DisplayName("延期时间值误差下限")]
        private double 延期时间值误差下限 { get; set; }
        [DisplayName("延期时间备注")]
        private string 延期时间备注 { get; set; }
    }
}