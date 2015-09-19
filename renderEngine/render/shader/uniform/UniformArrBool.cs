using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class UniformArrBool : UniformVariable
    {
        private bool[] value;

        public UniformArrBool(String name, int arrayLength):base(name,arrayLength){
            this.value = new bool[arrayLength];
        }

        public override void loadData()
        {
            for(int i=0;i<locations.Length;i++)
                glUniform1i(locations[i], (value[i]?1:0));
        }

        public override void set(bool[] value)
        {
            this.value = value;
        }
    }
}
