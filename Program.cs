
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cube_thing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
            using (Main main = new Main())
            {
                main.Run(60.0,60.0);
            }
        }
    }
}
