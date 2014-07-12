using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// The button which calls the cancel command in the <see cref="DW.WPFToolkit.Controls.SearchTextBox" />.
    /// </summary>
    public class CancelButton : Button
    {
        static CancelButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CancelButton), new FrameworkPropertyMetadata(typeof(CancelButton)));
        }
    }
}