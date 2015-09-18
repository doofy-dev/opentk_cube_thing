using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class UniformArrMat4f : UniformVariable
    {
        private Matrix4[] value;

        public UniformArrMat4f(String name, int arrayLength):base(name, arrayLength){
            this.value = new Matrix4[arrayLength];
        }

        public override void loadData()
        {
            for(int i=0;i<locations.Length;i++)
                glUniformMatrix4(locations[i], false, value[i]);
        }

        public override void set(Matrix4[] value)
        {
            this.value = value;
        }
    }
}
