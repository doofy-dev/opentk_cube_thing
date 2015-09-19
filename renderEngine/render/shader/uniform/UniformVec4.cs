using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class UniformVec4 : UniformVariable
    {
        private Vector4 value = Vector4.Zero;

        public UniformVec4(String name):base(name){ }

        public override void loadData()
        {
            glUniform4f(location, value.X, value.Y, value.Z, value.W);
        }

        public override void set(Vector4 value)
        {
            this.value = value;
        }
    }
}
