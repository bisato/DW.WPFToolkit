using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class PagingNavigateButton : Button
    {
        static PagingNavigateButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingNavigateButton), new FrameworkPropertyMetadata(typeof(PagingNavigateButton)));
        }
    }
}
