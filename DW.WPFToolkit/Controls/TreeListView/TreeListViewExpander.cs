using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents the expander shown in the <see cref="DW.WPFToolkit.Controls.TreeListView" /> to show or collapse child elements.
    /// </summary>
    public class TreeListViewExpander : ToggleButton
    {
        static TreeListViewExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewExpander), new FrameworkPropertyMetadata(typeof(TreeListViewExpander)));
#if TRIAL
            License1.License.Display();
#endif
        }
    }
}
