using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class NavigationBar : ItemsControl
    {
        static NavigationBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationBar), new FrameworkPropertyMetadata(typeof(NavigationBar)));
        }

        public NavigationBar()
        {
            AddHandler(NavigationBarItem.ExpandedEvent, (RoutedEventHandler)OnExpanded);

            Loaded += (sender, args) => OnExpandedItemIndexesChanged();
        }
        
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is NavigationBarItem;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new NavigationBarItem();
        }

        private void OnExpanded(object sender, RoutedEventArgs e)
        {
            if (ExpansionMode == ExpansionMode.Multiple)
                return;

            var currentItem = e.OriginalSource as NavigationBarItem;
            if (currentItem == null)
                return;

            foreach (var item in Items)
            {
                var itemContainer = ItemContainerGenerator.ContainerFromItem(item) as NavigationBarItem;
                if (itemContainer == null ||
                    Equals(itemContainer, currentItem))
                    continue;

                if (itemContainer.IsExpanded)
                    itemContainer.IsExpanded = false;
            }
        }

        public string ContentStringFormat
        {
            get { return (string)GetValue(ContentStringFormatProperty); }
            set { SetValue(ContentStringFormatProperty, value); }
        }

        public static readonly DependencyProperty ContentStringFormatProperty =
            DependencyProperty.Register("ContentStringFormat", typeof(string), typeof(NavigationBar), new PropertyMetadata(null));

        public DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(NavigationBar), new PropertyMetadata(null));

        public DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(NavigationBar), new PropertyMetadata(null));

        public ExpansionMode ExpansionMode
        {
            get { return (ExpansionMode)GetValue(ExpansionModeProperty); }
            set { SetValue(ExpansionModeProperty, value); }
        }

        public static readonly DependencyProperty ExpansionModeProperty =
            DependencyProperty.Register("ExpansionMode", typeof(ExpansionMode), typeof(NavigationBar), new PropertyMetadata(ExpansionMode.Multiple));

        public string ExpandedItemIndexes
        {
            get { return (string)GetValue(ExpandedItemIndexesProperty); }
            set { SetValue(ExpandedItemIndexesProperty, value); }
        }

        public static readonly DependencyProperty ExpandedItemIndexesProperty =
            DependencyProperty.Register("ExpandedItemIndexes", typeof(string), typeof(NavigationBar), new PropertyMetadata(OnExpandedItemIndexesChanged));

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(NavigationBar), new PropertyMetadata(Orientation.Vertical));

        private static void OnExpandedItemIndexesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (NavigationBar)d;
            control.OnExpandedItemIndexesChanged();
        }

        private void OnExpandedItemIndexesChanged()
        {
            var indexes = ExtraxtIndexes();
            for (var currentIndex = 0; currentIndex < Items.Count; ++currentIndex)
            {
                var itemContainer = ItemContainerGenerator.ContainerFromItem(Items[currentIndex]) as NavigationBarItem;
                if (itemContainer == null)
                    continue;

                if (indexes.Contains(currentIndex))
                {
                    if (!itemContainer.IsExpanded)
                        itemContainer.IsExpanded = true;
                }
                else
                {
                    if (itemContainer.IsExpanded)
                        itemContainer.IsExpanded = false;
                }
            }
        }

        private List<int> ExtraxtIndexes()
        {
            var indexes = new List<int>();

            if (string.IsNullOrWhiteSpace(ExpandedItemIndexes))
                return indexes;

            var itemIndexStrings = ExpandedItemIndexes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var itemIndexString in itemIndexStrings)
            {
                var itemIndex = 0;
                if (int.TryParse(itemIndexString, out itemIndex))
                    indexes.Add(itemIndex);

                if (ExpansionMode == ExpansionMode.Single)
                    return indexes;
            }
            return indexes;
        }
    }
}
