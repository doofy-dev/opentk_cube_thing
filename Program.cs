
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
            box.transform.position.Y = 4;
            World.getInstance().assingGameObject(box);  //Add gameobject to the world
            renderEngine.tools.utils.Timer timer = renderEngine.tools.utils.Timer.getInstance();
            GameObject box2 = new GameObject("Box2");
            World.getInstance().assingGameObject(box2);
            box2.transform.position.Y = 6;
            GameObject box3 = new GameObject("Box3");
            World.getInstance().assingGameObject(box3);
            box3.transform.position.Y = 2;

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
                camera.transform.position.Z-=1 * timer.getDeltaTime();
            });
            KBEvent.getInstance(Key.E).addKeyDown(() =>
            {
                camera.transform.position.Z += 1* timer.getDeltaTime();
            });


            KBEvent.getInstance(Key.Escape).addKeyDown(() =>
            {
                window.getWindow().Exit();
            });

            MBEvent.getInstance(MouseButton.Left).addButtonPress(() =>
            {
                box.transform.scale.X -= 0.1f * timer.getDeltaTime();
            });
            MBEvent.getInstance(MouseButton.Right).addButtonPress(() =>
            {
                box.transform.scale.X += 0.1f * timer.getDeltaTime();
            });

            MWheelEvent.getInstance().addScroll((y) =>
            {
                camera.transform.position.Z += y * timer.getDeltaTime();
            });
            MMoveEvent.getInstance().addMove((x, y) =>
            {
                camera.transform.rotation.Y += x * timer.getDeltaTime()*10;
                camera.transform.rotation.X += y * timer.getDeltaTime()*10;
            });

            //Window's onLoad event, OpenGL dependent code has to be here
            window.Load(() =>
            {
                DefaultMat material = new DefaultMat(); //Creating material component
                material.setCullingEnabled(false);       //Backface culling enabled
                material.setHasTransparency(true);
                material.setColor(new Vector4(0, 1, 0, 0.3f));      //Setting the materials color
                Renderer m = new Renderer(Primitives.Cube(), material);     //Creating renderer component -> Parameters Primitives.PRIMITIVE_NAME, material
                box.addComponent(m);                    //Assing renderer to the gameobject


                DefaultMat material2 = new DefaultMat(); //Creating material component
                material2.setCullingEnabled(false);       //Backface culling enabled
                material2.setHasTransparency(true);
                material2.setColor(new Vector4(1, 0, 0, 0.3f));      //Setting the materials color
                Renderer m2 = new Renderer(Primitives.Cube(), material2);     //Creating renderer component -> Parameters Primitives.PRIMITIVE_NAME, material
                box2.addComponent(m2);

                DefaultMat material3 = new DefaultMat(); //Creating material component
                material3.setCullingEnabled(false);       //Backface culling enabled
                material3.setHasTransparency(true);
                material3.setColor(new Vector4(0, 0, 1, 0.3f));      //Setting the materials color
                Renderer m3 = new Renderer(Primitives.Cube(), material3);     //Creating renderer component -> Parameters Primitives.PRIMITIVE_NAME, material
                box3.addComponent(m3);


            });

            //Starting the rendering at 60 Update/s with 60 FPS
            window.Start(60,60);
        }
    }
}
