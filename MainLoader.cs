using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DmScrCap
{
    public class MainLoader
    {
        public bool En_AutoSave = false;
        public string Def_FName;

        public FormEditor Editor;
        public FormCapturer Cap;
        public FormBucket Bucket;

        public NotificationControl SystemIcon;

        public MainLoader(string CommandLine)
        {
            Cap = new FormCapturer();
            Editor = new FormEditor();
            Bucket = new FormBucket();
          
            Parse_Parameter(CommandLine);

            SystemIcon = new NotificationControl(Editor, Editor.Icon);

            ToolStripMenuItem item;
            item = new ToolStripMenuItem();
            item.Click += SystemIconMenuBucket_Click;
            item.Text = "Bucket";
            SystemIcon.AddMenuItem(item);

            item = new ToolStripMenuItem();
            item.Click += SystemIconMenuEditor_Click;
            item.Text = "Editor";
            SystemIcon.AddMenuItem(item);

            Editor.Hide();

        }

        void SystemIconMenuBucket_Click(object sender, EventArgs e)
        {
            Bucket.Show();
        }

        void SystemIconMenuEditor_Click(object sender, EventArgs e)
        {
            Editor.Show();
        }


        public void Parse_Parameter(string StrParam)
        {
            En_AutoSave = (StrParam.IndexOf("/save") >= 0);
            Def_FName = GetStrInStr(StrParam, "(", ")");
        }

        public static string GetStrInStr(string Inp, string StrSt, string StrEn)
        {
            if (Inp.Length == 0)
                return "";
            int St = Inp.IndexOf(StrSt);
            int En = Inp.IndexOf(StrEn);
            if (((St < 0) || (En < 0)) && (En <= St))
                return "";
            return Inp.Substring(St + 1, En - St - 1);
        }





        

        public int RunWait()
        {


            Cap.SetRectFullScreen();
            Editor.DisplayImage.Image = Cap.LoadBitmapFromScreen();

            while (Editor.ShowDialog() == DialogResult.Retry)
            {
                if (Cap.ShowDialog() == DialogResult.Cancel)
                    break;
                Editor.DisplayImage.Image = Cap.LoadBitmapFromScreen();
            }

            if (Editor.DialogResult == DialogResult.Yes)
            {
                if (En_AutoSave)
                {
                    Editor.SaveImageFile(Def_FName);
                    return 1;
                }
                else
                {
                    if (Editor.SaveImageFile())
                        return 1;
                }
            }
            return 0;
        }
        
        



    }
}
