using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;
using DmShared;

namespace DmScrCap
{
    public partial class FormEditor : Form
    {
        public DataCollection Config;
        public bool AllowQuit;
        public string AutoSavePath = "";
        public string AutoSaveFileNameFormat = "{0:yyyy-MM-dd HH-mm}.png";

        public bool AutoSave
        {
            get { return BtAutoSave.Checked; }
            set { BtAutoSave.Checked = value; }
        }


        public FormCapturer Capturer;

        public FormEditor()
        {
            InitializeComponent();
        }


        public void Init()
        {
            try
            {
                AddClipboardFormatListener(this.Handle);

                AutoSavePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\autosave";

                LoadConfig();

                this.AllowDrop = true;
                this.AllowQuit = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadConfig()
        {
            Config = JSONConfig.LoadDataCollectionFile("config.txt");
        }

        public void SaveConfig()
        {
            JSONConfig.SaveDataCollectionFile("config.txt", Config);
        }

        public string Gen_AutoSaveFileName()
        {
            return AutoSavePath + "/" + string.Format(AutoSaveFileNameFormat, DateTime.Now);
        }


        private void FormEditor_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void FormEditor_Shown(object sender, EventArgs e)
        {
            FileInfo F = GetLatestWritenFileFileInDirectory(new DirectoryInfo(AutoSavePath));

            if ((F != null) && F.Exists)
                LoadImage(F.FullName);
            else
                LoadImage(DisplayImage.Image);
        }
        
        private void FormEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllowQuit)
            {
                e.Cancel = true;
                this.Hide();
            }
        }




        private static FileInfo GetLatestWritenFileFileInDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null || !directoryInfo.Exists)
                return null;

