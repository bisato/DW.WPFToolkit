using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// The button which calls the search command in the <see cref="DW.WPFToolkit.Controls.SearchTextBox" />.
    /// </summary>
    public class SearchButton : Button
    {
        static SearchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchButton), new FrameworkPropertyMetadata(typeof(SearchButton)));
#if TRIAL
            License1.License.Display();
#endif
        }
    }
}
