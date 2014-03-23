﻿using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Holds a specific page in the <see cref="DW.WPFToolkit.Controls.PagingControl" />.
    /// </summary>
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

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.PagingItem.Footer" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty FooterProperty =
            DependencyProperty.Register("Footer", typeof(object), typeof(PagingItem), new UIPropertyMetadata(null));

        public DataTemplate FooterTemplate
        {
            get { return (DataTemplate)GetValue(FooterTemplateProperty); }
            set { SetValue(FooterTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.PagingItem.FooterTemplate" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty FooterTemplateProperty =
            DependencyProperty.Register("FooterTemplate", typeof(DataTemplate), typeof(PagingItem), new UIPropertyMetadata(null));
    }
}