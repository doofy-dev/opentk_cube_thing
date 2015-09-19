using cube_thing.renderEngine.components.physics;
using cube_thing.renderEngine.core;
using cube_thing.renderEngine.tools.utils;
using OpenTK;
using System;
using System.Collections.Generic;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.components.camera
{
    public class AbstractCamera : Component
    {
        private static AbstractCamera mainCamera = null;

        private static List<AbstractCamera> cameras = new List<AbstractCamera>();

        public Transform transform;

        private int displayWidth;
        private int displayHeight;

        private int renderLayer = 0;
        private float fieldOfView = 90;
        private float nearPlane = 0.1f;
        private float farPlane = 30000;
        private Matrix4 projectionMatrix;

        private Vector3 backgroundColor = new Vector3(0.2f, 0.2f, 0.5f);

        public void setRenderLayer(int renderLayer)
        {
            this.renderLayer = renderLayer;
        }

        public AbstractCamera()
        {
            this.displayWidth = Settings.getInstance().getCurrentWindowSize()[0];
            this.displayHeight = Settings.getInstance().getCurrentWindowSize()[1];
            this.transform = new Transform();
            AbstractCamera.cameras.Add(this);
            createProjetcionMatrix();
        }

        public int getDisplayWidth()
        {
            return displayWidth;
        }

        public int getDisplayHeight()
        {
            return displayHeight;
        }

        public void setDisplaySize(int widht, int height)
        {
            this.displayWidth = widht;
            this.displayHeight = height;
            createProjetcionMatrix();
        }

        public Matrix4 getViewMatrix()
        {

            Vector3 negativeCameraPos = new Vector3(-transform.getPosition().X, -transform.getPosition().Y,
                    -transform.getPosition().Z);

            Matrix4 translation = Matrix4.CreateTranslation(negativeCameraPos);
            Matrix4 rotX = Matrix4.CreateFromAxisAngle(Vector3.UnitX, (float)Maths.toRadians((double)transform.getRotation().X));
            Matrix4 rotY = Matrix4.CreateFromAxisAngle(Vector3.UnitY, (float)Maths.toRadians((double)transform.getRotation().Y));
            Matrix4 rotZ = Matrix4.CreateFromAxisAngle(Vector3.UnitZ, (float)Maths.toRadians((double)transform.getRotation().Z));
            
            return rotX*rotY*rotZ* translation;
        }

        public void createProjetcionMatrix()
        {
            float aspectRatio = (float)displayWidth / (float)displayHeight;
            float y_scale = (float)((1f / Math.Tan((float)Maths.toRadians(fieldOfView / 2f))) * aspectRatio);
            float x_scale = y_scale / aspectRatio;
            float frustum_length = farPlane - nearPlane;

            projectionMatrix = new Matrix4();
            projectionMatrix.M11 = x_scale;
            projectionMatrix.M22 = y_scale;
            projectionMatrix.M33 = -((farPlane + nearPlane) / frustum_length);
            projectionMatrix.M34 = -1;
            projectionMatrix.M43 = -((2 * farPlane * nearPlane) / frustum_length);
            projectionMatrix.M44 = 0;

        }

        public static void enableCulling()
        {
            glEnable(GL_BLEND);
            glEnable(GL_CULL_FACE);
            glCullFace(GL_BACK);
        }

        public static void disableCulling()
        {
            glDisable(GL_CULL_FACE);
            glDisable(GL_BLEND);
        }

        public void setMain()
        {
            mainCamera = this;
        }

        public static AbstractCamera getMainCamera()
        {
            if (mainCamera == null)
            {
                Console.Error.WriteLine("No main camera attached!");
                System.Environment.Exit(0);
            }
            return mainCamera;
        }

        public static List<AbstractCamera> getCameras()
        {
            return cameras;
        }

        public Matrix4 getProjectionMatrix()
        {
            return projectionMatrix;
        }

        public Vector3 getBackgroundColor()
        {
            return backgroundColor;
        }

        public void setBackgroundColor(Vector3 backgroundColor)
        {
            this.backgroundColor = backgroundColor;
        }
    }
}
