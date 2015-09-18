using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class UniformArr1f : UniformVariable
    {
        private float[] value;

        public UniformArr1f(String name, int arrayLength):base(name, arrayLength){
            this.value = new float[arrayLength];
        }

        public override void loadData()
        {
            for(int i=0;i< locations.Length;i++)
                glUniform1f(locations[i], value[i]);
        }

        public override void set(float[] value)
        {
            this.value = value;
        }
    }
}
