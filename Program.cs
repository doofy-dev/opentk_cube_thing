
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.render;
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
            AbstractCamera cam = new AbstractCamera();
            cam.setMain();
            cam.setBackgroundColor(new OpenTK.Vector3(100, 100, 100));
            new DisplayManager();
        }
    }
}
