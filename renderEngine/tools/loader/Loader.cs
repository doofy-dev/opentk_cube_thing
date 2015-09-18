using cube_thing.renderEngine.render.model;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.tools.loader
{
    public class Loader
    {
        private static Loader instance = null;

        private List<int> vaos = new List<int>();      //Vertex Attribute object
        private List<int> vbos = new List<int>();      //Vertex Buffer object
        private List<int> textures = new List<int>();	//Texture ID

        protected Loader() { }
        public static Loader getInstance()
        {
            if (instance == null)
                instance = new Loader();
            return instance;
        }

        public Mesh loadToVAO(float[] positions, float[] textureCoords, int[] indices,
                          float[] normals)
        {
            int vaoID = createVAO();
            bindIndiceBuffer(indices);
            storeDataInAttributeList(0, 3, positions);
            storeDataInAttributeList(1, 2, textureCoords);
            storeDataInAttributeList(2, 3, normals);
            unbindVAO();
            Mesh m = new Mesh(vaoID, positions.Length);
            m.setEnableVAOArray(new int[] { 0, 1, 2 });
            return m;
        }

        public Mesh loadToVAO(float[] positions)
        {
            int vaoID = createVAO();
            storeDataInAttributeList(0, 2, positions);
            unbindVAO();
            Mesh m = new Mesh(vaoID, positions.Length);
            m.setEnableVAOArray(new int[] { 0 });
            return m;
        }
        public Mesh loadToVAO(float[] positions, float[] textureCoords)
        {
            int vaoID = createVAO();
            storeDataInAttributeList(0, 2, positions);
            storeDataInAttributeList(1, 2, textureCoords);
            unbindVAO();
            Mesh m = new Mesh(vaoID, positions.Length);
            m.setEnableVAOArray(new int[] { 0, 1 });
            return m;
        }

        public void cleanUp()
        {
            foreach (int vao in vaos)
                glDeleteVertexArrays(vao);
            foreach (int vbo in vbos)
                glDeleteBuffers(vbo);
            foreach (int texture in textures)
                glDeleteTextures(texture);
        }
        //@TODO: textureLoader

        private int createVAO()
        {
            int vaoID = glGenVertexArrays();
            vaos.Add(vaoID);
            glBindVertexArray(vaoID);
            return vaoID;
        }
        private void unbindVAO()
        {
            glBindVertexArray(0);
        }
        private void storeDataInAttributeList(int attributeNumber, int coordinateSize,
                                              float[] data)
        {
            int vboID = glGenBuffers();
            vbos.Add(vboID);
            glBindBuffer(GL_ARRAY_BUFFER, vboID);
            glBufferData(GL_ARRAY_BUFFER, data, GL_STATIC_DRAW);
            glVertexAttribPointer(attributeNumber, coordinateSize, GL_FLOAT,
                    false, 0, 0);
            glBindBuffer(GL_ARRAY_BUFFER, 0);
        }
        private void bindIndiceBuffer(int[] indices)
        {
            int vboID = glGenBuffers();
            vbos.Add(vboID);
            glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, vboID);
            glBufferData(GL_ELEMENT_ARRAY_BUFFER, indices,
                    GL_STATIC_DRAW);
        }
       

        #region Texture
        public int loadTexture(string image)
        {
            try
            {
                Bitmap file = new Bitmap(image);
                return loadTexture(file);
            }
            catch (FileNotFoundException e)
            {
                return -1;
            }
        }

        public int loadTexture(Bitmap image)
        {
            int texID = glGenTextures();

            glBindTexture(GL_TEXTURE_2D, texID);
            BitmapData data = image.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, data.Width, data.Height, 0,
                GL_BGRA, GL_UNSIGNED_BYTE, data.Scan0);
            image.UnlockBits(data);
            //MIPMAPPING
            glGenerateMipmap(GL_TEXTURE_2D);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
            glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_LOD_BIAS, -0.4f);

            return texID;
        }

        public int loadTexture(Vector3 color)
        {
            return loadTexture(new Vector4(color.X, color.Y, color.Z, 255));
        }
        public int loadTexture(Vector4 color)
        {
            Bitmap flag = new Bitmap(2, 2);
            for (int i = 0; i < 2; i++)
                for (j = 0; j < 2; j++)
                    flag.SetPixel(i, j, Color.FromArgb((int)color.W, (int)color.X, (int)color.Y, (int)color.Z));
            return loadTexture(flag);
        }
        
        #endregion

    }
}
