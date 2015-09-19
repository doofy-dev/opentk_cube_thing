using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class UniformVec2 : UniformVariable
    {
        private Vector2 value = Vector2.Zero;

        public UniformVec2(String name):base(name){ }

        public override void loadData()
        {
            glUniform2f(location, value.X, value.Y);
        }

        public override void set(Vector2 value)
        {
            this.value = value;
        }
    }
}
