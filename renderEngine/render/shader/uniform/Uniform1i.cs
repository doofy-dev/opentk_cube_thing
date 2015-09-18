using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class Uniform1i : UniformVariable
    {
        private int value = 0;

        public Uniform1i(String name):base(name){}

        public override void loadData()
        {
            glUniform1i(location, value);
        }

        public override void set(int value)
        {
            this.value = value;
        }
    }
}
