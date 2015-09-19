using System;
using OpenTK;
using cube_thing.renderEngine.core.entity;
using System.Collections.Generic;
using cube_thing.renderEngine.tools.utils;

namespace cube_thing.renderEngine.components.physics
{
    public class Transform : Component
    {
        public Vector3 position;
        public Vector3 scale;
        public Vector3 rotation;

        private Vector3 xVector = new Vector3(1, 0, 0);
        private Vector3 yVector = new Vector3(0, 1, 0);
        private Vector3 zVector = new Vector3(0, 0, 1);

        private Matrix4 transformationMatrix;

        public GameObject parent = null;
        private Dictionary<string, GameObject> childNodes;
        
        public Transform() : this(new Vector3(0,0,0), new Vector3(1,1,1), new Vector3(0,0,0)){}

        public Transform(Vector3 position, Vector3 scale, Vector3 rotation)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
            this.childNodes = new Dictionary<string, GameObject>();
        }

        public void addChild(GameObject g)
        {
            g.transform.parent = this.gameObject;
            if (childNodes.ContainsKey(g.name))
            {
                childNodes[g.name] = g;
            }
            childNodes.Add(g.name, g);
        }

        public GameObject getChild(string name)
        {
            if (childNodes.ContainsKey(name))
                return childNodes[name];
            Console.WriteLine("The requested child: '" + name + "' not found in '" + this.gameObject.name + "'!");
            return null;
        }

        public List<GameObject> getAllChild()
        {
            List<GameObject> g = new List<GameObject>();
            foreach (string key in childNodes.Keys)
                g.Add(childNodes[key]);
            return g;
        }


        public override void update()
        {

        }
        public void createTransformationMatrix()
        {
            Matrix4 translation = Matrix4.CreateTranslation(position);
            Matrix4 rotX = Matrix4.CreateFromAxisAngle(Vector3.UnitX, (float)Maths.toRadians((double)rotation.X));
            Matrix4 rotY = Matrix4.CreateFromAxisAngle(Vector3.UnitY, (float)Maths.toRadians((double)rotation.Y));
            Matrix4 rotZ = Matrix4.CreateFromAxisAngle(Vector3.UnitZ, (float)Maths.toRadians((double)rotation.Z));
            Matrix4 scaleMat = Matrix4.CreateScale(scale.X, scale.Y, scale.Z);

            transformationMatrix = translation*rotX*rotY*rotZ*scaleMat;
        }

        public Matrix4 getTransformationMatrix()
        {
            return transformationMatrix;
        }

        public Vector3 getPosition()
        {
            return position;
        }

        public Vector3 getRotation()
        {
            return rotation;
        }

        public Vector3 getScale()
        {
            return scale;
        }

        public void setPosition(Vector3 position)
        {
            this.position = position;
        }

        public void setRotation(Vector3 rotation)
        {
            this.rotation = rotation;
        }

        public void setScale(Vector3 scale)
        {
            this.scale = scale;
        }
    }
}
