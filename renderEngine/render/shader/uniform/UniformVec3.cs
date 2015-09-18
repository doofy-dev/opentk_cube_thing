using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class UniformVec3 : UniformVariable
    {
        private Vector3 value = Vector3.Zero;

        public UniformVec3(String name):base(name){ }

        public override void loadData()
        {
            glUniform3f(location, value.X, value.Y, value.Z);
        }

        public override void set(Vector3 value)
        {
            this.value = value;
        }
    }
}
