
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.components.renderer;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.render;
using cube_thing.renderEngine.render.model;
using cube_thing.renderEngine.render.shader.material;
using static renderEngine.utils.OpenTKAsOpenGL;
using renderEngine.events;
using OpenTK;
using OpenTK.Input;
using System;
using RenderEngine.renderEngine.tools.utils;
using System.Threading;
using OpenTK.Graphics;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

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
            cube_thing.renderEngine.core.Settings.getInstance().setCurrentWindowSize(new int[] { 1024, 768 });

            DisplayManager window = new DisplayManager();
            //CAMERA setup

            GameObject camera = new GameObject("camera");   //Creating gameObject //String parameter is just a name
            AbstractCamera cam = new AbstractCamera();  //Creating camera
            World.getInstance().assingGameObject(camera);       //Adding gameobject to the world

            cam.setMain();                              //Sets this camera as main
            cam.setBackgroundColor(new Vector3(1,1,1)); //Sets background color  ->  RGB 0-1 at scale
            camera.addComponent(cam);                   //Adding the camera component to the gameobject
            camera.transform.position = new Vector3(0, 0, -5);
            renderEngine.tools.utils.Timer timer = renderEngine.tools.utils.Timer.getInstance();

           
            //EVENTS
            KBEvent.getInstance(Key.A).addKeyDown(() =>
            {
                camera.transform.rotation.Y-= 10*timer.getDeltaTime();         //timer.getDeltaTime() is for FPS drop to move always the same speed
            });
            KBEvent.getInstance(Key.D).addKeyDown(() =>
            {
                camera.transform.rotation.Y+= 10 * timer.getDeltaTime();
            });
            KBEvent.getInstance(Key.W).addKeyDown(() =>
            {
                camera.transform.rotation.X-= 10 * timer.getDeltaTime();
            });
            KBEvent.getInstance(Key.S).addKeyDown(() =>
            {
                camera.transform.rotation.X+= 10 * timer.getDeltaTime();
            });
            KBEvent.getInstance(Key.Q).addKeyDown(() =>
            {
                cam.transform.position.Z-=1 * timer.getDeltaTime();
            });
            KBEvent.getInstance(Key.E).addKeyDown(() =>
            {
                cam.transform.position.Z += 1* timer.getDeltaTime();
            });


            KBEvent.getInstance(Key.Escape).addKeyDown(() =>
            {
                window.getWindow().Exit();
            });

            MWheelEvent.getInstance().addScroll((y) =>
            {
                cam.transform.position.Z -= y * timer.getDeltaTime()*20;
            });
            MMoveEvent.getInstance().addMove((x, y) =>
            {
                camera.transform.rotation.Y += x * timer.getDeltaTime()*10;
                camera.transform.rotation.X += y * timer.getDeltaTime()*10;
            });

            KBEvent.getInstance(Key.F12).addKeyPress(() =>
            {
            if (GraphicsContext.CurrentContext == null)
                throw new GraphicsContextMissingException();

                Bitmap bmp = new Bitmap(window.getWindow().ClientSize.Width, window.getWindow().ClientSize.Height);
                System.Drawing.Imaging.BitmapData data =
                bmp.LockBits(window.getWindow().ClientRectangle, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                GL.ReadPixels(0, 0, window.getWindow().ClientSize.Width, window.getWindow().ClientSize.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, OpenTK.Graphics.OpenGL.PixelType.UnsignedByte, data.Scan0);
                bmp.UnlockBits(data);

                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

                bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Screenshot\" +
                  DateTime.Now.ToString("yyy_MM_dd_h_mm_ss") + ".png");
            });

            //59
            float resolution = 69;
            camera.transform.position = new Vector3(resolution / 2f -0.5f, resolution / 2f - 0.5f, resolution / 2f-0.5f);
           cam.transform.position.Z = resolution;
            //Window's onLoad event, OpenGL dependent code has to be here

            VoxelList list = new VoxelList();

            Thread t = new Thread(delegate () {
                int R, G, B;
                R = G = B = 0;
                for (R = 0; R < resolution; R++)
                {
                    for (G = 0; G < resolution; G++)
                    {
                        for (B = 0; B < resolution; B++)
                        {
                            list = list.Add(new VoxelList(new int[] { R, G, B }, new float[] { R / resolution, G / resolution, B / resolution, 1 }));
                        }
                    }

                }
                Console.WriteLine("Done: "+VoxelList.length+" "+R+" "+G+" "+B);
            });
            t.Start();

            window.Load(() =>
            {
                /*
                //glDepthMask(false);
                for(int R = 0; R < resolution; R++)
                {
                    for (int G = 0; G < resolution; G++)
                    {
                        for (int B = 0; B < resolution; B++)
                        {
                            //Sample box setup
                            GameObject box = new GameObject("Box "+R+"-"+G+"-"+B);
                            box.transform.position = new Vector3(R, G, B);
                            DefaultMat material = new DefaultMat(); //Creating material component
                            material.setCullingEnabled(false);       //Backface culling enabled
                            material.setHasTransparency(true);
                            box.transform.scale = new Vector3(0.999f, 0.999f, 0.999f);
                            material.setColor(new Vector4(R/resolution, G/ resolution ,B/ resolution, 1));      //Setting the materials color
                            Renderer m = new Renderer(Primitives.Cube(), material);     //Creating renderer component -> Parameters Primitives.PRIMITIVE_NAME, material
                            box.addComponent(m);                    //Assing renderer to the gameobject
                            box.transform.createTransformationMatrix();
                            World.getInstance().assingGameObject(box);  //Add gameobject to the world

                            System.GC.Collect();
                        }
                    }
                }*/

            });

            //Starting the rendering at 60 Update/s with 60 FPS
            window.Start(60,60);
        }
    }
}
