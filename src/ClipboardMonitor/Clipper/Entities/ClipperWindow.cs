using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Clipper.Entities
{
    internal class ClipperWindow : NativeWindow, IDisposable
    {
        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private IntPtr NextViewer;

        internal delegate void TextChangedEventHandler(string text);
        internal event TextChangedEventHandler TextChanged;

        internal ClipperWindow()
        {
            CreateHandle(new CreateParams());
            NextViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    if (TextChanged != null)
                        GetClipData();
                    SendMessage(NextViewer, m.Msg, m.WParam, m.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == NextViewer)
                        NextViewer = m.LParam;
                    else
                        SendMessage(NextViewer, m.Msg, m.WParam, m.LParam);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }	

        }

        private void GetClipData()
        {
            TextChanged(Clipboard.GetText());
        }

        public void Dispose()
        {
            ChangeClipboardChain(this.Handle, NextViewer);
            DestroyHandle();
        }
    }

}
