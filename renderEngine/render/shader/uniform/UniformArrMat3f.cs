using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class UniformArrMat3f : UniformVariable
    {
        private Matrix3[] value;

        public UniformArrMat3f(String name, int arrayLength):base(name,arrayLength){
            this.value = new Matrix3[arrayLength];
        }

        public override void loadData()
        {
            for(int i=0;i<locations.Length;i++)
                glUniformMatrix3(locations[i], false, value[i]);
        }

        public override void set(Matrix3[] value)
        {
            this.value = value;
        }
    }
}
