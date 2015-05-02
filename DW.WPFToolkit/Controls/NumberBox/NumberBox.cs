#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2015 David Wendland

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
    [TemplatePart(Name = "PART_ResetButton", Type = typeof(Button))]
    public class NumberBox : TextBox
    {
        static NumberBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberBox), new FrameworkPropertyMetadata(typeof(NumberBox)));
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
            var resetButton = GetTemplateChild("PART_ResetButton") as Button;

            if (upButton != null)
                upButton.Click += HandleUpButtonClick;
            if (downButton != null)
                downButton.Click += HandleDownButtonClick;
            if (resetButton != null)
                resetButton.Click += HandleResetButtonClick;
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

        private void HandleResetButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Text = DefaultValue == null ? string.Empty : DefaultValue.ToString();
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
        /// Gets or sets a value that indicates if the NumberBox has up and down buttons.
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


        /// <summary>
        /// Gets or sets a value that indicates if the NumberBox has a button to reset the value
        /// </summary>
        [DefaultValue(false)]
        public bool HasResetButton
        {
            get { return (bool)GetValue(HasResetButtonProperty); }
            set { SetValue(HasResetButtonProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.HasResetButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HasResetButtonProperty =
            DependencyProperty.Register("HasResetButton", typeof(bool), typeof(NumberBox), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets the default value to be used when the reset button is pressed.
        /// </summary>
        [DefaultValue(0.0)]
        public object DefaultValue
        {
            get { return (object)GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.DefaultValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.Register("DefaultValue", typeof(object), typeof(NumberBox), new PropertyMetadata(0.0));

        /// <summary>
        /// Gets or sets a value that indicates if the NumberBox contains a checkbox.
        /// </summary>
        public bool IsCheckable
        {
            get { return (bool)GetValue(IsCheckableProperty); }
            set { SetValue(IsCheckableProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.IsCheckable" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsCheckableProperty =
            DependencyProperty.Register("IsCheckable", typeof(bool), typeof(NumberBox), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value that indicates of the NumberBox is checked or not.
        /// </summary>
        [DefaultValue(false)]
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.IsChecked" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(NumberBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Gets or sets a value that indicates if the NumberBox gets enabled or disabled depending on the IsChecked state.
        /// </summary>
        [DefaultValue(true)]
        public bool DisabledOnUncheck
        {
            get { return (bool)GetValue(DisabledOnUncheckProperty); }
            set { SetValue(DisabledOnUncheckProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.NumberBox.DisabledOnUncheck" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DisabledOnUncheckProperty =
            DependencyProperty.Register("DisabledOnUncheck", typeof(bool), typeof(NumberBox), new PropertyMetadata(true));

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
