using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductQuery.Controllers.IMeasurementConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductQuery.Controllers.IMeasurementConverters.Tests
{
    [TestClass()]
    public class IMeasurementConverterTests
    {
        //系统默认时间为毫秒（ms）
        [TestMethod()]
        public void 时间测试()
        {
            IMeasurementConverter measurementConverter1 = new Time("ns");
            double TestValue1 = measurementConverter1.ToStandardValue(45);
            double CorrectValue1 = 0.000045;
            Assert.AreEqual(CorrectValue1, TestValue1);

            IMeasurementConverter measurementConverter2 = new Time("μs");
            double TestValue2 = measurementConverter2.ToStandardValue(235);
            double CorrectValue2 = 0.235;
            Assert.AreEqual(CorrectValue2, TestValue2);

            IMeasurementConverter measurementConverter3 = new Time("ms");
            double TestValue3 = measurementConverter3.ToStandardValue(54.68);
            double CorrectValue3 = 54.68;
            Assert.AreEqual(CorrectValue3, TestValue3);

            IMeasurementConverter measurementConverter4 = new Time("s");
            double TestValue4 = measurementConverter4.ToStandardValue(2.5);
            double CorrectValue4 = 2500;
            Assert.AreEqual(CorrectValue4, TestValue4);

            IMeasurementConverter measurementConverter5 = new Time("min");
            double TestValue5 = measurementConverter5.ToStandardValue(6);
            double CorrectValue5 = 360000;
            Assert.AreEqual(CorrectValue5, TestValue5);
        }

        //系统默认电容为微法（μf）
        [TestMethod()]
        public void 电容测试()
        {
            IMeasurementConverter measurementConverter1 = new Capacitance("μf");
            double TestValue1 = measurementConverter1.ToStandardValue(236.554);
            double CorrectValue1 = 236.554;
            Assert.AreEqual(CorrectValue1, TestValue1);

            IMeasurementConverter measurementConverter2 = new Capacitance("pf");
            double TestValue2 = measurementConverter2.ToStandardValue(365.481111);
            double CorrectValue2 = 0.000365481111;
            Assert.AreEqual(CorrectValue2, TestValue2);
        }

        //系统默认电流为兆安（mA）
        [TestMethod()]
        public void 电流测试()
        {
            IMeasurementConverter measurementConverter1 = new Current("mA");
            double TestValue1 = measurementConverter1.ToStandardValue(0.221501);
            double CorrectValue1 = 0.221501;
            Assert.AreEqual(CorrectValue1, TestValue1);

            IMeasurementConverter measurementConverter2 = new Current("A");
            double TestValue2 = measurementConverter2.ToStandardValue(0.26569114);
            double CorrectValue2 = 265.69114;
            Assert.AreEqual(CorrectValue2, TestValue2);
        }

        //系统默认长度为毫米（mm）
        [TestMethod()]
        public void 长度测试()
        {
            IMeasurementConverter measurementConverter1 = new Lenght("mm");
            double TestValue1 = measurementConverter1.ToStandardValue(0.221501);
            double CorrectValue1 = 0.221501;
            Assert.AreEqual(CorrectValue1, TestValue1);

            IMeasurementConverter measurementConverter2 = new Lenght("cm");
            double TestValue2 = measurementConverter2.ToStandardValue(583.63981);
            double CorrectValue2 = 5836.3981;
            Assert.AreEqual(CorrectValue2, TestValue2);

            IMeasurementConverter measurementConverter3 = new Lenght("m");
            double TestValue3 = measurementConverter3.ToStandardValue(2.15);
            double CorrectValue3 = 2150;
            Assert.AreEqual(CorrectValue3, TestValue3);
        }

        //系统默认电阻为欧（ms）
        [TestMethod()]
        public void 电阻测试()
        {
            IMeasurementConverter measurementConverter1 = new Resistance("mΩ");
            double TestValue1 = measurementConverter1.ToStandardValue(25.36578);
            double CorrectValue1 = 0.02536578;
            Assert.AreEqual(CorrectValue1, TestValue1);

            IMeasurementConverter measurementConverter2 = new Resistance("Ω");
            double TestValue2 = measurementConverter2.ToStandardValue(852456);
            double CorrectValue2 = 852456;
            Assert.AreEqual(CorrectValue2, TestValue2);

            IMeasurementConverter measurementConverter3 = new Resistance("kΩ");
            double TestValue3 = measurementConverter3.ToStandardValue(2.68);
            double CorrectValue3 = 2680;
            Assert.AreEqual(CorrectValue3, TestValue3);

            IMeasurementConverter measurementConverter4 = new Resistance("MΩ");
            double TestValue4 = measurementConverter4.ToStandardValue(87.6);
            double CorrectValue4 = 87600000;
            Assert.AreEqual(CorrectValue4, TestValue4);
        }

        //系统默认能量为焦（J）
        [TestMethod()]
        public void 能量测试()
        {
            IMeasurementConverter measurementConverter1 = new Energy("J");
            double TestValue1 = measurementConverter1.ToStandardValue(509.55);
            double CorrectValue1 = 509.55;
            Assert.AreEqual(CorrectValue1, TestValue1);

            IMeasurementConverter measurementConverter2 = new Energy("mJ");
            double TestValue2 = measurementConverter2.ToStandardValue(0.26569114);
            double CorrectValue2 = 265691.14;
            Assert.AreEqual(CorrectValue2, TestValue2);
        }
    }
}
