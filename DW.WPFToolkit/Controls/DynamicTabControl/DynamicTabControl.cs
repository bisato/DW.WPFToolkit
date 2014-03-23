using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.TabControl" /> with buttons for add new tab item and close buttons of existing tab items.
    /// </summary>
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

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.ShowCloseButtons" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowCloseButtonsProperty =
            DependencyProperty.Register("ShowCloseButtons", typeof(bool), typeof(DynamicTabControl), new UIPropertyMetadata(true));

        public bool ShowAddButton
        {
            get { return (bool)GetValue(ShowAddButtonProperty); }
            set { SetValue(ShowAddButtonProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.ShowAddButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowAddButtonProperty =
            DependencyProperty.Register("ShowAddButton", typeof(bool), typeof(DynamicTabControl), new UIPropertyMetadata(true));

        public ICommand TabItemClosingCommand
        {
            get { return (ICommand)GetValue(TabItemClosingCommandProperty); }
            set { SetValue(TabItemClosingCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.TabItemClosingCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TabItemClosingCommandProperty =
            DependencyProperty.Register("TabItemClosingCommand", typeof(ICommand), typeof(DynamicTabControl), new UIPropertyMetadata(null));

        public object TabItemAddingCommandParameter
        {
            get { return (object)GetValue(TabItemAddingCommandParameterProperty); }
            set { SetValue(TabItemAddingCommandParameterProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.TabItemAddingCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TabItemAddingCommandParameterProperty =
            DependencyProperty.Register("TabItemAddingCommandParameter", typeof(object), typeof(DynamicTabControl), new UIPropertyMetadata(null));

        public ICommand TabItemAddingCommand
        {
            get { return (ICommand)GetValue(TabItemAddingCommandProperty); }
            set { SetValue(TabItemAddingCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.TabItemAddingCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TabItemAddingCommandProperty =
            DependencyProperty.Register("TabItemAddingCommand", typeof(ICommand), typeof(DynamicTabControl), new UIPropertyMetadata(null));

        public Thickness AddButtonMargin
        {
            get { return (Thickness)GetValue(AddButtonMarginProperty); }
            set { SetValue(AddButtonMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.AddButtonMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AddButtonMarginProperty =
            DependencyProperty.Register("AddButtonMargin", typeof(Thickness), typeof(DynamicTabControl), new UIPropertyMetadata(new Thickness(0)));

        public double AddButtonWidth
        {
            get { return (double)GetValue(AddButtonWidthProperty); }
            set { SetValue(AddButtonWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.AddButtonWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AddButtonWidthProperty =
            DependencyProperty.Register("AddButtonWidth", typeof(double), typeof(DynamicTabControl), new UIPropertyMetadata(14.0));

        public double AddButtonHeight
        {
            get { return (double)GetValue(AddButtonHeightProperty); }
            set { SetValue(AddButtonHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.AddButtonHeight" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AddButtonHeightProperty =
            DependencyProperty.Register("AddButtonHeight", typeof(double), typeof(DynamicTabControl), new UIPropertyMetadata(14.0));

        public Dock AddButtonPosition
        {
            get { return (Dock)GetValue(AddButtonPositionProperty); }
            set { SetValue(AddButtonPositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.DynamicTabControl.AddButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AddButtonPositionProperty =
            DependencyProperty.Register("AddButtonPosition", typeof(Dock), typeof(DynamicTabControl), new UIPropertyMetadata(Dock.Right));
    }
}
