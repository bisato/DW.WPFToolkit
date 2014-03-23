namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents what is possible to drop into the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" />.
    /// </summary>
    public enum DroppableTypes
    {
        /// <summary>
        /// Just one file can be dropped into the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" />.
        /// </summary>
        File,

        /// <summary>
        /// Multiple files can be dropped into the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" />.
        /// </summary>
        Files,

        /// <summary>
        /// Multiple files and folders can be dropped into the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" />.
        /// </summary>
        FilesFolders,

        /// <summary>
        /// Multiple folders can be dropped into the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" />.
        /// </summary>
        Folders,

        /// <summary>
        /// Just one folder can be dropped into the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" />.
        /// </summary>
        Folder
    }
}
