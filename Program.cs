using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag;
            new Mutex(false, @"Local\AudioPPMInstance", out flag);
            if (!flag)
                return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Form1();
            Application.Run();
        }
    }
}
