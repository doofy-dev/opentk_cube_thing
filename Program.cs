
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.components.renderer;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.render;
using cube_thing.renderEngine.render.model;
using cube_thing.renderEngine.render.shader.material;
using System;
using System.Collections.Generic;
using System.Threading;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTest());
           
        }
    }
}