            FileInfo[] files = directoryInfo.GetFiles();
            DateTime lastWrite = DateTime.MinValue;
            FileInfo lastWritenFile = null;

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastWrite)
                {
                    lastWrite = file.LastWriteTime;
                    lastWritenFile = file;
                }
            }
            return lastWritenFile;
        }


        #region "Form Events"

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool AddClipboardFormatListener(IntPtr hWnd);



        private bool WndProc_ClipboardUpdate(ref Message m)
        {
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if (LoadDataObject(Clipboard.GetDataObject()))
                {
                    if (AutoSave)
                        SaveImageFile(Gen_AutoSaveFileName());
                }
                return true;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }



        public static int WM_CLIPBOARDUPDATE = 0x031D;

        private void FormEditor_MouseLeave(object sender, EventArgs e)
        {
            //DoDragDrop("C:\\", DragDropEffects.Copy);

        }

        private void FormEditor_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            if (e.Data.GetDataPresent("FileDrop"))
                e.Effect = DragDropEffects.Copy;

            if (e.Data.GetDataPresent("Text"))
                e.Effect = DragDropEffects.Copy;

        }

        private void FormEditor_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string s in e.Data.GetFormats())
            {
                Console.WriteLine(s);
            }

            e.Effect = DragDropEffects.Copy;

            LoadDataObject(e.Data);
        }

        private void FormEditor_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }


        #endregion







        
        private void BtCapture_Click(object sender, EventArgs e)
        {
            Capturer = new FormCapturer();

            this.Hide();

            if ( Capturer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadImage(Capturer.LoadBitmapFromScreen());
            }

            Capturer.Dispose();

            this.Show();
        }

        private void BtSaveAs_Click(object sender, EventArgs e)
        {
            SaveImageFile();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            
        }



        public ImageFormat GetImageFormatByFName(string FName)
        {
            if (FName.ToLower().IndexOf(".jpg") >= 0)
                return GetImageFormat(1);
            if (FName.ToLower().IndexOf(".gif") >= 0)
                return GetImageFormat(2);
            if (FName.ToLower().IndexOf(".png") >= 0)
                return GetImageFormat(3);
            if (FName.ToLower().IndexOf(".tiff") >= 0)
                return GetImageFormat(4);
            if (FName.ToLower().IndexOf(".wmf") >= 0)
                return GetImageFormat(5);
            return GetImageFormat(0);
        }

        public ImageFormat GetImageFormat(int Index)
        {
            switch (Index)
            {
                case 0: return ImageFormat.Bmp;
                case 1: return ImageFormat.Jpeg;
                case 2: return ImageFormat.Gif;
                case 3: return ImageFormat.Png;
                case 4: return ImageFormat.Tiff;
                case 5: return ImageFormat.Wmf;
                default:
                    return ImageFormat.Bmp;
            }
        }

        #region "LOADING"
        public bool LoadImage(string FName)
        {
            Image Img = Image.FromFile(FName);
            Bitmap Bmp = new Bitmap(Img);
            Img.Dispose();
            return LoadImage(Bmp);
        }


        public bool LoadImage(Image Src)
        {
            if (Src != null)
            {
                LbInfor.Text =
                    "Image Properties\n" +
                    "Width: " + Src.PhysicalDimension.Width.ToString() +
                    " Height: " + Src.PhysicalDimension.Height.ToString()
                    ;
                TxImgWidth.Text = Src.PhysicalDimension.Width.ToString();
                TxImgHeight.Text = Src.PhysicalDimension.Height.ToString();

            }
            else
            {
                LbInfor.Text = "";
            }

            DisplayImage.Image = Src;
            return (Src != null);
        }


        public bool LoadDataObject(object Src)
        {
            try
            {
                DataObject d = new DataObject(Src);

                if (d.ContainsImage())
                {
                    if (LoadImage(d.GetImage()))
                        return true;
                }

                if (d.ContainsFileDropList())
                {
                    foreach (string FName in d.GetFileDropList())
                    {
                        try
                        {
                            if (LoadImage(FName))
                                return true;

                        }
                        catch
                        {
                        }
                    }
                }

                if (d.ContainsText())
                {
                    string FName = d.GetText().Trim();

                    if ((FName.IndexOf("http://") == 0) ||
                        (FName.IndexOf("https://") == 0))
                    {
                        if (LoadImageFromUrl(FName))
                            return true;

                    }
                    else
                    {
                        if (File.Exists(FName))
                        {
                            if (LoadImage(FName))
                                return true;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());

            }
            return false;
        }


        public bool LoadImageFromUrl(string Url)
        {
            bool res = false;
            if ((Url == null) || (Url == ""))
                return res;
            WebRequest request = WebRequest.Create(Url);
            WebResponse response = request.GetResponse();

            string ContentType = response.ContentType;

            if (ContentType.IndexOf("image") >= 0)
            {
                Stream FSrc = response.GetResponseStream();
                MemoryStream FDest = new MemoryStream();
                byte[] Buf = new byte[4096];
                int ReadCount = 0;

                while ((ReadCount = FSrc.Read(Buf, 0, Buf.Length)) > 0)
                {
                    FDest.Write(Buf, 0, ReadCount);
                }

                Image Img = Image.FromStream(FDest);
                Bitmap Bmp = new Bitmap(Img);
                Img.Dispose();
                res = LoadImage(Bmp);
                FDest.Close();

                FSrc.Close();
            }
            else
            {
                MessageBox.Show("Content-Type is NOT image. (" + ContentType + ").");
            }

            response.Close();
            return res;
        }
        #endregion

        #region "SAVING"

        public void SaveImageFile_Auto()
        {
            SaveImageFile(Gen_AutoSaveFileName());
        }

        public bool SaveImageFile()
        {
            try
            {
                SaveFileDialog SaveDlg = new SaveFileDialog();
                SaveDlg.OverwritePrompt = true;
                SaveDlg.RestoreDirectory = true;
                SaveDlg.Filter = "BMP File|*.bmp|JPEG File|*.jpg|GIF File|*.gif|PNG File|*.png|TIFF File|*.tiff";
                if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    DisplayImage.Image.Save(SaveDlg.FileName, GetImageFormat(SaveDlg.FilterIndex - 1));
                    return true;
                }
            }
            catch (Exception EX)
            {
            }
            return false;
        }

        public bool SaveImageFile(string FName)
        {
            try
            {
                FileInfo F = new FileInfo(FName);
                if (!Directory.Exists(F.DirectoryName))
                {
                    if (!Directory.CreateDirectory(F.DirectoryName).Exists)
                        return false;
                }

                DisplayImage.Image.Save(F.FullName, GetImageFormatByFName(FName));

                if (AutoCopyPath)
                    Clipboard.SetText(F.FullName);

                return true;
            }
            catch (Exception EX)
            {
            }
            return false;
        }

        #endregion

        private void DisplayImage_MouseEnter(object sender, EventArgs e)
        {
            DisplayImage.Focus();        
        }



        public bool AutoCopyPath
        {
            get { return BtAutoCopyPath.Checked; }
        }


        private void BtPaste_Click(object sender, EventArgs e)
        {
            LoadDataObject(Clipboard.GetDataObject());
        }

        private void BtAutoSave_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        }

        private void BtAutoResize_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        }

        private void BtAutoKeepRatio_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        }

        private void BtAutoCopyPath_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        }

        private void BtSetSize_Click(object sender, EventArgs e)
        {

        }





        private void DisplayImage_Paint(object sender, PaintEventArgs e)
        {

        }


        private MouseButtons DisplayImage_MouseButtons = System.Windows.Forms.MouseButtons.None;
        private Point DisplayImage_MousePos;

        private void DisplayImage_MouseDown(object sender, MouseEventArgs e)
        {
            DisplayImage_MouseButtons = e.Button;
            DisplayImage_MousePos = e.Location;
        }


        private void DisplayImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (DisplayImage_MouseButtons == System.Windows.Forms.MouseButtons.Left)
            {
                if ((DisplayImage_MousePos.X != e.Location.X) && (DisplayImage_MousePos.Y != e.Location.Y))
                {
                    if (DisplayImage.Image != null)
                    {
                        DoDragDrop((Bitmap)DisplayImage.Image, DragDropEffects.Copy);
                        DisplayImage_MouseButtons = System.Windows.Forms.MouseButtons.None;
                    }
                }
            }
        }
        private void DisplayImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                EditorContextMenu.Show(sender as Control , new Point(e.X, e.Y));
            }

            DisplayImage_MouseButtons = System.Windows.Forms.MouseButtons.None;
        }

        private void ContextMenu_CopyToClipboard_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenu_PasteFromClipboard_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenu_CopyFilePath_Click(object sender, EventArgs e)
        {

        }


    }
}
