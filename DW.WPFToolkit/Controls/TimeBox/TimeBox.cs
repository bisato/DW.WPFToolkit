﻿#region License
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Shows textboxes to let the user input a time.
    /// </summary>
    /// <example>
    /// <code lang="XAML">
    /// <![CDATA[
    /// <WPFToolkit:TimeBox HasUpDownButtons="True" TimeFormat="Long" Time="{Binding CurrentTime}" />
    /// ]]>
    /// </code>
    /// </example>
    [TemplatePart(Name = "PART_HourBox", Type = typeof(NumberBox))]
    [TemplatePart(Name = "PART_MinuteBox", Type = typeof(NumberBox))]
    [TemplatePart(Name = "PART_SecondBox", Type = typeof(NumberBox))]
    [TemplatePart(Name = "PART_UpButton", Type = typeof(UpDownButton))]
    [TemplatePart(Name = "PART_DownButton", Type = typeof(UpDownButton))]
    public class TimeBox : Control
    {
        static TimeBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeBox), new FrameworkPropertyMetadata(typeof(TimeBox)));
        }

        /// <summary>
        /// Gets or sets the time shown in the text box.
        /// </summary>
        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TimeBox.Time" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(TimeSpan), typeof(TimeBox), new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTimeChanged));

        /// <summary>
        /// Gets or sets the format of the time the user can edit.
        /// </summary>
        [DefaultValue(TimeFormat.Short)]
        public TimeFormat TimeFormat
        {
            get { return (TimeFormat)GetValue(TimeFormatProperty); }
            set { SetValue(TimeFormatProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TimeBox.TimeFormat" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TimeFormatProperty =
            DependencyProperty.Register("TimeFormat", typeof(TimeFormat), typeof(TimeBox), new UIPropertyMetadata(TimeFormat.Short));

        /// <summary>
        /// Gets or sets a value that indicates if the time box has up down buttons or not.
        /// </summary>
        [DefaultValue(true)]
        public bool HasUpDownButtons
        {
            get { return (bool)GetValue(HasUpDownButtonsProperty); }
            set { SetValue(HasUpDownButtonsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.TimeBox.HasUpDownButtons" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HasUpDownButtonsProperty =
            DependencyProperty.Register("HasUpDownButtons", typeof(bool), typeof(TimeBox), new UIPropertyMetadata(true));

        private NumberBox _focusedBox;
        private NumberBox _hourBox;
        private NumberBox _minuteBox;
        private NumberBox _secondBox;
        private bool _selfChange;

        private static void OnTimeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (TimeBox)sender;
            if (!control._selfChange &&
                control.IsLoaded)
            {
                control.TakeTime();
            }
        }

        /// <summary>
        /// The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _hourBox = CatchBox("PART_HourBox");
            _minuteBox = CatchBox("PART_MinuteBox");
            _secondBox = CatchBox("PART_SecondBox");
            CatchButton("PART_UpButton", new RoutedEventHandler(Up_Click));
            CatchButton("PART_DownButton", new RoutedEventHandler(Down_Click));

            TakeTime();
        }

        private void TakeTime()
        {
            _selfChange = true;
            _hourBox.Text = Time.Hours.ToString();
            _minuteBox.Text = Time.Minutes.ToString();
            _secondBox.Text = Time.Seconds.ToString();
            _selfChange = false;
        }

        private NumberBox CatchBox(string name)
        {
            var numberBox = GetTemplateChild(name) as NumberBox;
            if (numberBox != null)
            {
                numberBox.TextChanged += new TextChangedEventHandler(NumberBox_TextChanged);
                numberBox.PreviewKeyDown += new KeyEventHandler(NumberBox_PreviewKeyDown);
                numberBox.KeyUp += new KeyEventHandler(NumberBox_KeyUp);
                numberBox.GotFocus += new RoutedEventHandler(NumberBox_GotFocus);
            }
            return numberBox;
        }

        private void CatchButton(string name, RoutedEventHandler handler)
        {
            var numberBox = GetTemplateChild(name) as UpDownButton;
            if (numberBox != null)
                numberBox.Click += handler;
        }

        private void NumberBox_GotFocus(object sender, RoutedEventArgs e)
        {
            _focusedBox = (NumberBox)sender;
        }

        private void NumberBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var box = (NumberBox)sender;
            switch (e.Key)
            {
                case Key.Up:
                    ChangeValue(box, 1);
                    break;
                case Key.Down:
                    ChangeValue(box, -1);
                    break;
                case Key.Left:
                    MoveCarretLeft(box);
                    break;
                case Key.Right:
                    MoveCarretRight(box);
                    break;
            }
            
        }

        private void NumberBox_KeyUp(object sender, KeyEventArgs e)
        {
            var box = (NumberBox)sender;
            if (IsNumeric(e.Key) &&
                box.Text.Length == 2)
            {
                MoveCarretRight(box);
            }
        }

        private bool IsNumeric(Key key)
        {
            return (key >= Key.D0 && key <= Key.D9) ||
                   (key >= Key.NumPad0 && key <= Key.NumPad9);
        }

        private void MoveCarretLeft(NumberBox numberBox)
        {
            if (numberBox.SelectionStart == 0)
                MoveCarret(numberBox, FocusNavigationDirection.Left);
        }

        private void MoveCarretRight(NumberBox numberBox)
        {
            if (numberBox.Text.Length == numberBox.SelectionStart)
                MoveCarret(numberBox, FocusNavigationDirection.Right);
        }

        private void MoveCarret(NumberBox numberBox, FocusNavigationDirection direction)
        {
            if (numberBox.SelectionLength == 0)
                numberBox.MoveFocus(new TraversalRequest(direction));
        }
        
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (_focusedBox != null)
                ChangeValue(_focusedBox, 1);
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (_focusedBox != null)
                ChangeValue(_focusedBox, -1);
        }

        private void ChangeValue(NumberBox box, int step)
        {
            int value = box.GetInteger() + step;
            if (value >= 60)
                value -= 60;
            else if (value <= -1)
                value += 60;
            box.Text = value.ToString();
        }

        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_selfChange)
            {
                _selfChange = true;
                Time = new TimeSpan(_hourBox.GetInteger(),
                                    _minuteBox.GetInteger(),
                                    TimeFormat == TimeFormat.Long ? _secondBox.GetInteger() : 0);
                _selfChange = false;
            }
        }
    }
}
