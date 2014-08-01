#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2014 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

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
