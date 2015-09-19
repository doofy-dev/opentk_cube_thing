using cube_thing.renderEngine.core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace renderEngine.render.shader
{
    public class ShaderSource
    {
        private int shaderID;

        public ShaderSource(String path, int ShaderType)
        {
            this.shaderID = loadShader(path, ShaderType);
        }

        private int loadShader(String file, int type)
        {
            int shaderID;

            using (StreamReader sr = new StreamReader(Settings.getInstance().getShaderPath()+file))
            {
                string shader = sr.ReadToEnd();

                shaderID = glCreateShader(type);
                glShaderSource(shaderID, shader);
                glCompileShader(shaderID);
                if(glGetShader(shaderID,GL_COMPILE_STATUS) == GL_FALSE)
                {
                    Console.WriteLine(glGetShaderInfoLog(shaderID));
                    Console.WriteLine("The shader (" + file + ") has some errors!");
                    Environment.Exit(0);
                }  
            }
            return shaderID;
        }
        
        public int getShaderID() { return shaderID; }
        public void deleteShader()
        {
            glDeleteShader(shaderID);
        }
    }
}
