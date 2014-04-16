using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a button to jump directly to a page shown in the <see cref="DW.WPFToolkit.Controls.PagingControl" />.
    /// </summary>
    public class PagingJumpBarItem : ListBoxItem
    {
        static PagingJumpBarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingJumpBarItem), new FrameworkPropertyMetadata(typeof(PagingJumpBarItem)));
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }
    }
}
