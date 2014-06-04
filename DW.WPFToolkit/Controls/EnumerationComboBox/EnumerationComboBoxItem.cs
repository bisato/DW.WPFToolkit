#region License
/*--------------------------------------------------------------------------------
    Copyright (c) 2009-2013 David Wendland

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
    THE SOFTWARE.
--------------------------------------------------------------------------------*/
#endregion License

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit
{
    /// <summary>
    /// Represents an item inside the EnumerationComboBox which holds the appropriate enumeration object
    /// </summary>
    public class EnumerationComboBoxItem : ContentControl
    {
        /// <summary>
        /// Gets or sets the enumeration this items represents
        /// </summary>
        /// <value>If not set: null</value>
        [Category("Common Properties")]
        [Description("Gets or sets the enumeration this items represents")]
        [DefaultValue(null)]
        public Enum Enum
        {
            get { return (Enum)GetValue(EnumProperty); }
            set { SetValue(EnumProperty, value); }
        }

        /// <summary>
        /// Identifies the Enum dependency property
        /// </summary>
        public static readonly DependencyProperty EnumProperty =
            DependencyProperty.Register("Enum", typeof(Enum), typeof(EnumerationComboBoxItem), new UIPropertyMetadata(OnEnumChanged));

        private static void OnEnumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EnumerationComboBoxItem)sender;
            if (control.Content == null)
                control.Content = e.NewValue.ToString();
        }
    }
}
