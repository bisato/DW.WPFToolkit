using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class DockingPane : TabControl
    {
        static DockingPane()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockingPane), new FrameworkPropertyMetadata(typeof(DockingPane)));
        }

        public DockingPane()
        {
            Loaded += HandleLoaded;
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DockingPaneItem;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DockingPaneItem();
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            if (SelectedIndex == -1)
                CollapseAll();
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            CollapseAll();
        }

        private void CollapseAll()
        {
            if (!DisableDefaultSelection)
                return;

            foreach (var item in Items)
            {
                var container = ItemContainerGenerator.ContainerFromItem(item) as DockingPaneItem;
                if (container != null)
                    container.IsSelected = false;
            }
        }


        public bool DisableDefaultSelection
        {
            get { return (bool)GetValue(DisableDefaultSelectionProperty); }
            set { SetValue(DisableDefaultSelectionProperty, value); }
        }

        public static readonly DependencyProperty DisableDefaultSelectionProperty =
            DependencyProperty.Register("DisableDefaultSelection", typeof(bool), typeof(DockingPane), new PropertyMetadata(true));

        public ButtonPanePosition ButtonsPosition
        {
            get { return (ButtonPanePosition)GetValue(ButtonsPositionProperty); }
            set { SetValue(ButtonsPositionProperty, value); }
        }

        public static readonly DependencyProperty ButtonsPositionProperty =
            DependencyProperty.Register("ButtonsPosition", typeof(ButtonPanePosition), typeof(DockingPane), new PropertyMetadata(ButtonPanePosition.Outher));

        public ExpandDirection ExpandDirection
        {
            get { return (ExpandDirection)GetValue(ExpandDirectionProperty); }
            set { SetValue(ExpandDirectionProperty, value); }
        }

        public static readonly DependencyProperty ExpandDirectionProperty =
            DependencyProperty.Register("ExpandDirection", typeof(ExpandDirection), typeof(DockingPane), new PropertyMetadata(ExpandDirection.LeftToRight));

        public double AreaWidth
        {
            get { return (double)GetValue(AreaWidthProperty); }
            set { SetValue(AreaWidthProperty, value); }
        }

        public static readonly DependencyProperty AreaWidthProperty =
            DependencyProperty.Register("AreaWidth", typeof(double), typeof(DockingPane), new PropertyMetadata(double.NaN));

        public double AreaMinWidth
        {
            get { return (double)GetValue(AreaMinWidthProperty); }
            set { SetValue(AreaMinWidthProperty, value); }
        }

        public static readonly DependencyProperty AreaMinWidthProperty =
            DependencyProperty.Register("AreaMinWidth", typeof(double), typeof(DockingPane), new PropertyMetadata(double.NaN));

        public double AreaMaxWidth
        {
            get { return (double)GetValue(AreaMaxWidthProperty); }
            set { SetValue(AreaMaxWidthProperty, value); }
        }

        public static readonly DependencyProperty AreaMaxWidthProperty =
            DependencyProperty.Register("AreaMaxWidth", typeof(double), typeof(DockingPane), new PropertyMetadata(double.NaN));

        public double AreaHeight
        {
            get { return (double)GetValue(AreaHeightProperty); }
            set { SetValue(AreaHeightProperty, value); }
        }

        public static readonly DependencyProperty AreaHeightProperty =
            DependencyProperty.Register("AreaHeight", typeof(double), typeof(DockingPane), new PropertyMetadata(double.NaN));

        public double AreaMinHeight
        {
            get { return (double)GetValue(AreaMinHeightProperty); }
            set { SetValue(AreaMinHeightProperty, value); }
        }

        public static readonly DependencyProperty AreaMinHeightProperty =
            DependencyProperty.Register("AreaMinHeight", typeof(double), typeof(DockingPane), new PropertyMetadata(double.NaN));

        public double AreaMaxHeight
        {
            get { return (double)GetValue(AreaMaxHeightProperty); }
            set { SetValue(AreaMaxHeightProperty, value); }
        }

        public static readonly DependencyProperty AreaMaxHeightProperty =
            DependencyProperty.Register("AreaMaxHeight", typeof(double), typeof(DockingPane), new PropertyMetadata(double.NaN));
    }
}
