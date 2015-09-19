using cube_thing.renderEngine.core.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace cube_thing.renderEngine.components
{
    public abstract class Component
    {
        public GameObject gameObject;

        public virtual void update() { }

    }
}
