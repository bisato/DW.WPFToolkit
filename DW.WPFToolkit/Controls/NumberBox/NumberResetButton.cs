using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents the reset to default button shown in the <see cref="DW.WPFToolkit.Controls.NumberBox" />.
    /// </summary>
    public class NumberResetButton : Button
    {
        static NumberResetButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberResetButton), new FrameworkPropertyMetadata(typeof(NumberResetButton)));
#if TRIAL
            License1.License.Display();
#endif
        }
    }
}