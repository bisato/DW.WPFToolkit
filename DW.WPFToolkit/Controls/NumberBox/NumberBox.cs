using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.TextBox" /> to accept numeric values only, so the text can be bound to a numeric property direclty without converting.
    /// </summary>
    public class NumberBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.WPFToolkit.Controls.NumberBox" /> class.
        /// </summary>
        public NumberBox()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, null, CanPasteCommand));
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
            if ((input.Equals("-", StringComparison.Ordinal)) &&
                GetMinimum() < 0)
                return true;
            else
            {
                if (NumberType == NumberTypes.Integer)
                {
                    int value = 0;
                    if (int.TryParse(input, System.Globalization.NumberStyles.Integer, CultureInfo.CurrentUICulture, out value) &&
                        IsValidRange(value))
                        return true;
                    else
                        return false;
                }
                else
                {
                    double value = 0;
                    if (double.TryParse(input, System.Globalization.NumberStyles.Float, CultureInfo.CurrentUICulture, out value) &&
                        IsValidRange(value))
                        return true;
                    return false;
                }
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
            if ((value >= GetMinimum()) &&
                (value <= GetMaximum()))
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
