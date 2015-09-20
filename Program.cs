
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.components.renderer;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.render;
using cube_thing.renderEngine.render.model;
using cube_thing.renderEngine.render.shader.material;
using OpenTK;
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
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTest());*/
            new DisplayManager(() =>
            {
                //CAMERA setup
                GameObject camera = new GameObject("camera");   //Creating gameObject //String parameter is just a name
                AbstractCamera cam = new AbstractCamera();  //Creating camera
                cam.setMain();                              //Sets this camera as main
                cam.setBackgroundColor(new Vector3(0,0,0)); //Sets background color  ->  RGB 0-1 at scale
                camera.addComponent(cam);                   //Adding the camera component to the gameobject
                World.getInstance().assingGameObject(camera);       //Adding gameobject to the world
                camera.transform.position.Z = 10;                   //Setting camera gameobject's position

                //Sample box setup
                GameObject box = new GameObject("Box");         
                DefaultMat material = new DefaultMat(); //Creating material component
                material.setCullingEnabled(true);       //Backface culling enabled
                Renderer m = new Renderer(Primitives.Cube(), material);     //Creating renderer component -> Parameters Primitives.PRIMITIVE_NAME, material
                box.addComponent(m);                    //Assing renderer to the gameobject
                World.getInstance().assingGameObject(box);  //Add gameobject to the world


                material.setColor(new Vector4(1, 0, 0.1f, 1));      //Setting the materials color

            });

        }
    }
}
