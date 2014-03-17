using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class CancelButton : Button
    {
        static CancelButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CancelButton), new FrameworkPropertyMetadata(typeof(CancelButton)));
        }
    }
}