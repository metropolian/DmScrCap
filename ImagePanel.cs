using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmScrCap
{
    public class ImagePanel : Panel
    {
        private Bitmap CurrentBitmap;

        public ImagePanel()
        {
            DoubleBuffered = true;
        }

        public Image Image
        {
            get { return CurrentBitmap; }

            set
            {
                if (value != null)
                {
                    CurrentBitmap = new Bitmap(value);
                    ResizeToFitScale();
                    Invalidate();
                }
                else
                {
                    if (CurrentBitmap != null)
                        CurrentBitmap.Dispose();
                    CurrentBitmap = null;
                }
            }
        }

        public float PosX = 0;
        public float PosY = 0;
        public float ScaleX = 0.5f;
        public float ScaleY = 0.5f;
        public float AspectRatio = 0;

        public void ResizeToFitScale()
        {
            if (CurrentBitmap == null)
                return;

            float W = (float)CurrentBitmap.Width;
            float H = (float)CurrentBitmap.Height;
            float BW = (float)this.ClientRectangle.Width;
            float BH = (float)this.ClientRectangle.Height;

            ScaleX = BW / W;
            ScaleY = BH / H;

            if (ScaleX < ScaleY)
                ScaleY = ScaleX;
            if (ScaleY < ScaleX)
                ScaleX = ScaleY;

            PosX = (float)this.ClientRectangle.Width / 2;
            PosY = (float)this.ClientRectangle.Height / 2;

        }

        public bool Render(Graphics Gfx)
        {
            if (CurrentBitmap != null)            
            {
                float BW = (float)this.CurrentBitmap.Width;
                float BH = (float)this.CurrentBitmap.Height;
             
                float SX = PosX;
                float SY = PosY;

                float W = BW * ScaleX;
                float H = BH * ScaleY;

                SX -= (W * 0.5f);
                SY -= (H * 0.5f);

                Gfx.DrawImage(CurrentBitmap,
                    SX, SY,
                    W, H);

                return true;
            }
            return false;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            ResizeToFitScale();
            base.OnResize(eventargs);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Render(e.Graphics))
               base.OnPaint(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta > 0)
            {
                if ((ScaleX < 2f) && (ScaleY < 2f))
                {
                    ScaleX += 0.1f;
                    ScaleY += 0.1f;
                }
            }
            else
            {
                if ((ScaleX >= 0.2f) && (ScaleY >= 0.2f))
                {
                    ScaleX -= 0.1f;
                    ScaleY -= 0.1f;
                }
            }

            Invalidate();
        }

        
        public static int WM_MOUSEWHEEL = 0x020A;

        protected override void WndProc(ref Message m)
        {            
            base.WndProc(ref m);

        }

    }
}
