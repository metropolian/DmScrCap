using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DmScrCap
{
    public class NotificationControl
    {
        public NotifyIcon SystemIcon;
        public ContextMenuStrip SystemMenu;

        public Form MainForm;

        public NotificationControl(Form SrcForm, Icon Ic)
        {
            SystemIcon = new NotifyIcon();
            SystemMenu = new  ContextMenuStrip();

            SystemIcon.Icon = Ic;

            SystemIcon.Visible = true;
            SystemIcon.Click += SystemIcon_Click;
            SystemIcon.DoubleClick += SystemIcon_DoubleClick;

            MainForm = SrcForm;
        }

        void SystemIcon_Click(object sender, EventArgs e)
        {
            if (SystemMenu.Items.Count == 0)
                ToggleMainForm();
            else
            {
                if (SystemMenu.Visible == false)
                        SystemMenu.Show(Cursor.Position.X, Cursor.Position.Y);
                    else
                        SystemMenu.Hide();
                
            }
        }

        void SystemIcon_DoubleClick(object sender, EventArgs e)
        {
            ToggleMainForm();
        }

        public void ToggleMainForm()
        {
            if (MainForm.Visible == true)
                MainForm.Hide();
            else
            {
                MainForm.Show();
                PositionFormToIcon();
            }
        }

        public void PositionFormToIcon()
        {
            int ScrW = Screen.PrimaryScreen.WorkingArea.Width;
            int ScrH = Screen.PrimaryScreen.WorkingArea.Height;
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            int W = MainForm.Width;
            int H = MainForm.Height;

            if (X + W > ScrW)
                X = ScrW - W;

            if (Y + H > ScrH)
                Y = ScrH - H;

            MainForm.Left = X;
            MainForm.Top = Y;
        }


        public void AddMenuItem(ToolStripItem item)
        {

            SystemMenu.Items.Add(item);
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPLACEMENT
        {
            public uint length;
            public uint flags;
            public uint showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        const UInt32 SW_HIDE = 0;
        const UInt32 SW_SHOWNORMAL = 1;
        const UInt32 SW_NORMAL = 1;
        const UInt32 SW_SHOWMINIMIZED = 2;
        const UInt32 SW_SHOWMAXIMIZED = 3;
        const UInt32 SW_MAXIMIZE = 3;
        const UInt32 SW_SHOWNOACTIVATE = 4;
        const UInt32 SW_SHOW = 5;
        const UInt32 SW_MINIMIZE = 6;
        const UInt32 SW_SHOWMINNOACTIVE = 7;
        const UInt32 SW_SHOWNA = 8;
        const UInt32 SW_RESTORE = 9;

        private WINDOWPLACEMENT GetFormPlacement(Form Src)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = (uint)Marshal.SizeOf(placement);
            bool res = GetWindowPlacement(Src.Handle, ref placement);
            return placement;
        }
    }
}
