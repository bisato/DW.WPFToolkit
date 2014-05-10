using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class NumberResetButton : Button
    {
        static NumberResetButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (NumberResetButton), new FrameworkPropertyMetadata(typeof (NumberResetButton)));
        }
    }
}