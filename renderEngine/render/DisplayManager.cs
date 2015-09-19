using cube_thing.renderEngine.components;
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.core;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.core.renderer;
using cube_thing.renderEngine.tools.loader;
using cube_thing.renderEngine.tools.utils;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render
{
    public class DisplayManager
    {
        private Timer timer;
        private Settings settings;
        private glWindow window;

        public DisplayManager()
        {
            settings = Settings.getInstance();
            timer = Timer.getInstance();
            using (window = new glWindow(OnLoad, onResize, OnUpdateFrame, OnRenderFrame))
            {
                window.Run(60.0, 60.0);
            }
//            Loader.getInstance().cleanUp();
        }

        private void OnLoad(EventArgs e)
        {
            glViewport(0, 0, settings.getCurrentWindowSize()[0], settings.getCurrentWindowSize()[1]);
           
            timer.setLastFrameTime(Timer.getCurrentTime());
        }

        private void onResize(EventArgs e)
        {
            Console.WriteLine(window.Width +"# "+ window.Height);
            settings.setCurrentWindowSize(new int[] { window.Width, window.Height });
            foreach (AbstractCamera cam in AbstractCamera.getCameras())
            {
                cam.setDisplaySize(window.Width, window.Height);
            }
            glViewport(0, 0, settings.getCurrentWindowSize()[0], settings.getCurrentWindowSize()[1]);
        }
        private void OnUpdateFrame(FrameEventArgs e)
        {
            foreach (GameObject g in World.getInstance().getGameObjects())
            {
                gameObjectLoop(g);
            }
        }

        private void OnRenderFrame(FrameEventArgs e)
        {
            MasterRenderer.getInstance().render();
            OpenTK.Graphics.GL.Flush();
        }
        private static void gameObjectLoop(GameObject g)
        {
            List<Component> c = g.getComponent();
            for (int i = 0; i < c.Count; i++)
                c[i].update();
            for (int i = 0; i < g.getChildrens().Count; i++)
                gameObjectLoop(g.getChildrens()[i]);
        }

    }
}
