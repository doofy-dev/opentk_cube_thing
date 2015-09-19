using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class UniformMat3f : UniformVariable
    {
        private Matrix3 value = Matrix3.Zero;

        public UniformMat3f(String name):base(name){ }

        public override void loadData()
        {
            glUniformMatrix3(location, false, value);
        }

        public override void set(Matrix3 value)
        {
            this.value = value;
        }
    }
}
