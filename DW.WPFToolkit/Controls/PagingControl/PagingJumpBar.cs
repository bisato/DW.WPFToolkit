using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
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
