using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

using DmGdiLib;

namespace DmScrCap
{
    public partial class FormCapturer : Form
    {
        public FormCapturer()
        {
            InitializeComponent();
        }

        private void ScrCapturer_Load(object sender, EventArgs e)
        {
            /*Left = 0;
            Top = 0; */
            MouseRect = Bounds = Screen.GetBounds(new Point());

            AllowTransparency = false;
            Opacity = 0.15;

            MouseFormRect = new Form();
            MouseFormRect.FormBorderStyle = FormBorderStyle.None;
            MouseFormRect.Bounds = this.Bounds;
            MouseFormRect.AllowTransparency = true;
            MouseFormRect.BackColor = Color.Brown;
            MouseFormRect.TransparencyKey = Color.Brown;
            MouseFormRect.Show();

            ScrCapturer_DrawInfor(MouseFormRect.CreateGraphics());            

            
        }

        void Tray_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }


        private void ScrCapturer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CapTime_Tick(object sender, EventArgs e)
        {
/*            IntPtr HDesktop = GetDesktopWindow();
            IntPtr HDeskDC = GetDC(HDesktop);

            Graphics Gfx = CreateGraphics();
            IntPtr HWinDC = Gfx.GetHdc();


            StretchBlt(HWinDC, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height,
                HDeskDC, 0, 0, 400, 400,
                0x00CC0020); 

            Gfx.ReleaseHdc();
            ReleaseDC(HDeskDC); */

        }

        private bool MouseDowning = false;
        private int MouseStX, MouseStY, MouseEnX, MouseEnY;
        private Form MouseFormRect = new Form();
        public bool EnMouseRect = false;
        public Rectangle MouseRect = new Rectangle();

        private void ScrCapturer_MouseDown(object sender, MouseEventArgs e)
        {
            MouseStX = e.X;
            MouseStY = e.Y;
            MouseDowning = true;
        }

        private void ScrCapturer_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDowning)
            {
                MouseEnX = e.X;
                MouseEnY = e.Y;

                int Tmp = 0, StX = MouseStX, StY = MouseStY, EnX = MouseEnX, EnY = MouseEnY;

                if (EnX < StX)
                {
                    Tmp = StX; StX = EnX; EnX = Tmp;
                }

                if (EnY < StY)
                {
                    Tmp = StY; StY = EnY; EnY = Tmp;
                }
                    
                MouseRect = Rectangle.FromLTRB(StX, StY, EnX, EnY);
                
                ScrCapturer_DrawMouseRect();
            }
        }

        private void ScrCapturer_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseDowning)
            {
                ScrCapturer_DrawMouseRect();
            }
            EnMouseRect = true;
            MouseDowning = false;
        }

        private void ScrCapturer_DrawInfor(Graphics Gfx)
        {
            Gfx.DrawString("Drag Region and Press ENTER / To Cancel Press ESC",
                new Font("Tahoma", 14.0f),
                new SolidBrush(Color.White),
                new PointF(12, 12)
            );

            string StrPos = "Position: " +
                MouseRect.X.ToString() + "," + MouseRect.Y.ToString() + " ~ " +
                MouseRect.Right.ToString() + "," + MouseRect.Bottom.ToString() +
                " (" + MouseRect.Width.ToString() + "x" +
                MouseRect.Height.ToString() + ")";
            Gfx.DrawString(StrPos,
                new Font("Tahoma", 12.0f),
                new SolidBrush(Color.White),
                new PointF(12, MouseFormRect.Bounds.Bottom - 36)
            );
        }

        private void ScrCapturer_DrawMouseRect()
        {
            Graphics Gfx = MouseFormRect.CreateGraphics();

            Gfx.Clear(Color.Brown);
            Gfx.DrawRectangle(new Pen(Color.Red), MouseRect);

            ScrCapturer_DrawInfor(Gfx);
        }

        private void ScrCapturer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DialogResult = DialogResult.OK;
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void ScrCapturer_DoubleClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ScrCapturer_FormClosed(object sender, FormClosedEventArgs e)
        {
            MouseFormRect.Close();
        }

        public void SetRectFullScreen()
        {
            MouseRect = Screen.GetBounds(new Point());
        }


        public Bitmap LoadBitmapFromScreen()
        {
            return LoadBitmapFromScreen(MouseRect);
        }

        public Bitmap LoadBitmapFromScreen(Rectangle SrcRect)
        {
            IntPtr HDesktop = GdiFunc.GetDesktopWindow();
            IntPtr HDeskDC = GdiFunc.GetDC(HDesktop);

            Graphics Gfx = CreateGraphics();
            IntPtr HFormDC = Gfx.GetHdc();

            /* Create Temporary DC Space */
            IntPtr NewHDC = GdiFunc.CreateCompatibleDC(HFormDC);
            IntPtr NewBmp = GdiFunc.CreateCompatibleBitmap(HFormDC, SrcRect.Width, SrcRect.Height);
            GdiFunc.SelectObject(NewHDC, NewBmp);

            /* Draw Out  */
            GdiFunc.StretchBlt(NewHDC, 0, 0, SrcRect.Width, SrcRect.Height, 
                HDeskDC, SrcRect.X, SrcRect.Y, SrcRect.Width, SrcRect.Height, 0x00CC0020); 

            Bitmap ResBmp = Bitmap.FromHbitmap(NewBmp);

            Gfx.ReleaseHdc(HFormDC);
            GdiFunc.ReleaseDC(HDeskDC);

            return ResBmp;
        }

    }
}