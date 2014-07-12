using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a single page with header in the DockingPane
    /// </summary>
    public class DockingPaneItem : TabItem
    {
        static DockingPaneItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockingPaneItem), new FrameworkPropertyMetadata(typeof(DockingPaneItem)));
        }
    }
}