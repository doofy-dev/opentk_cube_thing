using OpenTK;
using OpenTK.Graphics.OpenGL;
using static renderEngine.utils.OpenTKAsOpenGL;
using System;
using System.Collections.Generic;
using System.Text;

namespace cube_thing
{
    class Main : GameWindow
    {
        public Main() : base(800, 600)
        {
            Title = "Test";
        }

        //DATA Loading
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            glClearColor(0, 0, 0, 0);
        }

        //Redefine viewport on resize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            glViewPort(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;

            float fov = 1.0f;
            float near_plane = 1.0f;
            float far_plane = 1000.0f;
            Matrix4 perspective_matrix = Matrix4.CreatePerspectiveFieldOfView(fov, (float)aspect_ratio, near_plane, far_plane);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective_matrix);
        }

        //Logic
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        //Rendering
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0, 0, -5);

            GL.Color3(System.Drawing.Color.Red);

            glBegin(GL_QUADS);
            GL.Vertex2(1, 1);
            GL.Vertex2(-1, 1);
            GL.Vertex2(-1, -1);
            GL.Vertex2(1, -1);
            glEnd();
            SwapBuffers();
        }

       
    }
}
