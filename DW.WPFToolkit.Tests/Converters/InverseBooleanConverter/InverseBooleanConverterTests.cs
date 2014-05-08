using System.Globalization;
using DW.WPFToolkit.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.WPFToolkit.Tests.Converters
{
    [TestClass]
    public class InverseBooleanConverterTests
    {
        private InverseBooleanConverter _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new InverseBooleanConverter();
        }

        [TestMethod]
        public void Convert_ValueIsNotBoolean_ReturnsFalse()
        {
            var result = _target.Convert("hans", typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void Convert_ValeIsTrue_ReturnsFalse()
        {
            var result = _target.Convert(true, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Convert_ValeIsFalse_ReturnsTrue()
        {
            var result = _target.Convert(false, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void Convert_ValeIsNullableTrue_ReturnsFalse()
        {
            var result = _target.Convert(new bool?(true), typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void Convert_ValeIsNullableFalse_ReturnsTrue()
        {
            var result = _target.Convert(new bool?(false), typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void Convert_ValeIsNullableNull_ReturnsFalse()
        {
            var result = _target.Convert(new bool?(), typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }




        [TestMethod]
        public void ConvertBack_ValueIsNotBoolean_ReturnsFalse()
        {
            var result = _target.ConvertBack("hans", typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValeIsTrue_ReturnsFalse()
        {
            var result = _target.ConvertBack(true, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValeIsFalse_ReturnsTrue()
        {
            var result = _target.ConvertBack(false, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValeIsNullableTrue_ReturnsFalse()
        {
            var result = _target.ConvertBack(new bool?(true), typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValeIsNullableFalse_ReturnsTrue()
        {
            var result = _target.ConvertBack(new bool?(false), typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValeIsNullableNull_ReturnsFalse()
        {
            var result = _target.ConvertBack(new bool?(), typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }
    }
}
