using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxButtonControl : Button
    {
        static WPFMessageBoxButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxButtonControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxButtonControl)));
        }
    }
}
