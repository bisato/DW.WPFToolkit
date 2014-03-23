namespace DW.WPFToolkit.Interactivity
{
    /// <summary>
    /// Defines how the columns has to be resized by the <see cref="DW.WPFToolkit.Interactivity.ColumnWidthBehavior" />.
    /// </summary>
    public enum ColumnResizeKind
    {
        /// <summary>
        /// The column widths stays unchanged.
        /// </summary>
        NoResize = -1,

        /// <summary>
        /// The column widths are defined by the owner control width.
        /// </summary>
        ByControl = -2,

        /// <summary>
        /// The column widths are defined by their shown content.
        /// </summary>
        ByContent = -3,

        /// <summary>
        /// The column widths are calculated proportional by the owner control width.
        /// </summary>
        Proportional = -4
    }
}
