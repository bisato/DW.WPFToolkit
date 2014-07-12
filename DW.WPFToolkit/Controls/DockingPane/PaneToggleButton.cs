using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a toggle button in the bottom pane of an <see cref="DW.WPFToolkit.Controls.DockingPane" />.
    /// </summary>
    public class PaneToggleButton : ToggleButton
    {
        static PaneToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PaneToggleButton), new FrameworkPropertyMetadata(typeof(PaneToggleButton)));
        }
    }
}
