using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxCheckBoxControl : CheckBox
    {
        static WPFMessageBoxCheckBoxControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxCheckBoxControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxCheckBoxControl)));
        }
    }
}
