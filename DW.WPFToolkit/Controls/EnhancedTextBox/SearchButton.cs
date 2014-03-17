using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class SearchButton : Button
    {
        static SearchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchButton), new FrameworkPropertyMetadata(typeof(SearchButton)));
        }
    }
}
