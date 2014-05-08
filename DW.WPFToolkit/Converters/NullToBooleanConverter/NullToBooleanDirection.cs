namespace DW.WPFToolkit.Converters
{
    /// <summary>
    /// Defines if the NullToBooleanConverter returns true or false if the value is null.
    /// </summary>
    public enum NullToBooleanDirection
    {
        /// <summary>
        /// If the value is null the Convert has to return true; otherwise false.
        /// </summary>
        NullIsTrue,

        /// <summary>
        /// If the value is null the Convert has to return false; otherwise true.
        /// </summary>
        NullIsFalse
    }
}