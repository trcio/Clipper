using System;

namespace Clipper.Entities
{
    public class ClipperEventArgs : EventArgs
    {
        public ClipperEventArgs(string text)
        {
            this.ClipboardText = text;
        }

        /// <summary>
        /// The global clipboard's current text.
        /// </summary>
        public string ClipboardText { get; private set; }
    }
}
