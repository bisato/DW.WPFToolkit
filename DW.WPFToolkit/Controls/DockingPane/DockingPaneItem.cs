using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class DockingPaneItem : TabItem
    {
        static DockingPaneItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockingPaneItem), new FrameworkPropertyMetadata(typeof(DockingPaneItem)));
        }
    }
}