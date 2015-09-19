using cube_thing.renderEngine.components.physics;
using cube_thing.renderEngine.core.renderer;
using System.Collections.Generic;

namespace cube_thing.renderEngine.core.entity
{
    public class World
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        private Transform transform;

        private static World instance = null;

        protected World()
        {
            transform = new Transform();
            transform.createTransformationMatrix();
        }

        public static World getInstance()
        {
            if (instance == null)
                instance = new World();
            return instance;
        }

        public void assingGameObject(GameObject instance)
        {
            gameObjects.Add(instance);
            MasterRenderer.getInstance().assignGameobject(instance);
        }

        public List<GameObject> getGameObjects()
        {
            return gameObjects;
        }

        public Transform getTransform()
        {
            return transform;
        }

        public void setTransform(Transform transform)
        {
            this.transform = transform;
        }
    }
}
