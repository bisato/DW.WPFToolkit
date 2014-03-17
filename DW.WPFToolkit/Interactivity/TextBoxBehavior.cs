using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Interactivity
{
    public class TextBoxBehavior : DependencyObject
    {
        public static string GetSelectedText(DependencyObject obj)
        {
            return (string)obj.GetValue(SelectedTextProperty);
        }

        public static void SetSelectedText(DependencyObject obj, string value)
        {
            obj.SetValue(SelectedTextProperty, value);
        }

        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.RegisterAttached("SelectedText", typeof(string), typeof(TextBoxBehavior), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedTextChanged));

        public static bool GetSelectAllOnFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(SelectAllOnFocusProperty);
        }

        public static void SetSelectAllOnFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(SelectAllOnFocusProperty, value);
        }

        public static readonly DependencyProperty SelectAllOnFocusProperty =
            DependencyProperty.RegisterAttached("SelectAllOnFocus", typeof(bool), typeof(TextBoxBehavior), new UIPropertyMetadata(OnSelectAllOnFocusChanged));

        private static TextBoxBehavior GetTextTextBoxBehavior(DependencyObject obj)
        {
            return (TextBoxBehavior)obj.GetValue(TextTextBoxBehaviorProperty);
        }

        private static void SetTextTextBoxBehavior(DependencyObject obj, TextBoxBehavior value)
        {
            obj.SetValue(TextTextBoxBehaviorProperty, value);
        }

        private static readonly DependencyProperty TextTextBoxBehaviorProperty =
            DependencyProperty.RegisterAttached("TextTextBoxBehavior", typeof(TextBoxBehavior), typeof(TextBoxBehavior), new UIPropertyMetadata(null));

        private static TextBoxBehavior GetAllTextBoxBehavior(DependencyObject obj)
        {
            return (TextBoxBehavior)obj.GetValue(AllTextBoxBehaviorProperty);
        }

        private static void SetAllTextBoxBehavior(DependencyObject obj, TextBoxBehavior value)
        {
            obj.SetValue(AllTextBoxBehaviorProperty, value);
        }

        private static readonly DependencyProperty AllTextBoxBehaviorProperty =
            DependencyProperty.RegisterAttached("AllTextBoxBehavior", typeof(TextBoxBehavior), typeof(TextBoxBehavior), new UIPropertyMetadata(null));

        public static Key GetRefreshBindingOnKey(DependencyObject obj)
        {
            return (Key)obj.GetValue(RefreshBindingOnKeyProperty);
        }

        public static void SetRefreshBindingOnKey(DependencyObject obj, Key value)
        {
            obj.SetValue(RefreshBindingOnKeyProperty, value);
        }

        public static readonly DependencyProperty RefreshBindingOnKeyProperty =
            DependencyProperty.RegisterAttached("RefreshBindingOnKey", typeof(Key), typeof(TextBoxBehavior), new UIPropertyMetadata(OnRefreshBindingOnKeyChanged));

        private static void OnRefreshBindingOnKeyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBox = GetTextBox(sender);
            textBox.KeyUp += new KeyEventHandler(TextBox_KeyUp);
        }

        private static void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            var box = (TextBox)sender;
            if (e.Key == GetRefreshBindingOnKey(box))
            {
                var expression = box.GetBindingExpression(TextBox.TextProperty);
                expression.UpdateSource();
            }
        }

        private static void OnSelectedTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBox = GetTextBox(sender);
            var behavior = GetTextTextBoxBehavior(sender);
            if (behavior == null)
            {
                behavior = new TextBoxBehavior();
                SetTextTextBoxBehavior(sender, behavior);
                textBox.SelectionChanged += new RoutedEventHandler(behavior.TextBox_SelectionChanged);
            }
            behavior.RunSetSelectedText(textBox, e.NewValue);
        }

        private bool _selfChange;
        private void RunSetSelectedText(TextBox textbox, object param)
        {
            if (!_selfChange &&
                param != null)
                SelectText(textbox, false, param.ToString());
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            _selfChange = true;
            var textBox = (TextBox)sender;
            SetSelectedText(textBox, textBox.SelectedText);
            _selfChange = false;
        }

        private static void OnSelectAllOnFocusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBox = GetTextBox(sender);
            var behavior = GetAllTextBoxBehavior(sender);
            if (behavior == null)
            {
                behavior = new TextBoxBehavior();
                SetAllTextBoxBehavior(sender, behavior);
                textBox.GotFocus += new RoutedEventHandler(behavior.TextBox_GotFocus);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            SelectText(textBox, true, null);
        }

        private static TextBox GetTextBox(DependencyObject sender)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                throw new InvalidOperationException("The TextBoxBehavior.SelectionStart only can be attached on a TextBox control");
            return textBox;
        }

        private void SelectText(TextBox box, bool selectAll, string text)
        {
            ControlFocus.GiveFocus(box, delegate
                {
                    if (selectAll)
                        box.SelectAll();
                    else if (!string.IsNullOrEmpty(text))
                    {
                        int pos = box.Text.IndexOf(text);
                        if (pos > 0 &&
                            box.Text.Contains(text))
                            box.Select(pos, text.Length);
                    }
                });
        }
    }
}
