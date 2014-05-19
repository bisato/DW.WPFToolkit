using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    public class PaneToggleButton : ToggleButton
    {
        static PaneToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PaneToggleButton), new FrameworkPropertyMetadata(typeof(PaneToggleButton)));
        }
    }
}
