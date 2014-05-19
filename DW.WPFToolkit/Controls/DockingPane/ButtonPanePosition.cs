namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Defines where the button pane in the <see cref="DW.WPFToolkit.Controls.DockingPane" /> should be located.
    /// </summary>
    public enum ButtonPanePosition
    {
        /// <summary>
        /// The button pane has to be on the inner side moving in with expanding and collapsing the content area.
        /// </summary>
        Inner,

        /// <summary>
        /// The button pane has to be on the outher side not moving when the content area gets expanded or collapsed.
        /// </summary>
        Outher
    }
}