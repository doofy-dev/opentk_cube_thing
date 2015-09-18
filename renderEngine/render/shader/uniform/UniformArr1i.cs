using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class UniformArr1i : UniformVariable
    {
        private int[] value;

        public UniformArr1i(String name, int arrayLength):base(name,arrayLength){
            this.value = new int[arrayLength];
        }

        public override void loadData()
        {
            for(int i=0;i< locations.Length;i++)
                glUniform1i(locations[i], value[i]);
        }

        public override void set(int[] value)
        {
            this.value = value;
        }
    }
}
