using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace renderEngine.render.shader
{
    public abstract class ShaderProgram
    {
        protected int programID;
        private ShaderSource[] shaderSources = null;

        public ShaderProgram(ShaderSource[] sources)
        {
            this.shaderSources = sources;
        }

        public void buildShader()
        {
            programID = glCreateProgram();

            foreach (ShaderSource source in shaderSources)
                glAttachShader(programID, source.getShaderID());

            bindAttributes();
            glLinkProgram(programID);
            glValidateProgram(programID);
            getAllUniformLocations();
        }

        protected abstract void bindAttributes();
        protected abstract void getAllUniformLocations();
        public abstract void loadUniformVariables();

        protected int getUniformLoaction(String uniformName)
        {
            return glGetUniformLocation(programID, uniformName);
        }

        protected void bindAttribute(int attribute, string variable)
        {
            glBindAttribLocation(programID, attribute, variable);
        }

        public void start() { glUseProgram(programID); }
        public void stop() { glUseProgram(0); }



    }
}
