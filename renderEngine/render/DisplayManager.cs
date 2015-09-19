using cube_thing.renderEngine.components;
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.core;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.core.renderer;
using cube_thing.renderEngine.tools.utils;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render
{
    public class DisplayManager
    {
        private static tools.utils.Timer timer;
        private Settings settings;
        public delegate void Init();

        public DisplayManager(Init init, Panel canvas)
        {
                GLControl control = new GLControl(new GraphicsMode(32, 24, 8, 4), 3, 2, GraphicsContextFlags.Debug);
                
                canvas.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                control.CreateControl();
                settings = Settings.getInstance();
                timer = tools.utils.Timer.getInstance();

                init();
                control.Load += (s, e) => {
                    init();

                    settings.setCurrentWindowSize(new int[] { control.Width, control.Height });
                    foreach (AbstractCamera cam in AbstractCamera.getCameras())
                    {
                        cam.setDisplaySize(control.Width, control.Height);
                    }
                    glViewport(0, 0, settings.getCurrentWindowSize()[0], settings.getCurrentWindowSize()[1]);

                    timer.setLastFrameTime(tools.utils.Timer.getCurrentTime());
                };
                control.Paint += (s, e) => {
                    foreach (GameObject g in World.getInstance().getGameObjects())
                    {
                        gameObjectLoop(g);
                    }

                    MasterRenderer.getInstance().render();
                    control.SwapBuffers();

                    long currentFrameTime = tools.utils.Timer.getCurrentTime();
                    timer.setDeltaTime((currentFrameTime - timer.getLastFrameTime()) / 1000.0f);
                    InfoContainer.getInstance().incrementFPS();
                    timer.setNewSecond(false);
                    if (currentFrameTime - timer.getLastFPS() > 1000)
                    {
                        timer.setLastFPS(currentFrameTime);
                        InfoContainer.getInstance().saveFPS();
                        timer.setNewSecond(true);
                    }
                    timer.setLastFrameTime(currentFrameTime);

                    control.Invalidate();
                };
                control.Resize += (s, e) => {
                    settings.setCurrentWindowSize(new int[] { control.Width, control.Height });
                    foreach (AbstractCamera cam in AbstractCamera.getCameras())
                    {
                        cam.setDisplaySize(control.Width, control.Height);
                    }
                    glViewport(0, 0, settings.getCurrentWindowSize()[0], settings.getCurrentWindowSize()[1]);
                };
                control.MakeCurrent();
            
        }


        public DisplayManager(Init init)
        {
            settings = Settings.getInstance();
            timer = tools.utils.Timer.getInstance();

            using (var game = new GameWindow(settings.getCurrentWindowSize()[0], settings.getCurrentWindowSize()[1], new GraphicsMode(32, 24, 8, 4)))
            {

                game.Keyboard.KeyDown += new EventHandler<KeyboardKeyEventArgs>((s,e)=>
                {
                    if(e.Key == Key.A)
                    {
                        AbstractCamera.getMainCamera().gameObject.transform.position.X -= 1;
                    }
                    if (e.Key == Key.D)
                    {
                        AbstractCamera.getMainCamera().gameObject.transform.position.X += 1;
                    }
                    if (e.Key == Key.W)
                    {
                        AbstractCamera.getMainCamera().gameObject.transform.position.Z -= 1;
                    }
                    if (e.Key == Key.S)
                    {
                        AbstractCamera.getMainCamera().gameObject.transform.position.Z += 1;
                    }
                });
                game.Load += (sender, e) =>
                {
                    init();
                    glViewport(0, 0, settings.getCurrentWindowSize()[0], settings.getCurrentWindowSize()[1]);
                    timer.setLastFrameTime(tools.utils.Timer.getCurrentTime());
                };

                game.Resize += (sender, e) =>
                {
                    settings.setCurrentWindowSize(new int[] { game.Width, game.Height });
                    foreach (AbstractCamera cam in AbstractCamera.getCameras())
                    {
                        cam.setDisplaySize(game.Width, game.Height);
                    }
                    glViewport(0, 0, settings.getCurrentWindowSize()[0], settings.getCurrentWindowSize()[1]);
                };

                game.UpdateFrame += (sender, e) =>
                {
                    foreach (GameObject g in World.getInstance().getGameObjects())
                    {
                        gameObjectLoop(g);
                    }

                    game.Title = settings.getWindowTitle() + " FPS: " + InfoContainer.getInstance().getFPS();
                    
                };

                game.RenderFrame += (sender, e) =>
                {
                    MasterRenderer.getInstance().render();
                    game.SwapBuffers();
                    long currentFrameTime = tools.utils.Timer.getCurrentTime();
                    timer.setDeltaTime((currentFrameTime - timer.getLastFrameTime()) / 1000.0f);
                    InfoContainer.getInstance().incrementFPS();
                    timer.setNewSecond(false);
                    if (currentFrameTime - timer.getLastFPS() > 1000)
                    {
                        timer.setLastFPS(currentFrameTime);
                        InfoContainer.getInstance().saveFPS();
                        timer.setNewSecond(true);
                    }
                    timer.setLastFrameTime(currentFrameTime);
                };

                // Run the game at 60 updates per second
                game.Run(60.0,60.0);
            }
        
//            Loader.getInstance().cleanUp();
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
