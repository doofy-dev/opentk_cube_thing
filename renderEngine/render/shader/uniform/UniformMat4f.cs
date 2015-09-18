using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class UniformMat4f : UniformVariable
    {
        private Matrix4 value = Matrix4.Zero;

        public UniformMat4f(String name):base(name){ }

        public override void loadData()
        {
            glUniformMatrix4(location, false, value);
        }

        public override void set(Matrix4 value)
        {
            this.value = value;
        }
    }
}
