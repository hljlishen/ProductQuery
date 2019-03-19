using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.entity
{
    public class Conventional
    {
        private int conventionalId { get; set; }
        private int mainId { get; set; }
        private string 尺寸名称 { get; set; }
        private double 直径 { get; set; }
        private double 长度 { get; set; }
        private double 高度 { get; set; }
        private double 索普通直径 { get; set; }
        private double 爆速上限 { get; set; }
        private double 爆速下限 { get; set; }
        private string 爆速备注 { get; set; }

        //添加
        public string AddConventionalSql()
        {
            常规 sa = new 常规();
            string sql = "";
            return sql;
        }
    }

}