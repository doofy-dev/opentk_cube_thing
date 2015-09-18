using System;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    class UniformArrVec2 : UniformVariable
    {
        private Vector2[] value;

        public UniformArrVec2(String name, int arrayLength):base(name, arrayLength){
            this.value = new Vector2[arrayLength];
        }

        public override void loadData()
        {
            for(int i=0;i<locations.Length;i++)
                glUniform2f(locations[i], value[i].X, value[i].Y);
        }

        public override void set(Vector2[] value)
        {
            this.value = value;
        }
    }
}
