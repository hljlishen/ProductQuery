using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductQuery.Controllers.Filters;
using ProductQuery.Controllers.IMeasurementConverters;
using ProductQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductQuery.Controllers.Filters.Tests
{
    [TestClass()]
    public class FilterTests
    {

        [TestMethod()]
        public void DoubleInRangeTest()
        {
            Ignition ig = new Ignition();
            ig.IgnitionId = 1;
            ig.串联电阻 = 5;

            Conventional conventional = new Conventional();
            conventional.IgnitionID = 1;
            conventional.Ignition = ig;
            conventional.Id = 1;
            conventional.尺寸名称 = "001";
            conventional.直径 = 2.3;
            conventional.长度 = 2.3;
            conventional.高度 = 2.3;
            ig.常规.Add(conventional);

            IMeasurementConverter measurementConverter = new Resistance("Ω");
            _Filter filter = new DoubleInRange("串联电阻" , 4 , 9);
            filter.MeasurementConverter = measurementConverter;
            bool test= filter.IsPass(ig);
            Assert.IsTrue(test);

            measurementConverter = new Resistance("Ω");
            filter = new DoubleInRange("串联电阻", 9, 9);
            filter.MeasurementConverter = measurementConverter;
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            measurementConverter = new Resistance("Ω");
            filter = new DoubleInRange("串联电阻", 8, 9);
            filter.MeasurementConverter = measurementConverter;
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            measurementConverter = new Resistance("Ω");
            filter = new DoubleInRange("串联电阻", 10, 4);
            filter.MeasurementConverter = measurementConverter;
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            measurementConverter = new Lenght("mm");
            _Filter filter1 = new DoubleInRange("直径", 1.5, 4.9);
            filter1.MeasurementConverter = measurementConverter;
            filter = new ListPropertyDecorator("常规", filter1);
            test = filter.IsPass(ig);
            Assert.IsTrue(test);
        }

        [TestMethod()]
        public void IntInRangeTest()
        {
            Ignition ig = new Ignition();
            ig.IgnitionId = 1;
            ig.桥丝数目 = 2;
            ig.贮存寿命 = 10;
            DcResistance dcResistance = new DcResistance();
            dcResistance.电阻桥个数 = 1;
            ig.直流电阻.Add(dcResistance);

            _Filter filter = new IntInRange("桥丝数目", 2,3);
            bool test = filter.IsPass(ig);
            Assert.IsTrue(test);

            filter = new IntInRange("桥丝数目", 2, 2);
            test = filter.IsPass(ig);
            Assert.IsTrue(test);

            filter = new IntInRange("贮存寿命", 2, 6);
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            _Filter filter1 = new IntInRange("电阻桥个数", 0, 1);
            filter = new ListPropertyDecorator("直流电阻", filter1);
            test = filter.IsPass(ig);
            Assert.IsTrue(test);
        }

        [TestMethod()]
        public void RangeIntersectTest()
        {
            Ignition ig = new Ignition();
            ig.IgnitionId = 1;
            ig.燃烧压力上限 = 105.3;
            ig.燃烧压力下限 = 90.8;
            DelayTime delayTime = new DelayTime();
            delayTime.延期时间下限 = 120000;
            delayTime.延期时间上限 = 800000;
            ig.延期时间.Add(delayTime);

            _Filter filter = new RangeIntersect("燃烧压力", 100.6, 120.88);
            bool test = filter.IsPass(ig);
            Assert.IsTrue(test);

            filter = new RangeIntersect("燃烧压力", 70, 90);
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            filter = new RangeIntersect("燃烧压力", 99, 100);
            test = filter.IsPass(ig);
            Assert.IsTrue(test);

            filter = new RangeIntersect("燃烧压力", 106, 500);
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            filter = new RangeIntersect("燃烧压力", 88, 100);
            test = filter.IsPass(ig);
            Assert.IsTrue(test);

            IMeasurementConverter measurementConverter = new Time("min");
            _Filter filter1 = new RangeIntersect("延期时间", 1, 3);
            filter1.MeasurementConverter = measurementConverter;
            filter = new ListPropertyDecorator("延期时间", filter1);
            test = filter.IsPass(ig);
            Assert.IsTrue(test);
        }

        [TestMethod()]
        public void StringLikeTest()
        {
            Ignition ig = new Ignition();
            ig.IgnitionId = 1;
            ig.安全电流备注 = "安全电流100mA";
            DelayTime delayTime = new DelayTime();
            delayTime.延期时间备注 = "延期时间100天";
            ig.延期时间.Add(delayTime);

            _Filter filter = new StringLike("安全电流备注", "100mA");
            bool test = filter.IsPass(ig);
            Assert.IsTrue(test);

            filter = new StringLike("安全电流备注", "安全100mA");
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            _Filter filter1 = new StringLike("延期时间备注", "延期100多天");
            filter = new ListPropertyDecorator("延期时间", filter1);
            test = filter.IsPass(ig);
            Assert.IsFalse(test);
        }

        [TestMethod()]
        public void DateTimeInRangeTest()
        {
            Ignition ig = new Ignition();
            ig.定型日期 = new DateTime(2010, 2, 12);

            _Filter filter = new DateTimeInRange("定型日期", new DateTime(2010, 2, 10), new DateTime(2019,4, 13));
            bool test = filter.IsPass(ig);
            Assert.IsTrue(test);

            filter = new DateTimeInRange("定型日期", new DateTime(2019, 2, 10), new DateTime(2019, 4, 13));
            test = filter.IsPass(ig);
            Assert.IsFalse(test);
        }

        [TestMethod()]
        public void GlobalStringLikeTest()
        {
            Ignition ig = new Ignition();
            ig.IgnitionId = 1;
            ig.安全电流备注 = "安全电流100mA";
            DelayTime delayTime = new DelayTime();
            delayTime.延期时间备注 = "延期时间100天";
            ig.延期时间.Add(delayTime);

            _Filter filter = new GlobalStringLike("100mA");
            bool test = filter.IsPass(ig);
            Assert.IsTrue(test);

            filter = new GlobalStringLike("安全100mA");
            test = filter.IsPass(ig);
            Assert.IsFalse(test);

            filter = new GlobalStringLike("延期100多天");
            test = filter.IsPass(ig);
            Assert.IsFalse(test);
        }


    }
}