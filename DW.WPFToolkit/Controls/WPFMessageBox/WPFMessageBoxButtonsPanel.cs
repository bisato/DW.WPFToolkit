using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_SingleOKButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_OKButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_YesButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_YesToAllButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_NoButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_NoToAllButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_RetryButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_IgnoreButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_AbortButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_HelpButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_TryAgainButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ContinueButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_DoNotShowAgainCheckBox", Type = typeof(CheckBox))]
    [TemplatePart(Name = "PART_DetailsExpander", Type = typeof(Expander))]
    public class WPFMessageBoxButtonsPanel : Control
    {
        static WPFMessageBoxButtonsPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxButtonsPanel), new FrameworkPropertyMetadata(typeof(WPFMessageBoxButtonsPanel)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            AddHandler(ButtonBase.ClickEvent, (RoutedEventHandler)OnMessageBoxButtonClick);
        }

        private void OnMessageBoxButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (ButtonBase)e.OriginalSource;
            switch (button.Name)
            {
                case "PART_SingleOKButton":
                    Result = WPFMessageBoxResult.OK;
                    break;
                case "PART_OKButton":
                    Result = WPFMessageBoxResult.OK;
                    break;
                case "PART_YesButton":
                    Result = WPFMessageBoxResult.Yes;
                    break;
                case "PART_YesToAllButton":
                    Result = WPFMessageBoxResult.YesToAll;
                    break;
                case "PART_NoButton":
                    Result = WPFMessageBoxResult.No;
                    break;
                case "PART_NoToAllButton":
                    Result = WPFMessageBoxResult.NoToAll;
                    break;
                case "PART_RetryButton":
                    Result = WPFMessageBoxResult.Retry;
                    break;
                case "PART_IgnoreButton":
                    Result = WPFMessageBoxResult.Ignore;
                    break;
                case "PART_CancelButton":
                    Result = WPFMessageBoxResult.Cancel;
                    break;
                case "PART_AbortButton":
                    Result = WPFMessageBoxResult.Abort;
                    break;
                case "PART_TryAgainButton":
                    Result = WPFMessageBoxResult.Retry;
                    break;
                case "PART_ContinueButton":
                    Result = WPFMessageBoxResult.Continue;
                    break;
                case "PART_HelpButton":
                    OnHelpRequest();
                    return;
                default:
                    return;
            }
            OnClick();
        }

        internal void SetDefaultButton()
        {
            switch (DefaultButton)
            {
                case WPFMessageBoxResult.Abort:
                    SetDefaultButton("PART_AbortButton");
                    break;
                case WPFMessageBoxResult.Cancel:
                    SetDefaultButton("PART_CancelButton");
                    break;
                case WPFMessageBoxResult.Ignore:
                    SetDefaultButton("PART_IgnoreButton");
                    break;
                case WPFMessageBoxResult.No:
                    SetDefaultButton("PART_NoButton");
                    break;
                case WPFMessageBoxResult.None:
                    CalculateDefaultButton();
                    break;
                case WPFMessageBoxResult.Continue:
                    SetDefaultButton("PART_ContinueButton");
                    break;
                case WPFMessageBoxResult.OK:
                    if (Buttons == WPFMessageBoxButtons.OK)
                        SetDefaultButton("PART_SingleOKButton");
                    else
                        SetDefaultButton("PART_OKButton");
                    break;
                case WPFMessageBoxResult.Retry:
                    if (!SetDefaultButton("PART_TryAgainButton"))
                        SetDefaultButton("PART_RetryButton");
                    break;
                case WPFMessageBoxResult.Yes:
                    SetDefaultButton("PART_YesButton");
                    break;
                case WPFMessageBoxResult.YesToAll:
                    SetDefaultButton("PART_YesToAllButton");
                    break;
                case WPFMessageBoxResult.NoToAll:
                    SetDefaultButton("PART_NoToAllButton");
                    break;
            }
        }

        private void CalculateDefaultButton()
        {
            switch (Buttons)
            {
                case WPFMessageBoxButtons.OK:
                    SetDefaultButton("PART_SingleOKButton");
                    break;
                case WPFMessageBoxButtons.OKCancel:
                    SetDefaultButton("PART_OKButton");
                    break;
                case WPFMessageBoxButtons.RetryCancel:
                case WPFMessageBoxButtons.AbortRetryIgnore:
                    SetDefaultButton("PART_RetryButton");
                    break;
                case WPFMessageBoxButtons.YesNo:
                case WPFMessageBoxButtons.YesNoCancel:
                    SetDefaultButton("PART_YesButton");
                    break;
                case WPFMessageBoxButtons.CancelTryAgainContinue:
                    SetDefaultButton("PART_TryAgainButton");
                    break;
            }
        }

        private bool SetDefaultButton(string elementName)
        {
            var button = GetTemplateChild(elementName) as UIElement;
            if (button != null && button.Visibility == Visibility.Visible)
            {
                button.Focus();
                Keyboard.Focus(button);
                return true;
            }
            
            CalculateDefaultButton();
            return false;
        }

        public WPFMessageBoxResult Result
        {
            get { return (WPFMessageBoxResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(WPFMessageBoxResult), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(WPFMessageBoxResult.None));

        public WPFMessageBoxButtons Buttons
        {
            get { return (WPFMessageBoxButtons)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(WPFMessageBoxButtons), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(WPFMessageBoxButtons.OK));

        public WPFMessageBoxResult DefaultButton
        {
            get { return (WPFMessageBoxResult)GetValue(DefaultButtonProperty); }
            set { SetValue(DefaultButtonProperty, value); }
        }

        public static readonly DependencyProperty DefaultButtonProperty =
            DependencyProperty.Register("DefaultButton", typeof(WPFMessageBoxResult), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(WPFMessageBoxResult.None));

        public MessageBoxStrings Strings
        {
            get { return (MessageBoxStrings)GetValue(StringsProperty); }
            set { SetValue(StringsProperty, value); }
        }

        public static readonly DependencyProperty StringsProperty =
            DependencyProperty.Register("Strings", typeof(MessageBoxStrings), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(null));

        public bool ShowHelpButton
        {
            get { return (bool)GetValue(ShowHelpButtonProperty); }
            set { SetValue(ShowHelpButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowHelpButtonProperty =
            DependencyProperty.Register("ShowHelpButton", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(false));

        public bool ShowYesToAllButton
        {
            get { return (bool)GetValue(ShowYesToAllButtonProperty); }
            set { SetValue(ShowYesToAllButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowYesToAllButtonProperty =
            DependencyProperty.Register("ShowYesToAllButton", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(false));

        public bool ShowNoToAllButton
        {
            get { return (bool)GetValue(ShowNoToAllButtonProperty); }
            set { SetValue(ShowNoToAllButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowNoToAllButtonProperty =
            DependencyProperty.Register("ShowNoToAllButton", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new PropertyMetadata(false));
        
        public bool ShowDoNotShowAgainCheckBox
        {
            get { return (bool)GetValue(ShowDoNotShowAgainCheckBoxProperty); }
            set { SetValue(ShowDoNotShowAgainCheckBoxProperty, value); }
        }

        public static readonly DependencyProperty ShowDoNotShowAgainCheckBoxProperty =
            DependencyProperty.Register("ShowDoNotShowAgainCheckBox", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new UIPropertyMetadata(false));

        public bool IsDoNotShowAgainChecked
        {
            get { return (bool)GetValue(IsDoNotShowAgainCheckedProperty); }
            set { SetValue(IsDoNotShowAgainCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsDoNotShowAgainCheckedProperty =
            DependencyProperty.Register("IsDoNotShowAgainChecked", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new UIPropertyMetadata(false));

        public bool ShowDetails
        {
            get { return (bool)GetValue(ShowDetailsProperty); }
            set { SetValue(ShowDetailsProperty, value); }
        }

        public static readonly DependencyProperty ShowDetailsProperty =
            DependencyProperty.Register("ShowDetails", typeof(bool), typeof(WPFMessageBoxButtonsPanel), new UIPropertyMetadata(false));

        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WPFMessageBoxButtonsPanel));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        private void OnClick()
        {
            var newEventArgs = new RoutedEventArgs(WPFMessageBoxButtonsPanel.ClickEvent);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent HelpRequestEvent = EventManager.RegisterRoutedEvent("HelpRequest", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WPFMessageBoxButtonsPanel));

        public event RoutedEventHandler HelpRequest
        {
            add { AddHandler(HelpRequestEvent, value); }
            remove { RemoveHandler(HelpRequestEvent, value); }
        }

        private void OnHelpRequest()
        {
            var newEventArgs = new RoutedEventArgs(WPFMessageBoxButtonsPanel.HelpRequestEvent);
            RaiseEvent(newEventArgs);
        }
    }
}
