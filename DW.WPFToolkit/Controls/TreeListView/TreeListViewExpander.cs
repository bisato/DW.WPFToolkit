using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    public class TreeListViewExpander : ToggleButton
    {
        static TreeListViewExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewExpander), new FrameworkPropertyMetadata(typeof(TreeListViewExpander)));
        }
    }
}
