using cube_thing.renderEngine.tools.loader;
using System;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.model
{
    public class Mesh
    {
        private int vao;
        private int vertexCount;

        private float[] verticles = null;
        private float[] normals = null;
        private float[] textureCoords = null;
        private float[] vertexColors = null;

        private int[] enableVAOArray = null;
        private int[] indices;
        private bool useVertexColor = false;

        public Mesh(int vao, int vertexCount)
        {
            this.vao = vao;
            this.vertexCount = vertexCount;
        }

        //Just the model
        public Mesh(float[] verticles)
        {
            this.verticles = verticles;
            this.vertexCount = verticles.Length;
            Mesh m = Loader.getInstance().loadToVAO(verticles);
            vao = m.getVao();
            vertexCount = m.getVertexCount();
            enableVAOArray = m.getEnableVAOArray();
        }
        //model and textureCoords
        public Mesh(float[] verticles, float[] textureCoords)
        {
            this.verticles = verticles;
            this.textureCoords = textureCoords;
            this.vertexCount = verticles.Length;
            Mesh m = Loader.getInstance().loadToVAO(verticles, textureCoords);
            vao = m.getVao();
            vertexCount = m.getVertexCount();
            enableVAOArray = m.getEnableVAOArray();
        }

        //Textured Mesh
        public Mesh(float[] verticles, int[] indices, float[] normals, float[] textureCoords)
        {
            this.verticles = verticles;
            this.normals = normals;
            this.indices = indices;
            this.textureCoords = textureCoords;
            this.vertexCount = verticles.Length;

            Mesh m = Loader.getInstance().loadToVAO(verticles, textureCoords, indices, normals);
            vao = m.getVao();
            vertexCount = m.getVertexCount();
            enableVAOArray = m.getEnableVAOArray();
        }

        public bool isUseVertexColor()
        {
            return useVertexColor;
        }

        public int getVao()
        {
            return vao;
        }

        public void setVao(int vao)
        {
            this.vao = vao;
        }

        public int getVertexCount()
        {
            return vertexCount;
        }

        public void setVertexCount(int vertexCount)
        {
            this.vertexCount = vertexCount;
        }

        public float[] getVerticles()
        {
            return verticles;
        }

        public void setVerticles(float[] verticles)
        {
            this.verticles = verticles;
        }

        public float[] getNormals()
        {
            return normals;
        }

        public void setNormals(float[] normals)
        {
            this.normals = normals;
        }

        public float[] getTextureCoords()
        {
            return textureCoords;
        }

        public void setTextureCoords(float[] textureCoords)
        {
            this.textureCoords = textureCoords;
        }

        public float[] getVertexColors()
        {
            return vertexColors;
        }

        public void setVertexColors(float[] vertexColors)
        {
            this.vertexColors = vertexColors;
        }

        public int[] getIndices()
        {
            return indices;
        }

        public void setIndices(int[] indices)
        {
            this.indices = indices;
        }

        public void setEnableVAOArray(int[] enableVAOArray)
        {
            this.enableVAOArray = enableVAOArray;
        }
        public int[] getEnableVAOArray()
        {
            return this.enableVAOArray;
        }

        public void enableVAO()
        {
            if (enableVAOArray != null)
                for (int i = 0; i < enableVAOArray.Length; i++)
                {
                    glEnableVertexAttribArray(enableVAOArray[i]);
                }
        }
        public void disableVAO()
        {
            if (enableVAOArray != null)
                for (int i = 0; i < enableVAOArray.Length; i++)
                    glDisableVertexAttribArray(enableVAOArray[i]);
        }
    }
}
