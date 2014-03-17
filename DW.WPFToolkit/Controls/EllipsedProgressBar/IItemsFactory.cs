using System.Collections.Generic;
using System.Windows;

namespace DW.WPFToolkit.Controls
{
    public interface IItemsFactory
    {
        IEnumerable<UIElement> GenerateItems(bool forIndeterminate);

        void EditItemsForValue(IEnumerable<UIElement> items, double mininum, double maximum, double value);
    }
}
