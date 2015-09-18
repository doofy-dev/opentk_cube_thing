using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class Uniform1f : UniformVariable
    {
        private float value = 0;

        public Uniform1f(String name):base(name){ }

        public override void loadData()
        {
            glUniform1f(location, value);
        }

        public override void set(float value)
        {
            this.value = value;
        }
    }
}
