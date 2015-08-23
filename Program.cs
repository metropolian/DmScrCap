using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DmScrCap
{
    static class Program
    {
        static DataCollection Config = new DataCollection();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainLoader F = new MainLoader(Environment.CommandLine);

           
            Application.Run();
            //MainLoader F = new MainLoader(Environment.CommandLine);
            //Environment.ExitCode = F.Run();

        }
    }
}