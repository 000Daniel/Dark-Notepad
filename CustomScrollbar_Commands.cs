using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkNotepad
{
    internal class CustomScrollbar_Commands
    {
        //  This entire class is a collection of a lot of spam code produced
        //  from buttons and more.
        //  A lot of the existing methods are for here for the custom scrollbars.
        public Notepad dnp;
        public FontMenu fm;
        public ViewHelp vh;
        public void VScrollBar_ArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.VScrollBar_HoldingUp = true;
                dnp.VScrollBar_ArrowUp.Image = dnp.VSB_Arrow_Up_Press;
            }
        }
        public void VScrollBar_ArrowUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.VScrollBar_HoldingUp = false;
                dnp.VScrollBar_ArrowUp.Image = dnp.VSB_Arrow_Up;
            }
        }
        public void VScrollBar_ArrowDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.VScrollBar_HoldingDown = true;
                dnp.VScrollBar_ArrowDown.Image = dnp.VSB_Arrow_Down_Press;
            }
        }
        public void VScrollBar_ArrowDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.VScrollBar_HoldingDown = false;
                dnp.VScrollBar_ArrowDown.Image = dnp.VSB_Arrow_Down;
            }
        }
        public void HScrollBar_ArrowRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.HScrollBar_HoldingRight = true;
                dnp.HScrollBar_ArrowRight.Image = dnp.HSB_Arrow_Right_Press;
            }
        }
        public void HScrollBar_ArrowRight_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.HScrollBar_HoldingRight = false;
                dnp.HScrollBar_ArrowRight.Image = dnp.HSB_Arrow_Right;
            }
        }
        public void HScrollBar_ArrowLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.HScrollBar_HoldingLeft = true;
                dnp.HScrollBar_ArrowLeft.Image = dnp.HSB_Arrow_Left_Press;
            }
        }
        public void HScrollBar_ArrowLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dnp.HScrollBar_HoldingLeft = false;
                dnp.HScrollBar_ArrowLeft.Image = dnp.HSB_Arrow_Left;
            }
        }

                //  From Here forward these functions refer to FontMenu scrollbars!
                //  ###################[First Scrollbar]###################
        public void VScrollBar1_ArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fm.VScrollBar1_HoldingUp = true;
                fm.VScrollBar1_ArrowUp.Image = dnp.VSB_Arrow_Up_Press;
            }
        }
        public void VScrollBar1_ArrowUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fm.VScrollBar1_HoldingUp = false;
                fm.VScrollBar1_ArrowUp.Image = dnp.VSB_Arrow_Up;
            }
        }
        public void VScrollBar1_ArrowDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            fm.VScrollBar1_HoldingDown = true;
            fm.VScrollBar1_ArrowDown.Image = dnp.VSB_Arrow_Down_Press;
        }
        public void VScrollBar1_ArrowDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            fm.VScrollBar1_HoldingDown = false;
            fm.VScrollBar1_ArrowDown.Image = dnp.VSB_Arrow_Down;
        }

        public void VScrollBar1_ArrowUp_Click(object sender, EventArgs e)
        {
            int curPos = fm.SelectionMenu1.AutoScrollPosition.Y;
            fm.SelectionMenu1.AutoScrollPosition = new Point(0, -curPos - 20);
        }
        public void VScrollBar1_ArrowDown_Click(object sender, EventArgs e)
        {
            int addScrollValue = 20;

            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            Win32_Calls.GetScrollInfo(fm.SelectionMenu1.Handle, 1, ref scrollInfo);

            while (scrollInfo.nTrackPos + addScrollValue > scrollInfo.max - scrollInfo.nPage)
            {
                addScrollValue--;
            }

            int curPos = fm.SelectionMenu1.AutoScrollPosition.Y;
            fm.SelectionMenu1.AutoScrollPosition = new Point(0, -curPos + addScrollValue);
        }
                //  ###################[Second Scrollbar]###################
        public void VScrollBar2_ArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fm.VScrollBar2_HoldingUp = true;
                fm.VScrollBar2_ArrowUp.Image = dnp.VSB_Arrow_Up_Press;
            }
        }
        public void VScrollBar2_ArrowUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fm.VScrollBar2_HoldingUp = false;
                fm.VScrollBar2_ArrowUp.Image = dnp.VSB_Arrow_Up;
            }
        }
        public void VScrollBar2_ArrowDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            fm.VScrollBar2_HoldingDown = true;
            fm.VScrollBar2_ArrowDown.Image = dnp.VSB_Arrow_Down_Press;
        }
        public void VScrollBar2_ArrowDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            fm.VScrollBar2_HoldingDown = false;
            fm.VScrollBar2_ArrowDown.Image = dnp.VSB_Arrow_Down;
        }

        public void VScrollBar2_ArrowUp_Click(object sender, EventArgs e)
        {
            int curPos = fm.SelectionMenu2.AutoScrollPosition.Y;
            fm.SelectionMenu2.AutoScrollPosition = new Point(0, -curPos - 20);
        }
        public void VScrollBar2_ArrowDown_Click(object sender, EventArgs e)
        {
            int addScrollValue = 20;

            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            Win32_Calls.GetScrollInfo(fm.SelectionMenu2.Handle, 1, ref scrollInfo);

            while (scrollInfo.nTrackPos + addScrollValue > scrollInfo.max - scrollInfo.nPage)
            {
                addScrollValue--;
            }

            int curPos = fm.SelectionMenu2.AutoScrollPosition.Y;
            fm.SelectionMenu2.AutoScrollPosition = new Point(0, -curPos + addScrollValue);
        }
                //  ###################[Third Scrollbar]###################
        public void VScrollBar3_ArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fm.VScrollBar3_HoldingUp = true;
                fm.VScrollBar3_ArrowUp.Image = dnp.VSB_Arrow_Up_Press;
            }
        }
        public void VScrollBar3_ArrowUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                fm.VScrollBar3_HoldingUp = false;
                fm.VScrollBar3_ArrowUp.Image = dnp.VSB_Arrow_Up;
            }
        }
        public void VScrollBar3_ArrowDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            fm.VScrollBar3_HoldingDown = true;
            fm.VScrollBar3_ArrowDown.Image = dnp.VSB_Arrow_Down_Press;
        }
        public void VScrollBar3_ArrowDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            fm.VScrollBar3_HoldingDown = false;
            fm.VScrollBar3_ArrowDown.Image = dnp.VSB_Arrow_Down;
        }

        public void VScrollBar3_ArrowUp_Click(object sender, EventArgs e)
        {
            int curPos = fm.SelectionMenu3.AutoScrollPosition.Y;
            fm.SelectionMenu3.AutoScrollPosition = new Point(0, -curPos - 20);
        }
        public void VScrollBar3_ArrowDown_Click(object sender, EventArgs e)
        {
            int addScrollValue = 20;

            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            Win32_Calls.GetScrollInfo(fm.SelectionMenu3.Handle, 1, ref scrollInfo);

            while (scrollInfo.nTrackPos + addScrollValue > scrollInfo.max - scrollInfo.nPage)
            {
                addScrollValue--;
            }

            int curPos = fm.SelectionMenu3.AutoScrollPosition.Y;
            fm.SelectionMenu3.AutoScrollPosition = new Point(0, -curPos + addScrollValue);
        }
                //  ###################[Forth Scrollbar]###################
        public void VScrollBar4_ArrowUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                vh.VScrollBar4_HoldingUp = true;
                vh.VScrollBar4_ArrowUp.Image = dnp.VSB_Arrow_Up_Press;
            }
        }
        public void VScrollBar4_ArrowUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                vh.VScrollBar4_HoldingUp = false;
                vh.VScrollBar4_ArrowUp.Image = dnp.VSB_Arrow_Up;
            }
        }
        public void VScrollBar4_ArrowDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            vh.VScrollBar4_HoldingDown = true;
            vh.VScrollBar4_ArrowDown.Image = dnp.VSB_Arrow_Down_Press;
        }
        public void VScrollBar4_ArrowDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            vh.VScrollBar4_HoldingDown = false;
            vh.VScrollBar4_ArrowDown.Image = dnp.VSB_Arrow_Down;
        }

        public void VScrollBar4_ArrowUp_Click(object sender, EventArgs e)
        {
            if (vh.flowLayoutPanel1.Visible)
            {
                int curPos = vh.flowLayoutPanel1.AutoScrollPosition.Y;
                vh.flowLayoutPanel1.AutoScrollPosition = new Point(0, -curPos - 20);
            }
            else
            {
                int curPos = vh.settingsPanel.AutoScrollPosition.Y;
                vh.settingsPanel.AutoScrollPosition = new Point(0, -curPos - 20);
            }
        }
        public void VScrollBar4_ArrowDown_Click(object sender, EventArgs e)
        {
            int addScrollValue = 20;

            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            if (vh.flowLayoutPanel1.Visible)
            {
                Win32_Calls.GetScrollInfo(vh.flowLayoutPanel1.Handle, 1, ref scrollInfo);
            }
            else
            {
                Win32_Calls.GetScrollInfo(vh.settingsPanel.Handle, 1, ref scrollInfo);
            }

            while (scrollInfo.nTrackPos + addScrollValue > scrollInfo.max - scrollInfo.nPage)
            {
                addScrollValue--;
            }

            if (vh.flowLayoutPanel1.Visible)
            {
                int curPos = vh.flowLayoutPanel1.AutoScrollPosition.Y;
                vh.flowLayoutPanel1.AutoScrollPosition = new Point(0, -curPos + addScrollValue);
            }
            else
            {
                int curPos = vh.settingsPanel.AutoScrollPosition.Y;
                vh.settingsPanel.AutoScrollPosition = new Point(0, -curPos + addScrollValue);
            }
        }
        //  ###################[MAIN SCROLLBAR IN RICHTEXTBOX]###################
        public void HScrollBar_ArrowLeft_Click(object sender, EventArgs e, RichTextBox richTextBox1)
        {
            Point curPos = Win32_Calls.GetScrollPos(richTextBox1);
            if (curPos.X <= 20)
            {
                Win32_Calls.SetScrollPos(new Point(0, curPos.Y), richTextBox1);
            }
            else
            {
                Win32_Calls.SetScrollPos(new Point(curPos.X - 20, curPos.Y), richTextBox1);
            }
        }
        public void HScrollBar_ArrowRight_Click(object sender, EventArgs e , RichTextBox richTextBox1)
        {
            int addScrollValue = 20;

            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            Win32_Calls.GetScrollInfo(richTextBox1.Handle, 0, ref scrollInfo);

            while (scrollInfo.nTrackPos + addScrollValue > scrollInfo.max - scrollInfo.nPage)
            {
                addScrollValue--;
            }

            Point curPos = Win32_Calls.GetScrollPos(richTextBox1);
            Win32_Calls.SetScrollPos(new Point(curPos.X + addScrollValue, curPos.Y), richTextBox1);
        }
        public void VScrollBar_ArrowUp_Click(object sender, EventArgs e, RichTextBox richTextBox1)
        {
            Point curPos = Win32_Calls.GetScrollPos(richTextBox1);
            Win32_Calls.SetScrollPos(new Point(curPos.X, curPos.Y - 20), richTextBox1);
        }
        public void VScrollBar_ArrowDown_Click(object sender, EventArgs e, RichTextBox richTextBox1)
        {
            int addScrollValue = 20;

            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            Win32_Calls.GetScrollInfo(richTextBox1.Handle, 1, ref scrollInfo);

            while (scrollInfo.nTrackPos + addScrollValue > scrollInfo.max - scrollInfo.nPage)
            {
                addScrollValue--;
            }

            Point curPos = Win32_Calls.GetScrollPos(richTextBox1);
            Win32_Calls.SetScrollPos(new Point(curPos.X, curPos.Y + addScrollValue), richTextBox1);
        }
                //  ###################[END]###################

                //  This function calculates the size of the scrollbar's 'scroll thumb'.
        public void ScrollSelection(IntPtr handlePtr, Panel VScrollbar_Thumb, Panel VScrollbar)
        {
                    //  Check if scrollbar's thumb is available
            string availableScroll = Win32_Calls.GetScrollBarsEnabled(handlePtr).Vertical.ToString();
            if (availableScroll == "STATE_SYSTEM_UNAVAILABLE" ||
                availableScroll == "STATE_SYSTEM_INVISIBLE")
            {
                VScrollbar_Thumb.Visible = false;
                return;
            }
            availableScroll = string.Empty;

                    //  Calculate the scrollbar's thumb size and location.
            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            Win32_Calls.GetScrollInfo(handlePtr, 1, ref scrollInfo);
            float scrollRatio = (float)scrollInfo.nPage / (float)scrollInfo.max;

            if (scrollInfo.max < 0 || scrollInfo.nPage < 0) return;
            VScrollbar_Thumb.Visible = true;

                    //  If the scrollbar's thumb is smaller than 17 pixels in height,
                    //  the software caps the height to 17.
                    //  capping the size causes desynchronization issues and 'heightDiff'
                    //  fixes them by calculating how the new thumb should look.
            int heightDiff = 0;
            VScrollbar_Thumb.Height = (int)(VScrollbar.Height * scrollRatio);
            if (VScrollbar_Thumb.Height < 17)
            {
                heightDiff = 17 - VScrollbar_Thumb.Height;
                VScrollbar_Thumb.Height = 17;
            }

            float scrollPosRatio = (float)(scrollInfo.nTrackPos + scrollInfo.nPage) / (float)scrollInfo.max;
            VScrollbar_Thumb.Top = (int)((VScrollbar.Height - heightDiff) * scrollPosRatio) - VScrollbar_Thumb.Height + heightDiff;
        }
        public void HScrollSelection(IntPtr handlePtr, Panel HScrollbar_Thumb, Panel HScrollbar)
        {
            string availableScroll = Win32_Calls.GetScrollBarsEnabled(handlePtr).Horizontal.ToString();
            if (availableScroll == "STATE_SYSTEM_UNAVAILABLE" ||
                availableScroll == "STATE_SYSTEM_INVISIBLE")
            {
                HScrollbar_Thumb.Visible = false;
                return;
            }
            availableScroll = string.Empty;

                    //  Calculate the 'HScrollbar_Thumb' size and location.
            Win32_Calls.SCROLLINFO scrollInfo = new Win32_Calls.SCROLLINFO();
            scrollInfo.cbSize = Marshal.SizeOf(scrollInfo);
            scrollInfo.fMask = 0x10 | 0x1 | 0x2;
            Win32_Calls.GetScrollInfo(handlePtr, 0, ref scrollInfo);

            if (scrollInfo.max < 0 && scrollInfo.nPage < 0) return;

            HScrollbar_Thumb.Visible = true;
            float scrollRatio = (float)scrollInfo.nPage / (float)scrollInfo.max;

                    //  If the scrollbar's thumb is smaller than 17 pixels in width,
                    //  the software caps the width to 17.
                    //  capping the size causes desynchronization issues and 'widthDiff'
                    //  fixes them by calculating how the new thumb should look.
            HScrollbar_Thumb.Width = (int)(HScrollbar.Width * scrollRatio);
            int widthDiff = 0;
            if (HScrollbar_Thumb.Width < 17)
            {
                widthDiff = 17 - HScrollbar_Thumb.Width;
                HScrollbar_Thumb.Width = 17;
            }

            float scrollPosRatio = (float)(scrollInfo.nTrackPos + scrollInfo.nPage) / (float)scrollInfo.max;
            HScrollbar_Thumb.Left = (int)((HScrollbar.Width - widthDiff) * scrollPosRatio) - HScrollbar_Thumb.Width + widthDiff;
        }
    }
}
