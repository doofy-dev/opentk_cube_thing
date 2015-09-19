using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using static renderEngine.utils.OpenTKAsOpenGL;

namespace cube_thing.renderEngine.render.shader.uniform
{
    public abstract class UniformVariable
    {
        public bool isArray;
        protected int[] locations;
        protected int location;
        protected string name;

        protected UniformVariable() { isArray = false; }

        protected UniformVariable(string name)
        {
            this.name = name;
            isArray = false;
        }

        protected UniformVariable(String name, int arrayLength)
        {
            this.name = name;
            isArray = true;
            locations = new int[arrayLength];
        }

        public abstract void loadData();

        public void requestLocation(int programID)
        {
            if (!isArray)
            {
                location = glGetUniformLocation(programID, name);
            }
            else
            {
                for (int i = 0; i < locations.Length; i++)
                    locations[i] = glGetUniformLocation(programID, name + "[" + i + "]");
            }
        }

        public void setLocation(int location) { this.location = location; }
        public void setLocation(int location, int ID) { this.locations[ID] = location; }

        public string getName() { return name; }

        public int getLocation() { return location; }
        public int[] getLocations() { return locations; }

        public virtual void set(int value)
        {
            Console.WriteLine("Integer type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(float value)
        {
            Console.WriteLine("Float type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Vector2 value)
        {
            Console.WriteLine("Vector2 type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Vector3 value)
        {
            Console.WriteLine("Vector3 type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Vector4 value)
        {
            Console.WriteLine("Vector4 type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(bool value)
        {
            Console.WriteLine("Boolean type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Matrix3 value)
        {
            Console.WriteLine("Matrix3 type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Matrix4 value)
        {
            Console.WriteLine("Matrix4 type is not supported by the " + name + " uniform variable!");
        }

        public virtual void set(int[] value)
        {
            Console.WriteLine("Integer[] type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(float[] value)
        {
            Console.WriteLine("Float[] type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Vector2[] value)
        {
            Console.WriteLine("Vector2[] type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Vector3[] value)
        {
            Console.WriteLine("Vector3[] type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Vector4[] value)
        {
            Console.WriteLine("Vector4[] type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(bool[] value)
        {
            Console.WriteLine("Boolean[] type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Matrix3[] value)
        {
            Console.WriteLine("Matrix3[] type is not supported by the " + name + " uniform variable!");
        }
        public virtual void set(Matrix4[] value)
        {
            Console.WriteLine("Matrix4[] type is not supported by the " + name + " uniform variable!");
        }
    }
}
