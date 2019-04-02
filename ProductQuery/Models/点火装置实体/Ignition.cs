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
            图片 = new List<Picture>();
            常规 = new List<Conventional>();
            普通索直径 = new List<CableDiameter>();
            爆速 = new List<SpeedDetonation>();
            接口信息 = new List<InterfaceInformation>();
            直流电阻 = new List<DcResistance>();
            发火条件 = new List<IgnitionCondition>();
            延期时间 = new List<DelayTime>();
        }

        [InverseProperty("Ignition")]
        public virtual List<Picture> 图片 { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<Conventional> 常规 { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<CableDiameter> 普通索直径 { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<SpeedDetonation> 爆速 { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<InterfaceInformation> 接口信息 { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<DcResistance> 直流电阻 { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<IgnitionCondition> 发火条件 { get; set; }
        [InverseProperty("Ignition")]
        public virtual List<DelayTime> 延期时间 { get; set; }

        [Key]
        [DisplayName("点火装置Id")]
        public int IgnitionId { get; set; }
        [DisplayName("类别")]
        public string 类别 { get; set; }
        [DisplayName("产品名称")]
        public string 产品名称 { get; set; }
        [DisplayName("设计单位")]
        public string 设计单位 { get; set; }
        [DisplayName("型号")]
        public string 型号 { get; set; }
        [DisplayName("图号")]
        public string 图号 { get; set; }
        [DisplayName("代号")]
        public string 代号 { get; set; }
        [DisplayName("研制日期")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}", HtmlEncode = false, NullDisplayText = "数据无效")]
        public DateTime 研制日期 { get; set; }
        [DisplayName("定型日期")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}", HtmlEncode = false, NullDisplayText = "数据无效")]
        public DateTime 定型日期 { get; set; }
        [DisplayName("工艺定型")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}", HtmlEncode = false, NullDisplayText = "数据无效")]
        public DateTime 工艺定型 { get; set; }
        [DisplayName("用途")]
        public string 用途 { get; set; }
        [DisplayName("系统组成")]
        public string 系统组成 { get; set; }
        [DisplayName("目前阶段")]
        public string 目前阶段 { get; set; }
        [DisplayName("机械性能")]
        public string 机械性能 { get; set; }
        [DisplayName("电性能")]
        public string 电性能 { get; set; }
        [DisplayName("功能")]
        public string 功能 { get; set; }
        [DisplayName("环境测试")]
        public string 环境测试 { get; set; }
        [DisplayName("桥丝数目")]
        public int 桥丝数目 { get; set; }
        [DisplayName("贮存寿命")]
        public int 贮存寿命 { get; set; }
        [DisplayName("贮存寿命备注")]
        public string 贮存寿命备注 { get; set; }
        [DisplayName("可靠度")]
        public string 可靠度 { get; set; }
        [DisplayName("主要性能指标")]
        public string 主要性能指标 { get; set; }
        [DisplayName("试验环境指标范围")]
        public string 试验环境指标范围 { get; set; }
        [DisplayName("基本性能")]
        public string 基本性能 { get; set; }

        [DisplayName("脚线")]
        public double 脚线 { get; set; }
        [DisplayName("总长度")]
        public double 总长度 { get; set; }
        [DisplayName("隔板厚度")]
        public double 隔板厚度 { get; set; }
        [DisplayName("索直径上限")]
        public double 索直径上限 { get; set; }
        [DisplayName("索直径下限")]
        public double 索直径下限 { get; set; }
        [DisplayName("索MDF银质直径")]
        public double 索MDF银质直径 { get; set; }
        [DisplayName("对边")]
        public int 对边 { get; set; }
        [DisplayName("对角线")]
        public double 对角线 { get; set; }
        [DisplayName("检测电流")]
        public double 检测电流 { get; set; }
        [DisplayName("静电电容")]
        public double 静电电容 { get; set; }
        [DisplayName("静电电压")]
        public double 静电电压 { get; set; }
        [DisplayName("串联电阻")]
        public double 串联电阻 { get; set; }
        [DisplayName("静电感度备注")]
        public string 静电感度备注 { get; set; }
        [DisplayName("作用时间")]
        public double 作用时间 { get; set; }
        [DisplayName("作用时间单位")]
        public string 作用时间单位 { get; set; }
        [DisplayName("作用时间下限")]
        public double 作用时间下限 { get; set; }
        [DisplayName("作用时间上限")]
        public double 作用时间上限 { get; set; }
        [DisplayName("作用时间备注")]
        public string 作用时间备注 { get; set; }
        [DisplayName("桥个数")]
        public double 桥个数 { get; set; }
        [DisplayName("安全电流值")]
        public double 安全电流值 { get; set; }
        [DisplayName("安全电流值下限")]
        public double 安全电流值下限 { get; set; }
        [DisplayName("安全电流值上限")]
        public double 安全电流值上限 { get; set; }
        [DisplayName("安全电流值单位")]
        public string 安全电流值单位 { get; set; }
        [DisplayName("时间值")]
        public double 时间值 { get; set; }
        [DisplayName("时间单位")]
        public string 时间单位 { get; set; }
        [DisplayName("功率值")]
        public double 功率值 { get; set; }
        [DisplayName("安全电流备注")]
        public string 安全电流备注 { get; set; }
        [DisplayName("安全电压电压")]
        public double 安全电压电压 { get; set; }
        [DisplayName("安全电压电容")]
        public double 安全电压电容 { get; set; }
        [DisplayName("燃烧压力下限")]
        public double 燃烧压力下限 { get; set; }
        [DisplayName("燃烧压力上限")]
        public double 燃烧压力上限 { get; set; }
        [DisplayName("燃烧压力备注")]
        public string 燃烧压力备注 { get; set; }

        //public string speicialPropertiesString { get; set; }

        //Dictionary<string, string> speicialProperties;
    }
}