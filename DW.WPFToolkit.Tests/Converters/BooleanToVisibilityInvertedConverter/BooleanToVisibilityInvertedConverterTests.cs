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
using System.Windows;
using DW.WPFToolkit.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DW.WPFToolkit.Tests.Converters
{
    [TestClass]
    public class BooleanToVisibilityInvertedConverterTests
    {
        private BooleanToVisibilityInvertedConverter _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new BooleanToVisibilityInvertedConverter();
        }

        [TestMethod]
        public void Convert_ValueIsNotABoolean_ReturnsVisible()
        {
            var result = _target.Convert("hans", typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_ValueIsTrue_ReturnsCollapsed()
        {
            var result = _target.Convert(true, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_ValueIsFalse_ReturnsVisible()
        {
            var result = _target.Convert(false, typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_ValueIsNullableTrue_ReturnsCollapsed()
        {
            var result = _target.Convert(new bool?(true), typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_ValueIsNullableFalse_ReturnsVisible()
        {
            var result = _target.Convert(new bool?(false), typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_ValueIsNullableNull_ReturnsVisible()
        {
            var result = _target.Convert(new bool?(), typeof(Visibility), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void ConvertBack_ValueIsNotVisible_ReturnsFalse()
        {
            var result = _target.ConvertBack("hans", typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValueIsVisible_ReturnsFalse()
        {
            var result = _target.ConvertBack(Visibility.Visible, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValueIsCollapsed_ReturnsTrue()
        {
            var result = _target.ConvertBack(Visibility.Collapsed, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void ConvertBack_ValueIsHidden_ReturnsFalse()
        {
            var result = _target.ConvertBack(Visibility.Hidden, typeof(bool), null, CultureInfo.InvariantCulture);

            Assert.IsFalse((bool)result);
        }
    }
}
