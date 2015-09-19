using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class UniformArrVec4 : UniformVariable
    {
        private Vector4[] value;

        public UniformArrVec4(String name, int arrayLength):base(name,arrayLength)
        {
            this.value = new Vector4[arrayLength];
        }

        public override void loadData()
        {
            for(int i=0;i<locations.Length;i++)
                glUniform4f(locations[i], value[i].X, value[i].Y, value[i].Z, value[i].W);
        }

        public override void set(Vector4[] value)
        {
            this.value = value;
        }
    }
}
