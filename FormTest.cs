using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.components.physics;
using cube_thing.renderEngine.components.renderer;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.render;
using cube_thing.renderEngine.render.model;
using cube_thing.renderEngine.render.shader.material;
using cube_thing.renderEngine.tools.utils;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cube_thing
{
    public partial class FormTest : Form
    {
        private Transform cameraMove = null;
        public FormTest()
        {
            InitializeComponent();

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += (s, e) =>
            {
                fpscounter.Text = InfoContainer.getInstance().getFPS()+" fps";
            };
            t.Start();

        }

        private void FormTest_Load(object sender, EventArgs e)
        {
                new DisplayManager(() =>
                {
                    GameObject camera = new GameObject("camera");
                    AbstractCamera cam = new AbstractCamera();
                    cam.setMain();
                    cam.setBackgroundColor(new OpenTK.Vector3(1, 1, 1));
                    camera.addComponent(cam);
                    World.getInstance().assingGameObject(camera);
                    camera.transform.position.Z = 10;
                    cameraMove = camera.transform;
                    GameObject box = new GameObject("Box");
                    DefaultMat material = new DefaultMat();
                    material.setCullingEnabled(true);
                    Renderer m = new Renderer(Primitives.Cube(), material);

                    box.addComponent(m);

                    World.getInstance().assingGameObject(box);

                }, canvasHolder);
        }
       
        private void Move_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Text)
            {
                case "F":
                    cameraMove.position.Z++;
                    break;
                case "B":
                    cameraMove.position.Z--;
                    break;
                case "L":
                    cameraMove.position.X--;
                    break;
                case "R":
                    cameraMove.position.X++;
                    break;
            }
        }

 
    }
}
