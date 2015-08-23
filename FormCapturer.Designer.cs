namespace DmScrCap
{
    partial class FormCapturer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CapTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CapTime
            // 
            this.CapTime.Enabled = true;
            this.CapTime.Tick += new System.EventHandler(this.CapTime_Tick);
            // 
            // ScrCapturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(578, 273);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScrCapturer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen Capturer";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.ScrCapturer_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScrCapturer_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrCapturer_Paint);
            this.DoubleClick += new System.EventHandler(this.ScrCapturer_DoubleClick);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScrCapturer_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScrCapturer_MouseDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScrCapturer_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScrCapturer_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer CapTime;
    }
}

