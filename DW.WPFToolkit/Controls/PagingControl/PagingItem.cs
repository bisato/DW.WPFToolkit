﻿using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class PagingItem : HeaderedContentControl
    {
        static PagingItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingItem), new FrameworkPropertyMetadata(typeof(PagingItem)));
        }

        public object Footer
        {
            get { return (object)GetValue(FooterProperty); }
            set { SetValue(FooterProperty, value); }
        }

        public static readonly DependencyProperty FooterProperty =
            DependencyProperty.Register("Footer", typeof(object), typeof(PagingItem), new UIPropertyMetadata(null));

        public DataTemplate FooterTemplate
        {
            get { return (DataTemplate)GetValue(FooterTemplateProperty); }
            set { SetValue(FooterTemplateProperty, value); }
        }

        public static readonly DependencyProperty FooterTemplateProperty =
            DependencyProperty.Register("FooterTemplate", typeof(DataTemplate), typeof(PagingItem), new UIPropertyMetadata(null));
    }
}
