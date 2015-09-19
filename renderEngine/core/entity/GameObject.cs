using cube_thing.renderEngine.components;
using cube_thing.renderEngine.components.camera;
using cube_thing.renderEngine.components.physics;
using cube_thing.renderEngine.components.renderer;
using System;
using System.Collections.Generic;
using System.Text;

namespace cube_thing.renderEngine.core.entity
{
    public class GameObject
    {
        private List<GameObject> childrens = new List<GameObject>();
        private int listID;

        private Dictionary<Type, Component> componentMap;

        private Renderer renderer = null;
        public Transform transform;
        public string name = "";
        public int layer = 0;
        private bool visible = true;
        
        public GameObject(string name, int layer=0)
        {
            this.transform = new Transform();
            this.transform.createTransformationMatrix();
            componentMap = new Dictionary<Type, Component>();
            this.transform.gameObject = this;
            this.name = name;
            this.layer = layer;
            this.listID = childrens.Count;
        }

        public void addComponent(Component c)
        {
            c.gameObject = this;
            if (c is Renderer) {
                renderer = (Renderer)c;
            }
		else if (c is AbstractCamera){
                ((AbstractCamera)c).transform.rotation = this.transform.rotation;
                ((AbstractCamera)c).transform.position = this.transform.position;
            }
		else
		componentMap.Add(c.GetType(), c);
        }
        public Component getComponent(Type t)
        {
            if (componentMap.ContainsKey(t))
            {
                return componentMap[t];
            }
            return null;
        }

        public List<Component> getComponent()
        {
            List<Component> components = new List<Component>();
            foreach (Type c in componentMap.Keys)
            {
                components.Add(componentMap[c]);
            }
            return components;
        }

        public bool isVisible()
        {
            return visible;
        }

        public List<GameObject> getChildrens()
        {
            return childrens;
        }

        public void setChildrens(List<GameObject> childrens)
        {
            this.childrens = childrens;
        }

        public void addChild(GameObject g)
        {
            g.transform.parent = this;
            childrens.Add(g);
        }

        public void setVisible(bool visible)
        {
            this.visible = visible;
        }

        public Renderer getRenderer()
        {
            return renderer;
        }

        public void setRenderer(Renderer renderer)
        {
            this.renderer = renderer;
        }
    }
}
