namespace DW.WPFToolkit.Converters
{
    /// <summary>
    /// Defines if the NullToVisibilityConverter returns Visibility.Visible, Visibility.Collapsed or Visibility.Hidden if the value is null.
    /// </summary>
    public enum NullToVisibilityDirection
    {
        /// <summary>
        /// If the value is null the Convert has to return Visibility.Visible; otherwise Visibility.Collapsed.
        /// </summary>
        NullIsVisible,

        /// <summary>
        /// If the value is null the Convert has to return Visibility.Collapsed; otherwise Visibility.Visible.
        /// </summary>
        NullIsCollapsed,

        /// <summary>
        /// If the value is null the Convert has to return Visibility.Hidden; otherwise Visibility.Visible.
        /// </summary>
        NullIsHidden
    }
}