using System;
using System.Collections.Generic;
using System.Text;

namespace cube_thing.renderEngine.tools.utils
{
    public class InfoContainer
    {
        private int fpsNumber;
        private int fpsTemp;

        public int getFPS()
        {
            return fpsNumber;
        }

        public void incrementFPS()
        {
            fpsTemp++;
        }

        public void saveFPS()
        {
            fpsNumber = fpsTemp;
            fpsTemp = 0;
        }

        private static InfoContainer instance;
        protected InfoContainer()
        {
            fpsNumber = 0;
            fpsTemp = 0;
        }
        public static InfoContainer getInstance()
        {
            if (instance == null)
                instance = new InfoContainer();
            return instance;
        }
    }
}
