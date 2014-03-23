using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Holds all created <see cref="DW.WPFToolkit.Controls.PagingJumpBarItem" /> shown in the <see cref="DW.WPFToolkit.Controls.PagingControl" />.
    /// </summary>
    public class PagingJumpBar : ListBox
    {
        static PagingJumpBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingJumpBar), new FrameworkPropertyMetadata(typeof(PagingJumpBar)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PagingJumpBarItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is PagingJumpBarItem;
        }
    }
}
