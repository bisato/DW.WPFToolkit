using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    public class NavigationBarToggleButton : ToggleButton
    {
        static NavigationBarToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationBarToggleButton), new FrameworkPropertyMetadata(typeof(NavigationBarToggleButton)));
        }
    }
}
