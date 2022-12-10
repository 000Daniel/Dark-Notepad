using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkNotepad
{
        //  This entire class is dedicated for Win32 API usage.
        //  A lot of code here was not written by me!
    public static class Win32_Calls
    {
                //  This code is from: https://stackoverflow.com/a/33542937
                //  Base source code: https://pastebin.com/FnEGqWxX
        public static void SetInnerMargins(this TextBoxBase textBox, int left, int top, int right, int bottom)
        {
            var rect = textBox.GetFormattingRect();

            var newRect = new Rectangle(left, top, rect.Width - left - right, rect.Height - top - bottom);
            textBox.SetFormattingRect(newRect);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public readonly int Left;
            public readonly int Top;
            public readonly int Right;
            public readonly int Bottom;

            private RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }
        }

        [DllImport(@"User32.dll", EntryPoint = @"SendMessage", CharSet = CharSet.Auto)]
        private static extern int SendMessageRefRect(IntPtr hWnd, uint msg, int wParam, ref RECT rect);

        [DllImport(@"user32.dll", EntryPoint = @"SendMessage", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, ref Rectangle lParam);

        private const int EmGetrect = 0xB2;
        private const int EmSetrect = 0xB3;

        private static void SetFormattingRect(this TextBoxBase textbox, Rectangle rect)
        {
            var rc = new RECT(rect);
            SendMessageRefRect(textbox.Handle, EmSetrect, 0, ref rc);
        }

        private static Rectangle GetFormattingRect(this TextBoxBase textbox)
        {
            var rect = new Rectangle();
            SendMessage(textbox.Handle, EmGetrect, (IntPtr)0, ref rect);
            return rect;
        }

                //  This code is from: https://www.4dots-software.com/codeblog/dotnet/how-to-set-or-get-scroll-position-of-richtextbox.php

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwndLock, Int32 wMsg, Int32 wParam, ref Point pt);

        public static Point GetScrollPos(RichTextBox txtbox)
        {
            const int EM_GETSCROLLPOS = 0x0400 + 221;
            Point pt = new Point();

            SendMessage(txtbox.Handle, EM_GETSCROLLPOS, 0, ref pt);
            return pt;
        }
        public static void SetScrollPos(Point pt, RichTextBox txtbox)
        {
            const int EM_SETSCROLLPOS = 0x0400 + 222;

            SendMessage(txtbox.Handle, EM_SETSCROLLPOS, 0, ref pt);
        }

                //  This code if from: https://stackoverflow.com/a/19344218/20202826
        [DllImport("user32")]
        public static extern int GetScrollInfo(IntPtr hwnd, int nBar, ref SCROLLINFO scrollInfo);

        public struct SCROLLINFO
        {
            public int cbSize;
            public int fMask;
            public int min;
            public int max;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }

                //  This code is from https://stackoverflow.com/a/74017343/20202826
        public static (SBRgState Vertical, SBRgState Horizontal) GetScrollBarsEnabled(IntPtr controlHandle)
        {
            var sbi = new SCROLLBARINFO() { cbSize = Marshal.SizeOf<SCROLLBARINFO>() };

            bool result = GetScrollBarInfo(controlHandle, SBIdObj.OBJID_VSCROLL, ref sbi);
            if (!result) throw new Exception("Failed to retrieve vertical ScrollBar info");
            var vert = (SBRgState)sbi.rgstate[0];

            result = GetScrollBarInfo(controlHandle, SBIdObj.OBJID_HSCROLL, ref sbi);
            if (!result) throw new Exception("Failed to retrieve horizontal ScrollBar info");
            return (vert, (SBRgState)sbi.rgstate[0]);
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool GetScrollBarInfo(IntPtr hWnd, SBIdObj idObject, ref SCROLLBARINFO psbi);

        [StructLayout(LayoutKind.Sequential)]
        public struct SCROLLBARINFO
        {
            public int cbSize;
            public Rectangle rcScrollBar;
            public int dxyLineButton;
            public int xyThumbTop;
            public int xyThumbBottom;
            public int reserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public int[] rgstate;
        }

        public enum SBIdObj : uint
        {
            OBJID_HSCROLL = 0xFFFFFFFA,
            OBJID_VSCROLL = 0xFFFFFFFB,
            OBJID_CLIENT = 0xFFFFFFFC
        }

        [Flags]
        public enum SBRgState
        {
            STATE_SYSTEM_AVAILABLE = 0x00000000,
            STATE_SYSTEM_UNAVAILABLE = 0x00000001,
            STATE_SYSTEM_PRESSED = 0x00000008,
            STATE_SYSTEM_INVISIBLE = 0x00008000,
            STATE_SYSTEM_OFFSCREEN = 0x00010000,
        }

                //  This is responsible for resizing windows.
                //  This is used for the left scrollbar grip.
        [DllImport("User32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);
    }
}
