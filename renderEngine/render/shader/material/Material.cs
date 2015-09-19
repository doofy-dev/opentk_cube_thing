using cube_thing.renderEngine.render.shader.uniform;
using renderEngine.render.shader;
using System;
using System.Collections.Generic;
using System.Text;

namespace cube_thing.renderEngine.render.shader.material
{
    public class Material : ShaderProgram
    {
        private bool cullingEnabled = true;
        private UniformMat4f projectionMatrix = new UniformMat4f("projectionMatrix");
        private UniformMat4f viewMatrix = new UniformMat4f("viewMatrix");
        private UniformMat4f transformationMatrix = new UniformMat4f("transformationMatrix");



        protected Dictionary<string, UniformVariable> locations = new Dictionary<string, UniformVariable>();
        private string[] attributes;

        public Material(ShaderSource[] shaderSources, string[] attributes, UniformVariable[] values) : base(shaderSources)
        {
            locations.Add("projectionMatrix", projectionMatrix);
            locations.Add("viewMatrix", viewMatrix);
            locations.Add("transformationMatrix", transformationMatrix);
            foreach (UniformVariable value in values)
            {
                locations.Add(value.getName(), value);
            }

            this.attributes = attributes;
            base.buildShader();
        }

        public void connectTextureUnits() { }
        public void loadTextures() { }

        public int getLocation(string uniformName)
        {
            if (locations.ContainsKey(uniformName))
            {
                return locations[uniformName].getLocation();
            }
            else
            {
                Console.WriteLine("Could not find the requested uniform: " + uniformName);
            }
            return -1;
        }

        protected override void getAllUniformLocations()
        {
            foreach (string key in locations.Keys)
            {
                locations[key].requestLocation(programID);
            }
        }

        protected override void bindAttributes()
        {
            for (int i = 0; i < attributes.Length; i++)
                base.bindAttribute(i, attributes[i]);
        }

        public UniformMat4f getProjectionMatrix()
        {
            return projectionMatrix;
        }


        public UniformMat4f getViewMatrix()
        {
            return viewMatrix;
        }


        public UniformMat4f getTransformationMatrix()
        {
            return transformationMatrix;
        }

        public bool isCullingEnabled()
        {
            return cullingEnabled;
        }

        public void setCullingEnabled(bool cullingEnabled)
        {
            this.cullingEnabled = cullingEnabled;
        }

        public override void loadUniformVariables()
        {
            foreach (string key in locations.Keys)
            {
                locations[key].loadData();
            }
        }
    }
}
