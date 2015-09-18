using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class UniformBool : UniformVariable
    {
        private bool value = false;

        public UniformBool(String name):base(name){ }

        public override void loadData()
        {
            glUniform1i(location, (value?1:0));
        }

        public override void set(bool value)
        {
            this.value = value;
        }
    }
}
