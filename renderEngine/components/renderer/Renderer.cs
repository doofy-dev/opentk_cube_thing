using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.render.model;
using cube_thing.renderEngine.render.shader.material;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.components.renderer
{
    public class Renderer : Component
    {
        private Mesh mesh;
        protected Material material;
        private PolygonMode renderMode = GL_FILL;

        public Renderer(Mesh mesh, Material material)
        {
            this.material = material;
            this.mesh = mesh;
        }

        public Mesh getMesh()
        {
            return mesh;
        }

        public void setMesh(Mesh mesh)
        {
            this.mesh = mesh;
        }

        public Material getMaterial()
        {
            return material;
        }

        public Matrix4 prepareInstance(Matrix4 transformMatrix)
        {
            gameObject.transform.createTransformationMatrix();

            Matrix4 newTransform = new Matrix4();
            if (transformMatrix != null)
            {
                newTransform = transformMatrix*gameObject.transform.getTransformationMatrix();
            }
            else
            {
                newTransform = gameObject.transform.getTransformationMatrix()*1;
            }
            material.getTransformationMatrix().set(newTransform);
            material.getViewMatrix().set(AbstractCamera.getMainCamera().getViewMatrix());
            material.loadUniformVariables();
            return newTransform;
        }
        public void setRenderMode(PolygonMode mode)
        {
            renderMode = mode;
        }

        public PolygonMode getRenderMode()
        {
            return renderMode;
        }
    }
}
