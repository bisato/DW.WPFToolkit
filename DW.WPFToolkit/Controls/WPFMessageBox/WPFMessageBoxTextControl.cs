using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxTextControl : ContentControl
    {
        static WPFMessageBoxTextControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxTextControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxTextControl)));
        }
    }
}