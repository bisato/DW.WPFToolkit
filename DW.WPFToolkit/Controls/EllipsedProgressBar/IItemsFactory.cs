using System.Collections.Generic;
using System.Windows;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// The object implementing this interface is used to create and updtae the items in the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" /> depending on the progress value and progress bar state.
    /// </summary>
    public interface IItemsFactory
    {
        /// <summary>
        /// This method returns the items placed into the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />.
        /// </summary>
        /// <param name="forIndeterminate">Defines if the using <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" /> is indeterminate or not.</param>
        /// <returns>The elements to be placed into the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />. These object will be passed to the <see cref="DW.WPFToolkit.Controls.IItemsFactory.EditItemsForValue(IEnumerable{UIElement}, double, double, double)" /> as soon any progress value changes.</returns>
        IEnumerable<UIElement> GenerateItems(bool forIndeterminate);

        /// <summary>
        /// Updates all items which are placed in the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" /> by the given progress value.
        /// </summary>
        /// <param name="items">The items placed in the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" /> to be updated.</param>
        /// <param name="mininum">The configured minimum value of the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />.</param>
        /// <param name="maximum">The configured maximum value of the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />.</param>
        /// <param name="value">The current progress value of the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />.</param>
        void EditItemsForValue(IEnumerable<UIElement> items, double mininum, double maximum, double value);
    }
}
