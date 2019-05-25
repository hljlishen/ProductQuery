using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductQuery.Models
{
    public class Ignition
    {
        public Ignition()
        {
            Pictures = new List<Picture>();
            Conventionals = new List<Conventional>();
            CableDiameters = new List<CableDiameter>();
            SpeedDetonations = new List<SpeedDetonation>();
            InterfaceInformations = new List<InterfaceInformation>();
            DcResistances = new List<DcResistance>();
            IgnitionConditions = new List<IgnitionCondition>();
            DelayTimes = new List<DelayTime>();
        }

        [InverseProperty("Ignition")]
        public virtual List<Picture> Pictures { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<Conventional> Conventionals { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<CableDiameter> CableDiameters { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<SpeedDetonation> SpeedDetonations { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<InterfaceInformation> InterfaceInformations { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<DcResistance> DcResistances { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<IgnitionCondition> IgnitionConditions { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<DelayTime> DelayTimes { get; set; }

        [Key]
        [DisplayName("点火装置Id")]
        public int IgnitionId { get; set; }
        [DisplayName("类别")]
        [Required(ErrorMessage = "*{0}是必填项")]
        public string lb { get; set; }
        [DisplayName("产品名称")]
        [Required(ErrorMessage = "*{0}是必填项")]
        public string cpmc { get; set; }
        [DisplayName("设计单位")]
        public string sjdw { get; set; }
        [DisplayName("生产单位")]
        public string scdw { get; set; }
        [DisplayName("型号")]
        public string xh { get; set; }
        [DisplayName("图号")]
        public string th { get; set; }
        [DisplayName("代号")]
        public string dh { get; set; }
        [DisplayName("研制日期")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}", HtmlEncode = false, NullDisplayText = "数据无效")]
        public DateTime? yzrq { get; set; }
        [DisplayName("定型日期")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}", HtmlEncode = false, NullDisplayText = "数据无效")]
        public DateTime? dxrq { get; set; }
        [DisplayName("工艺定型")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}", HtmlEncode = false, NullDisplayText = "数据无效")]
        public DateTime? gydx { get; set; }
        [DisplayName("用途")]
        public string yt { get; set; }
        [DisplayName("系统组成")]
        public string xtzc { get; set; }
        [DisplayName("目前阶段")]
        public string mqjd { get; set; }
        [DisplayName("机械性能")]
        public string jxxn { get; set; }
        [DisplayName("电性能")]
        public string dxn { get; set; }
        [DisplayName("功能")]
        public string gn { get; set; }
        [DisplayName("环境测试")]
        public string hjcs { get; set; }
        [DisplayName("桥丝数目")]
        public int? jssm { get; set; }
        [DisplayName("贮存寿命")]
        public int? zcsm { get; set; }
        [DisplayName("贮存寿命备注")]
        public string ccsmbz { get; set; }
        [DisplayName("可靠度")]
        public string kkd { get; set; }
        [DisplayName("主要性能指标")]
        public string zyxnzb { get; set; }
        [DisplayName("试验环境指标范围")]
        public string syhjzsfw { get; set; }
        [DisplayName("基本性能")]
        public string jbxn { get; set; }
        [DisplayName("宽度")]
        public double? kd { get; set; }
        [DisplayName("脚线")]
        public double? jx { get; set; }
        [DisplayName("总长度")]
        public double? zcd { get; set; }
        [DisplayName("隔板厚度")]
        public double? gbhd { get; set; }
        [DisplayName("索直径上限")]
        public double? szjsx { get; set; }
        [DisplayName("索直径下限")]
        public double? szjxx { get; set; }
        [DisplayName("索MDF银质直径")]
        public double? sMDFyzzj { get; set; }
        [DisplayName("索备注")]
        public string sbz { get; set; }
        [DisplayName("对边")]
        public double? db { get; set; }
        [DisplayName("对角线")]
        public double? djx { get; set; }
        [DisplayName("六方对角备注")]
        public string lfdjbz { get; set; }
        [DisplayName("检测电流")]
        public double? jcdl { get; set; }
        [DisplayName("静电电容")]
        public double? jddr { get; set; }
        [DisplayName("静电电压")]
        public double? jddy { get; set; }
        [DisplayName("串联电阻")]
        public double? cldz { get; set; }
        [DisplayName("静电感度备注")]
        public string jdgdbz { get; set; }
        [DisplayName("作用时间")]
        public double? zysj { get; set; }
        [DisplayName("作用时间下限")]
        public double? zysjxx { get; set; }
        [DisplayName("作用时间上限")]
        public double? zysjsx { get; set; }
        [DisplayName("作用时间备注")]
        public string zysjbz { get; set; }
        [DisplayName("桥个数")]
        public int? jgs { get; set; }
        [DisplayName("安全电流值")]
        public double? aydlz { get; set; }
        [DisplayName("安全电流值下限")]
        public double? aydlzxx { get; set; }
        [DisplayName("安全电流值上限")]
        public double? aydlzsx { get; set; }
        [DisplayName("时间值")]
        public double? ssj { get; set; }
        [DisplayName("功率值")]
        public double? glz { get; set; }
        [DisplayName("安全电流备注")]
        public string aqdlbz { get; set; }
        [DisplayName("安全电压电压")]
        public double? aqdydy { get; set; }
        [DisplayName("安全电压电容")]
        public double? aqdydr { get; set; }
        [DisplayName("燃烧压力下限")]
        public double? rsylxx { get; set; }
        [DisplayName("燃烧压力上限")]
        public double? rsylsx { get; set; }
        [DisplayName("燃烧压力备注")]
        public string rsylbz { get; set; }

        [NotMapped]
        [DisplayName("单位")]
        public string dw { get; set; }
        [NotMapped]
        public string speicialPropertiesString { get; set; }
        [NotMapped]
        Dictionary<string, string> speicialProperties;
    }
}