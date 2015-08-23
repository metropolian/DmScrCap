using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DmScrCap
{
    public partial class FormBucket : Form
    {
        public FormBucket()
        {
            InitializeComponent();
        }

        private void FormBucket_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;            
        }

        private void FormBucket_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void FormBucket_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            
        }

        private void BtPaste_Click(object sender, EventArgs e)
        {
            if ( Clipboard.ContainsImage())
            {
                SetImage( (Bitmap) Clipboard.GetImage() );
            }
        }


        public void SetImage(Bitmap bmp)
        {
            pictureBox1.Image = bmp;
            LbStatus.Text = "W: " + bmp.Width.ToString() + " H: " + bmp.Height.ToString();
        }
    }
}
