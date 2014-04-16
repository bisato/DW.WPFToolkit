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
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }

        /// <summary>
        /// Generates a new child item container to hold in the <see cref="DW.WPFToolkit.Controls.PagingJumpBar" />.
        /// </summary>
        /// <returns>The generated child item container</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PagingJumpBarItem();
        }

        /// <summary>
        /// Checks if the item is already the correct item container. If not the <see cref="DW.WPFToolkit.Controls.PagingJumpBar.GetContainerForItemOverride" /> will be used to generate the right container.
        /// </summary>
        /// <param name="item">The item to shown in the <see cref="DW.WPFToolkit.Controls.PagingJumpBar" />.</param>
        /// <returns>True if the item is the correct item container already.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is PagingJumpBarItem;
        }
    }
}
