using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    public class DynamicTabControl : TabControl
    {
        static DynamicTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicTabControl), new FrameworkPropertyMetadata(typeof(DynamicTabControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DynamicTabItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DynamicTabItem;
        }

        public bool ShowCloseButtons
        {
            get { return (bool)GetValue(ShowCloseButtonsProperty); }
            set { SetValue(ShowCloseButtonsProperty, value); }
        }

        public static readonly DependencyProperty ShowCloseButtonsProperty =
            DependencyProperty.Register("ShowCloseButtons", typeof(bool), typeof(DynamicTabControl), new UIPropertyMetadata(true));

        public bool ShowAddButton
        {
            get { return (bool)GetValue(ShowAddButtonProperty); }
            set { SetValue(ShowAddButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowAddButtonProperty =
            DependencyProperty.Register("ShowAddButton", typeof(bool), typeof(DynamicTabControl), new UIPropertyMetadata(true));

        public ICommand TabItemClosingCommand
        {
            get { return (ICommand)GetValue(TabItemClosingCommandProperty); }
            set { SetValue(TabItemClosingCommandProperty, value); }
        }

        public static readonly DependencyProperty TabItemClosingCommandProperty =
            DependencyProperty.Register("TabItemClosingCommand", typeof(ICommand), typeof(DynamicTabControl), new UIPropertyMetadata(null));

        public object TabItemAddingCommandParameter
        {
            get { return (object)GetValue(TabItemAddingCommandParameterProperty); }
            set { SetValue(TabItemAddingCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty TabItemAddingCommandParameterProperty =
            DependencyProperty.Register("TabItemAddingCommandParameter", typeof(object), typeof(DynamicTabControl), new UIPropertyMetadata(null));

        public ICommand TabItemAddingCommand
        {
            get { return (ICommand)GetValue(TabItemAddingCommandProperty); }
            set { SetValue(TabItemAddingCommandProperty, value); }
        }

        public static readonly DependencyProperty TabItemAddingCommandProperty =
            DependencyProperty.Register("TabItemAddingCommand", typeof(ICommand), typeof(DynamicTabControl), new UIPropertyMetadata(null));

        public Thickness AddButtonMargin
        {
            get { return (Thickness)GetValue(AddButtonMarginProperty); }
            set { SetValue(AddButtonMarginProperty, value); }
        }

        public static readonly DependencyProperty AddButtonMarginProperty =
            DependencyProperty.Register("AddButtonMargin", typeof(Thickness), typeof(DynamicTabControl), new UIPropertyMetadata(new Thickness(0)));

        public double AddButtonWidth
        {
            get { return (double)GetValue(AddButtonWidthProperty); }
            set { SetValue(AddButtonWidthProperty, value); }
        }

        public static readonly DependencyProperty AddButtonWidthProperty =
            DependencyProperty.Register("AddButtonWidth", typeof(double), typeof(DynamicTabControl), new UIPropertyMetadata(14.0));

        public double AddButtonHeight
        {
            get { return (double)GetValue(AddButtonHeightProperty); }
            set { SetValue(AddButtonHeightProperty, value); }
        }

        public static readonly DependencyProperty AddButtonHeightProperty =
            DependencyProperty.Register("AddButtonHeight", typeof(double), typeof(DynamicTabControl), new UIPropertyMetadata(14.0));

        public Dock AddButtonPosition
        {
            get { return (Dock)GetValue(AddButtonPositionProperty); }
            set { SetValue(AddButtonPositionProperty, value); }
        }

        public static readonly DependencyProperty AddButtonPositionProperty =
            DependencyProperty.Register("AddButtonPosition", typeof(Dock), typeof(DynamicTabControl), new UIPropertyMetadata(Dock.Right));
    }
}
