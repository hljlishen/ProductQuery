using ProductQuery.马华.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductQuery.燕廷
{
    public class ProductModel
    {
        public string 类别 { get; set; }
        public string 产品名称 { get; set; }
        public string 设计单位 { get; set; }
        public string 型号 { get; set; }
        public string 图号 { get; set; }
        public string 代号 { get; set; }
        public DateTime 研制日期 { get; set; }
        public DateTime 定型日期 { get; set; }
        public string 用途 { get; set; }
        public string 系统组成 { get; set; }
        public string 目前阶段 { get; set; }
        public List<产品示意图> 产品示意图 { get; set; }
        public string 机械性能 { get; set; }
        public string 电性能 { get; set; }
        public string 功能 { get; set; }
        public string 环境测试 { get; set; }
        public int 桥丝数目 { get; set; }
        public int 贮存寿命 { get; set; }
        public string 贮存寿命备注 { get; set; }
        public string 可靠度 { get; set; }
        public string 主要性能指标 { get; set; }
        public string 试验环境指标范围 { get; set; }
        public string 基本性能 { get; set; }
        public List<Conventional> 常规 { get; set; }
        public double 脚线 { get; set; }
        public double 总长度 { get; set; }
        public string 隔板厚度 { get; set; }
        public int 索直径上限 { get; set; }
        public int 索直径下限 { get; set; }
        public List<索普通直径> 索普通直径 { get; set; }
        public double 索普通直径误差 { get; set; }
        public double 索MDF银质直径 { get; set; }
        public double 索MDF银质直径误差 { get; set; }
        public List<速爆属性> 速爆属性 { get; set; }
        public int 对边 { get; set; }
        public int 对角线 { get; set; }
        public List<InterfaceInformation> 接口信息 { get; set; }
        public List<直流电阻> 直流电阻 { get; set; }
        public double 检测电流 { get; set; }
        public double 静电电容 { get; set; }
        public double 静电电压 { get; set; }
        public double 串联电阻 { get; set; }
        public string 静电感度备注 { get; set; }
        public List<桥个数> 桥个数 { get; set; }
        public List<发火条件> 发火条件 { get; set; }
        public double 作用时间 { get; set; }
        public string 作用时间单位 { get; set; }
        public double 作用时间下限 { get; set; }
        public double 作用时间上限 { get; set; }
        public string 作用时间备注 { get; set; }
        public List<DelayTime> 延期时间 { get; set; }
        public double 电流桥个数 { get; set; }
        public double 安全电流值 { get; set; }
        public double 安全电流值下限 { get; set; }
        public double 安全电流值上限 { get; set; }
        public string 安全电流值单位 { get; set; }
        public double 时间值 { get; set; }
        public string 时间单位 { get; set; }
        public double 功率值 { get; set; }
        public string 安全电流备注 { get; set; }
        public double 安全电压电压 { get; set; }
        public double 安全电压电容 { get; set; }
        public double 燃烧压力下限 { get; set; }
        public double 燃烧压力上限 { get; set; }
        public string 燃烧压力备注 { get; set; }
    }
}