using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.core.entity;
using cube_thing.renderEngine.render.model;
using OpenTK;
using System.Collections.Generic;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.core.renderer
{
    public class MasterRenderer
    {
        private Dictionary<Mesh, List<GameObject>> objects = new Dictionary<Mesh, List<GameObject>>();

        private Matrix4 projectionMatrix;

        private static MasterRenderer instance = null;
        protected MasterRenderer() { }
        public static MasterRenderer getInstance()
        {
            if (instance == null)
                instance = new MasterRenderer();
            return instance;
        }

        public void render()
        {
            renderScene(AbstractCamera.getMainCamera());
        }

        private void renderScene(AbstractCamera camera)
        {
            prepare(camera);
            this.projectionMatrix = camera.getProjectionMatrix();
            foreach (GameObject o in World.getInstance().getGameObjects())
            {
                gameObjectLoop(o, new Matrix4());
            }
        }

        private void gameObjectLoop(GameObject g, Matrix4 transformMatrix)
        {
            Matrix4 m = transformMatrix;

            if (g.getRenderer() != null)
            {
                m = m* renderInstance(g, transformMatrix);
            }
            for (int i = 0; i < g.getChildrens().Count; i++)
            {
                gameObjectLoop(g.getChildrens()[i], m);
            }

        }

        private Matrix4 renderInstance(GameObject o, Matrix4 transformMatrix)
        {
            glBindVertexArray(o.getRenderer().getMesh().getVao());
            o.getRenderer().getMaterial().start();
            o.getRenderer().getMaterial().getProjectionMatrix().set(projectionMatrix);

            Matrix4 m = o.getRenderer().prepareInstance(transformMatrix);
            o.getRenderer().getMesh().enableVAO();
            o.getRenderer().getMaterial().loadTextures();
            if (o.getRenderer().getMaterial().isCullingEnabled())
            {
                enableCulling();
            }
            glPolygonMode(GL_FRONT_AND_BACK, o.getRenderer().getRenderMode());
            glDrawElements(GL_TRIANGLES,
                    o.getRenderer().getMesh().getVertexCount(), GL_UNSIGNED_INT, 0);


            o.getRenderer().getMesh().disableVAO();
            glBindVertexArray(0);
            o.getRenderer().getMaterial().stop();
            disableCulling();
            return m;
        }

        public void assignGameobject(GameObject obj)
        {
            if (obj.getRenderer() == null) return;
            Mesh model = obj.getRenderer().getMesh();
            List<GameObject> batch = objects[model];
            if (batch != null)
            {
                batch.Add(obj);
            }
            else
            {
                List<GameObject> newBatch = new List<GameObject>();
                newBatch.Add(obj);
                objects.Add(model, newBatch);
            }
        }

        public void prepare(AbstractCamera c)
        {
            glEnable(GL_DEPTH_TEST);
            glDepthFunc(GL_LESS);
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            Vector3 color = c.getBackgroundColor();
            glClearColor(color.X, color.Y, color.Z, 1);
        }

        public void enableCulling()
        {
            glEnable(GL_BLEND);
            glEnable(GL_CULL_FACE);
            glCullFace(GL_BACK);
        }

        public void disableCulling()
        {
            glDisable(GL_CULL_FACE);
            glDisable(GL_BLEND);
        }
    }
}
