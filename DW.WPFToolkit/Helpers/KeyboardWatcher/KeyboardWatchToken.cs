using System;

namespace DW.WPFToolkit.Helpers
{
    /// <summary>
    /// Represents a token which stands for a callback in the <see cref="DW.WPFToolkit.Helpers.KeyboardWatcher" />.
    /// </summary>
    public class KeyboardWatchToken : IEquatable<KeyboardWatchToken>
    {
        internal KeyboardWatchToken()
        {
            _guid = Guid.NewGuid();
        }

        private Guid _guid;

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise false.</returns>
        public bool Equals(KeyboardWatchToken other)
        {
            return _guid.Equals(other._guid);
        }
    }
}