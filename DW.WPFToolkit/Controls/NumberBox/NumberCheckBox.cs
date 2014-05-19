using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents the check box shown in the <see cref="DW.WPFToolkit.Controls.NumberBox" />.
    /// </summary>
    public class NumberCheckBox : CheckBox
    {
        static NumberCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (NumberCheckBox), new FrameworkPropertyMetadata(typeof (NumberCheckBox)));
#if TRIAL
            License1.License.Display();
#endif
        }
    }
}
