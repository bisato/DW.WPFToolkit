using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.TextBox" /> to accept numeric values only, so the text can be bound to a numeric property direclty without converting.
    /// </summary>
    [TemplatePart(Name = "PART_UpButton", Type = typeof(RepeatButton))]
    [TemplatePart(Name = "PART_DownButton", Type = typeof(RepeatButton))]
    public class NumberBox : TextBox
    {
        static NumberBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberBox), new FrameworkPropertyMetadata(typeof(NumberBox)));
#if TRIAL
            License1.License.Display();
#endif
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Controls.NumberBox" /> class.
        /// </summary>
        public NumberBox()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, null, CanPasteCommand));

            MouseWheel += OnMouseWheel;
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!HasUpDownButtons)
                return;

            if (e.Delta > 0)
                HandleUpButtonClick(sender, e);
            else
                HandleDownButtonClick(sender, e);
        }

        /// <summary>
        /// The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var upButton = GetTemplateChild("PART_UpButton") as RepeatButton;
            var downButton = GetTemplateChild("PART_DownButton") as RepeatButton;

            if (upButton != null)
                upButton.Click += HandleUpButtonClick;
            if (downButton != null)
                downButton.Click += HandleDownButtonClick;
        }

        private void HandleUpButtonClick(object sender, RoutedEventArgs e)
        {
            double value = 0;
            double.TryParse(Text, out value);
            value += Step;
            if (value <= GetMaximum())
                Text = value.ToString(CultureInfo.CurrentUICulture);
        }

        private void HandleDownButtonClick(object sender, RoutedEventArgs e)
        {
            double value = 0;
            double.TryParse(Text, out value);
            value -= Step;
            if (value >= GetMinimum())
                Text = value.ToString(CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Gets or sets the minimum value allowed in the text box.
        /// </summary>
        public object Minimum
        {
            get { return (object)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.Minimum" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(object), typeof(NumberBox));

        /// <summary>
        /// Gets or sets the maximum value allowed in the text box.
        /// </summary>
        public object Maximum
        {
            get { return (object)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.Maximum" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(object), typeof(NumberBox));

        /// <summary>
        /// Gets or sets a value that indicated which type of numbers are allowed to type in.
        /// </summary>
        [DefaultValue(NumberTypes.Integer)]
        public NumberTypes NumberType
        {
            get { return (NumberTypes)GetValue(NumberTypeProperty); }
            set { SetValue(NumberTypeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.NumberType" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty NumberTypeProperty =
            DependencyProperty.Register("NumberType", typeof(NumberTypes), typeof(NumberBox), new UIPropertyMetadata(NumberTypes.Integer));

        /// <summary>
        /// Gets or sets the step width to be used by the up or down buttons.
        /// </summary>
        [DefaultValue(1.0)]
        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.Step" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(double), typeof(NumberBox), new PropertyMetadata(1.0));

        /// <summary>
        /// Gets or sets a value that indicates if the numberbox has up and down buttons.
        /// </summary>
        [DefaultValue(false)]
        public bool HasUpDownButtons
        {
            get { return (bool)GetValue(HasUpDownButtonsProperty); }
            set { SetValue(HasUpDownButtonsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.HasUpDownButtons" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HasUpDownButtonsProperty =
            DependencyProperty.Register("HasUpDownButtons", typeof(bool), typeof(NumberBox), new PropertyMetadata(false));

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

        private bool Parse(TextBox box, string insertText)
        {
            string input = box.Text;
            input = input.Remove(box.SelectionStart, box.SelectionLength);
            input = input.Insert(box.SelectionStart, insertText);
            if ((input.Equals("-", StringComparison.Ordinal)) && GetMinimum() < 0)
                return true;
            
            if (NumberType == NumberTypes.Integer)
            {
                var value = 0;
                if (int.TryParse(input, System.Globalization.NumberStyles.Integer, CultureInfo.CurrentUICulture, out value) && IsValidRange(value))
                    return true;
                return false;
            }
            else
            {
                double value = 0;
                if (double.TryParse(input, System.Globalization.NumberStyles.Float, CultureInfo.CurrentUICulture, out value) && IsValidRange(value))
                    return true;
                return false;
            }
        }

        private void CanPasteCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            if (Clipboard.ContainsText())
            {
                if (Parse(sender as TextBox, Clipboard.GetText()))
                    e.CanExecute = true;
            }
            e.Handled = true;
        }

        private bool IsValidRange(double value)
        {
            if ((value >= GetMinimum()) && (value <= GetMaximum()))
                return true;
            return false;
        }

        /// <summary>
        /// Handles key down in the text box.
        /// </summary>
        /// <param name="e">The parameter called by the owner.</param>
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;

            if (!HasUpDownButtons)
                return;

            if (e.Key == Key.Up)
                HandleUpButtonClick(null, null);
            else if (e.Key == Key.Down)
                HandleDownButtonClick(null, null);
        }

        /// <summary>
        /// Handles user input in the text box.
        /// </summary>
        /// <param name="e">The parameter called by the owner.</param>
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (Parse(this, e.Text))
                base.OnPreviewTextInput(e);
            else
                e.Handled = true;
        }

        /// <summary>
        /// Returns the written value as integer if possible; otherwise 0.
        /// </summary>
        /// <returns>The written value as integer if possible; otherwise 0.</returns>
        public int GetInteger()
        {
            int value;
            if (int.TryParse(Text, System.Globalization.NumberStyles.Integer, CultureInfo.CurrentUICulture, out value) && IsValidRange(value))
                return value;
            return 0;
        }

        /// <summary>
        /// Returns the written value as double if possible; otherwise 0.0
        /// </summary>
        /// <returns>The written value as double if possible; otherwise 0.0</returns>
        public double GetDouble()
        {
            double value;
            if (double.TryParse(Text, System.Globalization.NumberStyles.Float, CultureInfo.CurrentUICulture, out value) && IsValidRange(value))
                return value;
            return 0;
        }
    }
}
