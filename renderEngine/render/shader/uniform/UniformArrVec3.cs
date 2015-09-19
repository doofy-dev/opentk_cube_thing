using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public class UniformArrVec3 : UniformVariable
    {
        private Vector3[] value;

        public UniformArrVec3(String name, int arrayLength):base(name, arrayLength)
        {
            this.value = new Vector3[arrayLength];
        }

        public override void loadData()
        {
            for (int i = 0; i < locations.Length;i++)
                glUniform3f(locations[i], value[i].X, value[i].Y, value[i].Z);
        }

        public override void set(Vector3[] value)
        {
            this.value = value;
        }
    }
}
