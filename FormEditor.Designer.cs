namespace DmScrCap
{
    partial class FormEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditor));
            this.LbInfor = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbSourceName = new System.Windows.Forms.ToolStripStatusLabel();
            this.DisplayImage = new DmScrCap.ImagePanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtCapture = new System.Windows.Forms.ToolStripButton();
            this.BtCopy = new System.Windows.Forms.ToolStripButton();
            this.BtPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.BtSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.BtAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.BtAutoCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TxImgWidth = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TxImgHeight = new System.Windows.Forms.ToolStripTextBox();
            this.BtResize = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtSetSize = new System.Windows.Forms.ToolStripMenuItem();
            this.BtAutoResize = new System.Windows.Forms.ToolStripMenuItem();
            this.BtAutoKeepRatio = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenu_CopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu_PasteFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenu_CopyFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.EditorContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbInfor
            // 
            this.LbInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbInfor.AutoSize = true;
            this.LbInfor.BackColor = System.Drawing.SystemColors.Info;
            this.LbInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LbInfor.Location = new System.Drawing.Point(12, 393);
            this.LbInfor.Name = "LbInfor";
            this.LbInfor.Size = new System.Drawing.Size(10, 15);
            this.LbInfor.TabIndex = 2;
            this.LbInfor.Text = " ";
            this.LbInfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.DisplayImage);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(585, 414);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(585, 463);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbStatus,
            this.LbSourceName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(585, 23);
            this.statusStrip1.TabIndex = 0;
            // 
            // LbStatus
            // 
            this.LbStatus.Name = "LbStatus";
            this.LbStatus.Size = new System.Drawing.Size(141, 18);
            this.LbStatus.Text = "toolStripStatusLabel1";
            // 
            // LbSourceName
            // 
            this.LbSourceName.Name = "LbSourceName";
            this.LbSourceName.Size = new System.Drawing.Size(141, 18);
            this.LbSourceName.Text = "toolStripStatusLabel1";
            // 
            // DisplayImage
            // 
            this.DisplayImage.BackColor = System.Drawing.Color.Transparent;
            this.DisplayImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DisplayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayImage.Image = null;
            this.DisplayImage.Location = new System.Drawing.Point(0, 0);
            this.DisplayImage.Name = "DisplayImage";
            this.DisplayImage.Size = new System.Drawing.Size(585, 414);
            this.DisplayImage.TabIndex = 0;
            this.DisplayImage.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayImage_Paint);
            this.DisplayImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayImage_MouseDown);
            this.DisplayImage.MouseEnter += new System.EventHandler(this.DisplayImage_MouseEnter);
            this.DisplayImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayImage_MouseMove);
            this.DisplayImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayImage_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtCapture,
            this.BtCopy,
            this.BtPaste,
            this.toolStripSplitButton1,
            this.toolStripSeparator1,
            this.TxImgWidth,
            this.toolStripLabel1,
            this.TxImgHeight,
            this.BtResize});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(467, 26);
            this.toolStrip1.TabIndex = 0;
            // 
            // BtCapture
            // 
            this.BtCapture.Image = global::DmScrCap.Properties.Resources.Windows;
            this.BtCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtCapture.Name = "BtCapture";
            this.BtCapture.Size = new System.Drawing.Size(79, 23);
            this.BtCapture.Text = "Capture";
            this.BtCapture.Click += new System.EventHandler(this.BtCapture_Click);
            // 
            // BtCopy
            // 
            this.BtCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtCopy.Image = global::DmScrCap.Properties.Resources.Application_Blueprint;
            this.BtCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtCopy.Name = "BtCopy";
            this.BtCopy.Size = new System.Drawing.Size(23, 23);
            this.BtCopy.Text = "toolStripButton1";
            // 
            // BtPaste
            // 
            this.BtPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtPaste.Image = global::DmScrCap.Properties.Resources.Clipboard;
            this.BtPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtPaste.Name = "BtPaste";
            this.BtPaste.Size = new System.Drawing.Size(23, 23);
            this.BtPaste.Text = "Paste";
            this.BtPaste.Click += new System.EventHandler(this.BtPaste_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtSaveAs,
            this.BtAutoSave,
            this.BtAutoCopyPath});
            this.toolStripSplitButton1.Image = global::DmScrCap.Properties.Resources.Cut;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(72, 23);
            this.toolStripSplitButton1.Text = "Save";
            // 
            // BtSaveAs
            // 
            this.BtSaveAs.Name = "BtSaveAs";
            this.BtSaveAs.Size = new System.Drawing.Size(203, 22);
            this.BtSaveAs.Text = "Save as ...";
            this.BtSaveAs.Click += new System.EventHandler(this.BtSaveAs_Click);
            // 
            // BtAutoSave
            // 
            this.BtAutoSave.Name = "BtAutoSave";
            this.BtAutoSave.Size = new System.Drawing.Size(203, 22);
            this.BtAutoSave.Text = "Auto Save";
            this.BtAutoSave.Click += new System.EventHandler(this.BtAutoSave_Click);
            // 
            // BtAutoCopyPath
            // 
            this.BtAutoCopyPath.Name = "BtAutoCopyPath";
            this.BtAutoCopyPath.Size = new System.Drawing.Size(203, 22);
            this.BtAutoCopyPath.Text = "Auto Copy File Path";
            this.BtAutoCopyPath.Click += new System.EventHandler(this.BtAutoCopyPath_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // TxImgWidth
            // 
            this.TxImgWidth.Name = "TxImgWidth";
            this.TxImgWidth.Size = new System.Drawing.Size(60, 26);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 23);
            this.toolStripLabel1.Text = "x";
            // 
            // TxImgHeight
            // 
            this.TxImgHeight.Name = "TxImgHeight";
            this.TxImgHeight.Size = new System.Drawing.Size(60, 26);
            // 
            // BtResize
            // 
            this.BtResize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.BtSetSize,
            this.BtAutoResize,
            this.BtAutoKeepRatio});
            this.BtResize.Image = global::DmScrCap.Properties.Resources.Blocknotes_2;
            this.BtResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtResize.Name = "BtResize";
            this.BtResize.Size = new System.Drawing.Size(81, 23);
            this.BtResize.Text = "Resize";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Reset";
            // 
            // BtSetSize
            // 
            this.BtSetSize.Name = "BtSetSize";
            this.BtSetSize.Size = new System.Drawing.Size(152, 22);
            this.BtSetSize.Text = "Resize";
            this.BtSetSize.Click += new System.EventHandler(this.BtSetSize_Click);
            // 
            // BtAutoResize
            // 
            this.BtAutoResize.Name = "BtAutoResize";
            this.BtAutoResize.Size = new System.Drawing.Size(152, 22);
            this.BtAutoResize.Text = "Auto Resize";
            this.BtAutoResize.Click += new System.EventHandler(this.BtAutoResize_Click);
            // 
            // BtAutoKeepRatio
            // 
            this.BtAutoKeepRatio.Name = "BtAutoKeepRatio";
            this.BtAutoKeepRatio.Size = new System.Drawing.Size(152, 22);
            this.BtAutoKeepRatio.Text = "Keep Ratio";
            this.BtAutoKeepRatio.Click += new System.EventHandler(this.BtAutoKeepRatio_Click);
            // 
            // EditorContextMenu
            // 
            this.EditorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenu_CopyToClipboard,
            this.ContextMenu_PasteFromClipboard,
            this.toolStripMenuItem2,
            this.ContextMenu_CopyFilePath});
            this.EditorContextMenu.Name = "EditorContextMenu";
            this.EditorContextMenu.Size = new System.Drawing.Size(212, 76);
            // 
            // ContextMenu_CopyToClipboard
            // 
            this.ContextMenu_CopyToClipboard.Name = "ContextMenu_CopyToClipboard";
            this.ContextMenu_CopyToClipboard.Size = new System.Drawing.Size(211, 22);
            this.ContextMenu_CopyToClipboard.Text = "Copy to Clipboard";
            this.ContextMenu_CopyToClipboard.Click += new System.EventHandler(this.ContextMenu_CopyToClipboard_Click);
            // 
            // ContextMenu_PasteFromClipboard
            // 
            this.ContextMenu_PasteFromClipboard.Name = "ContextMenu_PasteFromClipboard";
            this.ContextMenu_PasteFromClipboard.Size = new System.Drawing.Size(211, 22);
            this.ContextMenu_PasteFromClipboard.Text = "Paste from Clipboard";
            this.ContextMenu_PasteFromClipboard.Click += new System.EventHandler(this.ContextMenu_PasteFromClipboard_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(208, 6);
            // 
            // ContextMenu_CopyFilePath
            // 
            this.ContextMenu_CopyFilePath.Name = "ContextMenu_CopyFilePath";
            this.ContextMenu_CopyFilePath.Size = new System.Drawing.Size(211, 22);
            this.ContextMenu_CopyFilePath.Text = "Copy File Path";
            this.ContextMenu_CopyFilePath.Click += new System.EventHandler(this.ContextMenu_CopyFilePath_Click);
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(585, 463);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.LbInfor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditor";
            this.Text = "Screen Capturer - Previewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditor_FormClosing);
            this.Load += new System.EventHandler(this.FormEditor_Load);
            this.Shown += new System.EventHandler(this.FormEditor_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormEditor_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormEditor_DragEnter);
            this.MouseLeave += new System.EventHandler(this.FormEditor_MouseLeave);
            this.Resize += new System.EventHandler(this.FormEditor_Resize);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.EditorContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ImagePanel DisplayImage;
        private System.Windows.Forms.Label LbInfor;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtCapture;
        private System.Windows.Forms.ToolStripButton BtPaste;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem BtSaveAs;
        private System.Windows.Forms.ToolStripMenuItem BtAutoSave;
        private System.Windows.Forms.ToolStripMenuItem BtAutoCopyPath;
        private System.Windows.Forms.ToolStripSplitButton BtResize;
        private System.Windows.Forms.ToolStripMenuItem BtSetSize;
        private System.Windows.Forms.ToolStripMenuItem BtAutoResize;
        private System.Windows.Forms.ToolStripMenuItem BtAutoKeepRatio;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox TxImgWidth;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TxImgHeight;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip EditorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_CopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_PasteFromClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ContextMenu_CopyFilePath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LbStatus;
        private System.Windows.Forms.ToolStripStatusLabel LbSourceName;
        private System.Windows.Forms.ToolStripButton BtCopy;

    }
}