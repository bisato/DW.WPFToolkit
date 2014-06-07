using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxScrollViewerControl : ScrollViewer
    {
        static WPFMessageBoxScrollViewerControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxScrollViewerControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxScrollViewerControl)));
        }
    }
}
