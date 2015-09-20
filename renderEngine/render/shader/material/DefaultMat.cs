using cube_thing.renderEngine.render.shader.uniform;
using OpenTK;
using renderEngine.render.shader;
using System;
using System.Collections.Generic;
using System.Text;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.material
{
    public class DefaultMat : Material
    {
        private UniformVec4 color;
        public DefaultMat() :base(new ShaderSource[]{
                new ShaderSource("default.vert", GL_VERTEX_SHADER),
                new ShaderSource("default.frag", GL_FRAGMENT_SHADER)
        }, new String[]{
                "position",
                "textureCoords",
                "normal"
        }, new UniformVariable[]{
            new UniformVec4("color")
        })
        {
            color = (UniformVec4)locations["color"];
        }

        public void setColor(Vector4 c)
        {
            color.set(c);
        }

    }
}
