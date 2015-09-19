using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace renderEngine.utils
{
    class OpenTKAsOpenGL
    {

        #region ClearBufferMasks
        public static ClearBufferMask GL_COLOR_BUFFER_BIT = ClearBufferMask.ColorBufferBit;
        public static ClearBufferMask GL_DEPTH_BUFFER_BIT = ClearBufferMask.DepthBufferBit;
        #endregion

        public static byte GL_FALSE = 0;
        public static byte GL_TRUE = 1;
        public static int GL_FRAGMENT_SHADER = 1;
        public static int GL_VERTEX_SHADER = 0;

        #region enableCap
        public static EnableCap GL_BLEND = EnableCap.Blend;
        public static EnableCap GL_CULL_FACE = EnableCap.CullFace; 
        public static EnableCap GL_DEPTH_TEST = EnableCap.DepthTest;
        #endregion

        public static CullFaceMode GL_BACK = CullFaceMode.Back;
        public static CullFaceMode GL_FRONT = CullFaceMode.Front;

        public static DepthFunction GL_LESS = DepthFunction.Less;

        public static ShaderParameter GL_COMPILE_STATUS = ShaderParameter.CompileStatus;
        

        #region Buffertypes
        public static BufferTarget GL_ELEMENT_ARRAY_BUFFER = BufferTarget.ElementArrayBuffer;
        public static BufferTarget GL_ARRAY_BUFFER = BufferTarget.ArrayBuffer;

        public static BufferUsageHint GL_STATIC_DRAW = BufferUsageHint.StaticDraw;
        public static BufferUsageHint GL_DYNAMIC_DRAW = BufferUsageHint.DynamicDraw;

        public static VertexAttribPointerType GL_FLOAT = VertexAttribPointerType.Float;
        #endregion

        public static MaterialFace GL_FRONT_AND_BACK = MaterialFace.FrontAndBack;

        public static PolygonMode GL_LINE = PolygonMode.Line;
        public static PolygonMode GL_FILL= PolygonMode.Fill;

        public static DrawElementsType GL_UNSIGNED_INT = DrawElementsType.UnsignedInt;

        #region Texture
        public static TextureTarget GL_TEXTURE_2D = TextureTarget.Texture2D;
        public static PixelInternalFormat GL_RGBA = PixelInternalFormat.Rgba;
        public static PixelFormat GL_BGRA = PixelFormat.Bgra;
        public static PixelType GL_UNSIGNED_BYTE = PixelType.UnsignedByte;
        public static TextureParameterName GL_TEXTURE_MIN_FILTER = TextureParameterName.TextureMinFilter;
        public static TextureParameterName GL_TEXTURE_LOD_BIAS = TextureParameterName.TextureLodBias;
        public static TextureMinFilter GL_LINEAR_MIPMAP_LINEAR = TextureMinFilter.LinearMipmapLinear;
        #endregion

        #region Beginmodes
        public static BeginMode GL_QUADS = BeginMode.Quads;
        public static BeginMode GL_TRIANGLES = BeginMode.Triangles;
        public static BeginMode GL_LINES = BeginMode.Lines;
        #endregion

        #region Methods
        public static void glClearColor(float r, float g, float b, float a)
        {
            GL.ClearColor(r, g, b, a);
        }
        public static void glViewPort(int x, int y, int width, int height)
        {
            GL.Viewport(x, y, width, height);
        }
        public static void glClear(ClearBufferMask mask)
        {
            GL.Clear(mask);
        }
        public static void glBegin(BeginMode mode)
        {
            GL.Begin(mode);
        }
        public static void glEnd()
        {
            GL.End();
        }
        public static void glEnableVertexAttribArray(int attrib)
        {
            GL.EnableVertexAttribArray(attrib);
        }
        public static void glDisableVertexAttribArray(int attrib)
        {
            GL.DisableVertexAttribArray(attrib);
        }
        public static void glDeleteVertexArrays(int id)
        {
            GL.DeleteVertexArray(id);
        }
        public static void glDeleteTextures(int id)
        {
            GL.DeleteTexture(id);
        }
        public static int glGenVertexArrays()
        {
            return GL.GenVertexArray();
        }
        public static void glBindVertexArray(int id)
        {
            GL.BindVertexArray(id);
        }
        public static int glGenBuffers()
        {
            int buffer;
            GL.GenBuffers(1, out buffer);
            return buffer;
        }
        public static void glDeleteBuffers(int id)
        {
            GL.DeleteBuffers(1,ref id);
        }
        public static void glBindBuffer(BufferTarget buffertype, int id)
        {
            GL.BindBuffer(buffertype, id);
        }
        public static void glBufferData(BufferTarget target, float[] buffer, BufferUsageHint hint)
        {
            GL.BufferData(target, (IntPtr)(buffer.Length * sizeof(float)), buffer, hint);
        }
        public static void glBufferData(BufferTarget target, int[] buffer, BufferUsageHint hint)
        {
            GL.BufferData(target, (IntPtr)(buffer.Length * sizeof(int)), buffer, hint);
        }
        public static void glVertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized, int stride, int offset)
        {
            GL.VertexAttribPointer(index, size, type, normalized, stride, offset);
        }
        public static void glEnable(EnableCap enable)
        {
            GL.Enable(enable);
        }
        public static void glDisable(EnableCap enable)
        {
            GL.Enable(enable);
        }
        public static void glCullFace(CullFaceMode mode)
        {
            GL.CullFace(mode);
        }
        public static void glPolygonMode(MaterialFace face, PolygonMode mode)
        {
            GL.PolygonMode(face, mode);
        }
        public static void glDrawElements(BeginMode mode, int count, DrawElementsType type, int indices)
        {
            GL.DrawElements(mode, count, type, indices);
        }
        public static void glDepthFunc(DepthFunction fn)
        {
            GL.DepthFunc(fn);
        }
        public static void glViewport(int x, int y, int width, int height)
        { 
            GL.Viewport(x,y,width,height);
        }
        #endregion

        #region Texture
        public static void glBindTexture(TextureTarget target, int texture)
        {
            GL.BindTexture(target, texture);
        }
        public static int glGenTextures()
        {
            return GL.GenTexture();
        }
        public static void glTexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat pixelFormat, PixelType pixelType, IntPtr pixels)
        {
            GL.TexImage2D(target, level, internalFormat, width, height, border, pixelFormat, pixelType, pixels);
        }
        public static void glGenerateMipmap(TextureTarget target)
        {
            switch (target)
            {
                case TextureTarget.Texture2D:
                    GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                    break;
            }
        }
        public static void glTexParameteri(TextureTarget target, TextureParameterName paramName, TextureMinFilter filer)
        {
            GL.TexParameter(target, paramName, (int)filer);
        }
        public static void glTexParameterf(TextureTarget target, TextureParameterName paramName, float filer)
        {
            GL.TexParameter(target, paramName, filer);
        }
        #endregion

        #region Shader specific
        public static int glCreateShader(int type)
        {
            ShaderType[] shaderTypes = new ShaderType[]
            {
               ShaderType.VertexShader, ShaderType.FragmentShader, 
            };

            Console.WriteLine(shaderTypes[type]);
            return GL.CreateShader(shaderTypes[type]);
           
        }
        public static void glShaderSource(int shaderID, String shaderSource)
        {
            GL.ShaderSource(shaderID, shaderSource);
        }
        public static void glCompileShader(int shaderID)
        {
            GL.CompileShader(shaderID);
        }
        public static int glGetShader(int shaderID, ShaderParameter param)
        {
            int ret;
            GL.GetShader(shaderID, param, out @ret);
            return ret;
        }
        public static string glGetShaderInfoLog(int shaderID)
        {
            string info;
            GL.GetShaderInfoLog(shaderID, out info);
            return info;
        }
        public static void glDeleteShader(int shaderID)
        {
            GL.DeleteShader(shaderID);
        }
        public static int glCreateProgram()
        {
            return GL.CreateProgram();
        }
        public static void glAttachShader(int programID, int shaderID)
        {
            GL.AttachShader(programID, shaderID);
        }
        public static int glGetUniformLocation(int programID, string uniformName)
        {
            return GL.GetUniformLocation(programID, uniformName);
        }
        public static void glUseProgram(int programID)
        {
            GL.UseProgram(programID);
        }
        public static void glLinkProgram(int programID)
        {
            GL.LinkProgram(programID);
        }
        public static void glValidateProgram(int programID)
        {
            GL.ValidateProgram(programID);
        }
        public static void glBindAttribLocation(int programID, int attribute, string variable)
        {
            GL.BindAttribLocation(programID, attribute, variable);
        }

        public static void glUniform1f(int location, float value)
        {
            GL.Uniform1(location, value);
        }
        public static void glUniform1i(int location, int value)
        {
            GL.Uniform1(location, value);
        }
        public static void glUniform2f(int location, float X, float Y)
        {
            GL.Uniform2(location, X, Y);
        }
        public static void glUniform3f(int location, float X, float Y, float Z)
        {
            GL.Uniform3(location, X, Y, Z);
        }
        public static void glUniform4f(int location, float X, float Y, float Z, float W)
        {
            GL.Uniform4(location, X, Y, Z, W);
        }

        public static void glUniformMatrix3(int location, bool transpose, Matrix3 value)
        {
            GL.UniformMatrix3(location, transpose, ref value);
        }
        public static void glUniformMatrix4(int location, bool transpose, Matrix4 value)
        {
            GL.UniformMatrix4(location, transpose, ref value);
        }
        #endregion
    }
}
