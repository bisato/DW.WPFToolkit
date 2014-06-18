using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents an item inside the <see cref="DW.WPFToolkit.Controls.EnumerationComboBox" /> which holds the appropriate enumeration object.
    /// </summary>
    public class EnumerationComboBoxItem : ContentControl
    {
        /// <summary>
        /// Gets or sets the enumeration this items represents.
        /// </summary>
        [DefaultValue(null)]
        public Enum Enum
        {
            get { return (Enum)GetValue(EnumProperty); }
            set { SetValue(EnumProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnumerationComboBoxItem.Enum" /> dependency property.
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
