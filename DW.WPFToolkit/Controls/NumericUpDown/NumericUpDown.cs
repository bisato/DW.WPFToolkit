using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Contains and enhances the <see cref="DW.WPFToolkit.Controls.NumberBox" /> by up and down buttons for changing the written numeric value.
    /// </summary>
    [TemplatePart(Name = "PART_UpButton", Type = typeof(RepeatButton))]
    [TemplatePart(Name = "PART_DownButton", Type = typeof(RepeatButton))]
    [TemplatePart(Name = "PART_NumberBox", Type = typeof(NumberBox))]
    public class NumericUpDown : Control
    {
        private NumberBox _box;

        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }

        /// <summary>
        /// The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var upButton = GetTemplateChild("PART_UpButton") as RepeatButton;
            var downButton = GetTemplateChild("PART_DownButton") as RepeatButton;
            _box = GetTemplateChild("PART_NumberBox") as NumberBox;

            if (upButton != null)
                upButton.Click += HandleUpButtonClick;
            if (downButton != null)
                downButton.Click += HandleDownButtonClick;
            if (_box != null)
                _box.PreviewKeyDown += HandleBoyKeyDown;
        }

        private void HandleBoyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
                HandleUpButtonClick(null, null);
            else if (e.Key == Key.Down)
                HandleDownButtonClick(null, null);
        }

        private double GetMinimum()
        {
            if (Minimum == null)
                return double.MinValue;
            double value = 0;
            if (double.TryParse(Minimum.ToString(), System.Globalization.NumberStyles.Float, CultureInfo.CurrentUICulture, out value))
                return value;
            return double.MinValue;
        }

        private double GetMaximum()
        {
            if (Maximum == null)
                return double.MaxValue;
            double value = 0;
            if (double.TryParse(Maximum.ToString(), System.Globalization.NumberStyles.Float, CultureInfo.CurrentUICulture, out value))
                return value;
            return double.MaxValue;
        }

        private void HandleUpButtonClick(object sender, RoutedEventArgs e)
        {
            UpdateTextBinding();
            double value = 0;
            double.TryParse(Text, out value);
            value += Step;
            if (value <= GetMaximum())
                Text = value.ToString(CultureInfo.CurrentUICulture);
        }

        private void UpdateTextBinding()
        {
            if (_box != null && _box.Text != Text)
                Text = _box.Text;
        }

        private void HandleDownButtonClick(object sender, RoutedEventArgs e)
        {
            UpdateTextBinding();
            double value = 0;
            double.TryParse(Text, out value);
            value -= Step;
            if (value >= GetMinimum())
                Text = value.ToString(CultureInfo.CurrentUICulture);
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumericUpDown.IsReadOnly" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(NumericUpDown), new UIPropertyMetadata(false));

        public object Minimum
        {
            get { return (object)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumericUpDown.Minimum" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(object), typeof(NumericUpDown), new UIPropertyMetadata(null));

        public object Maximum
        {
            get { return (object)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumericUpDown.Maximum" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(object), typeof(NumericUpDown), new UIPropertyMetadata(null));

        public NumberTypes NumberType
        {
            get { return (NumberTypes)GetValue(NumberTypeProperty); }
            set { SetValue(NumberTypeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumericUpDown.NumberType" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty NumberTypeProperty =
            DependencyProperty.Register("NumberType", typeof(NumberTypes), typeof(NumericUpDown), new UIPropertyMetadata(NumberTypes.Double));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumericUpDown.Text" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NumericUpDown), new FrameworkPropertyMetadata("0", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumericUpDown.Step" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(double), typeof(NumericUpDown), new UIPropertyMetadata(1.0));
        
        public int GetInteger()
        {
            var box = GetTemplateChild("PART_NumberBox") as NumberBox;
            if (box != null)
                return box.GetInteger();
            return 0;
        }

        public double GetDouble()
        {
            var box = GetTemplateChild("PART_NumberBox") as NumberBox;
            if (box != null)
                return box.GetDouble();
            return 0;
        }
    }
}
