using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_HourBox", Type = typeof(NumberBox))]
    [TemplatePart(Name = "PART_MinuteBox", Type = typeof(NumberBox))]
    [TemplatePart(Name = "PART_SecondBox", Type = typeof(NumberBox))]
    [TemplatePart(Name = "PART_UpButton", Type = typeof(NumericUpDownButton))]
    [TemplatePart(Name = "PART_DownButton", Type = typeof(NumericUpDownButton))]
    public class TimeBox : Control
    {
        static TimeBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeBox), new FrameworkPropertyMetadata(typeof(TimeBox)));
        }

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
            var numberBox = GetTemplateChild(name) as NumericUpDownButton;
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
            int value = box.AsInt + step;
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
                Time = new TimeSpan(_hourBox.AsInt,
                                    _minuteBox.AsInt,
                                    TimeFormat == TimeFormat.Long ? _secondBox.AsInt : 0);
                _selfChange = false;
            }
        }
    }
}
