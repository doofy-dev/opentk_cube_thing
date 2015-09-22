
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.components.renderer;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.render;
using cube_thing.renderEngine.render.model;
using cube_thing.renderEngine.render.shader.material;
using OpenTK;
using OpenTK.Input;
using renderEngine.events;
using System;


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

            DisplayManager window = new DisplayManager();
            //CAMERA setup

            GameObject camera = new GameObject("camera");   //Creating gameObject //String parameter is just a name
            AbstractCamera cam = new AbstractCamera();  //Creating camera
            World.getInstance().assingGameObject(camera);       //Adding gameobject to the world

            cam.setMain();                              //Sets this camera as main
            cam.setBackgroundColor(new Vector3(0, 0, 0)); //Sets background color  ->  RGB 0-1 at scale
            camera.addComponent(cam);                   //Adding the camera component to the gameobject
            camera.transform.position.Z = 10;                   //Setting camera gameobject's position

            //Sample box setup
            GameObject box = new GameObject("Box");
            World.getInstance().assingGameObject(box);  //Add gameobject to the world

            GameObject box2 = new GameObject("Box2");
            box.addChild(box2);
            box2.transform.position.Y = 2;
            //EVENTS
            KBEvent.getInstance(Key.A).addKeyDown(() =>
            {
                camera.transform.rotation.Y--;
            });
            KBEvent.getInstance(Key.D).addKeyDown(() =>
            {
                camera.transform.rotation.Y++;
            });
            KBEvent.getInstance(Key.W).addKeyDown(() =>
            {
                camera.transform.rotation.X--;
            });
            KBEvent.getInstance(Key.S).addKeyDown(() =>
            {
                camera.transform.rotation.X++;
            });
            KBEvent.getInstance(Key.Q).addKeyDown(() =>
            {
                camera.transform.position.Z-=0.1f;
            });
            KBEvent.getInstance(Key.E).addKeyDown(() =>
            {
                camera.transform.position.Z += 0.1f;
            });


            KBEvent.getInstance(Key.Escape).addKeyDown(() =>
            {
                window.getWindow().Exit();
            });

            //Window's onLoad event, OpenGL dependent code has to be here
            window.Load(() =>
            {
                DefaultMat material = new DefaultMat(); //Creating material component
                material.setCullingEnabled(true);       //Backface culling enabled
                Renderer m = new Renderer(Primitives.Cube(), material);     //Creating renderer component -> Parameters Primitives.PRIMITIVE_NAME, material
                box.addComponent(m);                    //Assing renderer to the gameobject

                Renderer m2 = new Renderer(Primitives.Cube(), material);     //Creating renderer component -> Parameters Primitives.PRIMITIVE_NAME, material
                box2.addComponent(m2);
                material.setColor(new Vector4(1, 0, 0.1f, 1));      //Setting the materials color


            });

            //Starting the rendering at 60 Update/s with 60 FPS
            window.Start(60, 60);
        }
    }
}
