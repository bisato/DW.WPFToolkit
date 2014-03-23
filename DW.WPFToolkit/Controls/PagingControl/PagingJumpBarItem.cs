using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class PagingJumpBarItem : ListBoxItem
    {
        static PagingJumpBarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingJumpBarItem), new FrameworkPropertyMetadata(typeof(PagingJumpBarItem)));
        }
    }
}
