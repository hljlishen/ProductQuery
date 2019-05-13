using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class WebsiteStatistical
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("访问日期")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}", HtmlEncode = false, NullDisplayText = "数据无效")]
        public DateTime Data { get; set; }

        [DisplayName("查询次数")]
        public int QueryNumber { get; set; }

        [DisplayName("访问次数")]
        public int AccessNumber { get; set; }

    }
}