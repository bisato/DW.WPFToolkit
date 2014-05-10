using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class NumberCheckBox : CheckBox
    {
        static NumberCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (NumberCheckBox), new FrameworkPropertyMetadata(typeof (NumberCheckBox)));
        }
    }
}
