using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a ComboBox which takes an enumeration value and shows all possible states inside the dropdown menu for let choosing a value
    /// </summary>
    public class EnumerationComboBox : Control
    {
        static EnumerationComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumerationComboBox), new FrameworkPropertyMetadata(typeof(EnumerationComboBox)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Controls.EnumerationComboBox"/> class.
        /// </summary>
        public EnumerationComboBox()
        {
            Items = new ObservableCollection<EnumerationComboBoxItem>();
        }

        private bool _selfChange;
        private bool _initialized;

        /// <summary>
        /// Gets or sets the enumeration value which the combobox uses.
        /// </summary>
        [DefaultValue(null)]
        public Enum Enum
        {
            get { return (Enum)GetValue(EnumProperty); }
            set { SetValue(EnumProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnumerationComboBox.Enum" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnumProperty =
            DependencyProperty.Register("Enum", typeof(Enum), typeof(EnumerationComboBox), new FrameworkPropertyMetadata(FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnEnumChanged));

        private static void OnEnumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EnumerationComboBox)sender;
            if (!control._initialized)
            {
                control._initialized = true;
                TakeValues(control);
            }
            
            if (!control._selfChange)
                SetSelectedItem(control, e.NewValue);
        }

        private static void TakeValues(EnumerationComboBox control)
        {
            foreach (var value in Enum.GetValues(control.Enum.GetType()))
                control.Items.Add(new EnumerationComboBoxItem { Enum = (Enum)value });
        }

        private static void SetSelectedItem(EnumerationComboBox control, object item)
        {
            control._selfChange = true;
            control.SelectedItem = control.Items.FirstOrDefault(i => i.Enum.ToString() == item.ToString());
            control._selfChange = false;
        }

        /// <summary>
        /// Gets or sets the items shown in the ComboBox.
        /// </summary>
        public ObservableCollection<EnumerationComboBoxItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the item selected in the combobox.
        /// </summary>
        public EnumerationComboBoxItem SelectedItem
        {
            get { return (EnumerationComboBoxItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnumerationComboBox.SelectedItem" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(EnumerationComboBoxItem), typeof(EnumerationComboBox), new UIPropertyMetadata(OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EnumerationComboBox)sender;
            control._selfChange = true;
            control.Enum = control.SelectedItem.Enum;
            control._selfChange = false;
        }
        
        /// <summary>
        /// Gets or sets the item template for the EnumerationComboBoxItems.
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnumerationComboBox.ItemTemplate" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(EnumerationComboBox), new UIPropertyMetadata(null));
    }
}
