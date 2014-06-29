using System;
using Clipper.Entities;

namespace Clipper
{
    public static class ClipperGlobal
    {
        private static ClipperWindow window = new ClipperWindow();

        public delegate void ClipperTextChangedEventHandler(ClipperEventArgs e);
        /// <summary>
        /// Fires when the user's clipboard text changes.
        /// </summary>
        public static event ClipperTextChangedEventHandler ClipperTextChanged;

        /// <summary>
        /// Starts listening for clipboard changes.
        /// </summary>
        public static void Initialize()
        {
            if (ClipperTextChanged == null)
                throw new InvalidOperationException("The event 'ClipperTextChanged' cannot be null.");

            window.TextChanged += window_TextChanged;
        }

        private static void window_TextChanged(string text)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
            {
                ClipperTextChanged(new ClipperEventArgs(text));
            }
        }
    }
}
