using System;
using System.Collections.Generic;
using System.Text;

namespace cube_thing.renderEngine.tools.utils
{
    public class Timer
    {
        private float deltaTime;
        private float lastFrameTime;
        private float lastFPS;
        private bool newSecond;

        public bool isNewSecond()
        {
            return newSecond;
        }

        public void setNewSecond(bool newSecond)
        {
            this.newSecond = newSecond;
        }

        public float getLastFPS()
        {
            return lastFPS;
        }

        public void setLastFPS(float lastFPS)
        {
            this.lastFPS = lastFPS;
        }

        private static Timer instance;
        protected Timer()
        {
            lastFPS = 0;
            deltaTime = 0;
            lastFrameTime = 0;
            newSecond = false;
        }

        public static Timer getInstance()
        {
            if (instance == null)
                instance = new Timer();

            return instance;
        }

        public float getDeltaTime()
        {
            return deltaTime;
        }

        public void setDeltaTime(float deltaTime)
        {
            this.deltaTime = deltaTime;
        }

        public float getLastFrameTime()
        {
            return lastFrameTime;
        }

        public void setLastFrameTime(float lastFrameTime)
        {
            this.lastFrameTime = lastFrameTime;
        }
        public static long getCurrentTime()
        {
            return DateTime.Now.Ticks *1000 / TimeSpan.TicksPerSecond;
        }
    }
}
