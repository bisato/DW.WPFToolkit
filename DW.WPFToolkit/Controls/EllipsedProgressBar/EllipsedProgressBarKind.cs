namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Defines how the progress in the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" /> is shown.
    /// </summary>
    public enum EllipsedProgressBarKind
    {
        /// <summary>
        /// The progress value is shown in a pie form. A minimum value is an empty ellipse form and a maximum value is a full filled ellipse.
        /// </summary>
        Pie,

        /// <summary>
        /// The progress value is shown by a pointer line from the center to the value in the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />.
        /// </summary>
        Pointer,

        /// <summary>
        /// The progress value is shown by the items in the <see cref="DW.WPFToolkit.Controls.EllipsedProgressBar" />. This is used in the <see cref="DW.WPFToolkit.Controls.IItemsFactory" />.
        /// </summary>
        Items
    }
}
