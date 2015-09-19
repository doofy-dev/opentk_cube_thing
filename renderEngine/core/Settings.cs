using System;
using System.Collections.Generic;
using System.Text;

namespace cube_thing.renderEngine.core
{
    class Settings
    {
        private string resPath;
        private string shaderPath;
        private int[] currentWindowSize;
        private List<int[]> supportedResolutions;
        private bool fullScreen;
        private int fpsCap;
        private bool vsync;
        private string windowTitle;

        private static int OPENGL_MAJOR_VER = 3;
        private static int OPENGL_MINOR_VER = 2;

        private static Settings instance = null;
        protected Settings()
        {
            resPath = "res/";
            shaderPath = "res/shaders/";
            currentWindowSize = new int[] { 800, 600 };
            fullScreen = false;
            fpsCap = 200;
            vsync = false;
            windowTitle = "Cube thing";

        }


        public static Settings getInstance()
        {
            if (instance == null)
            {
                instance = new Settings();
            }
            return instance;
        }
        

        public string getShaderPath()
        {
            return shaderPath;
        }
        public List<int[]> getSupportedResolutions()
        {
            return supportedResolutions;
        }

        public void setSupportedResolutions(List<int[]> supportedResolutions)
        {
            this.supportedResolutions = supportedResolutions;
        }
        public void setShaderPath(string shaderPath)
        {
            this.shaderPath = shaderPath;
        }

        public string getResPath()
        {
            return resPath;
        }

        public void setResPath(string resPath)
        {
            this.resPath = resPath;
        }

        public int[] getCurrentWindowSize()
        {
            return currentWindowSize;
        }

        public void setCurrentWindowSize(int[] currentWindowSize)
        {
            this.currentWindowSize = currentWindowSize;
        }

        public bool isFullScreen()
        {
            return fullScreen;
        }

        public void setFullScreen(bool fullScreen)
        {
            this.fullScreen = fullScreen;
        }

        public int getFpsCap()
        {
            return fpsCap;
        }

        public void setFpsCap(int fpsCap)
        {
            this.fpsCap = fpsCap;
        }

        public bool isVsync()
        {
            return vsync;
        }

        public void setVsync(bool vsync)
        {
            this.vsync = vsync;
        }

        public string getWindowTitle()
        {
            return windowTitle;
        }

        public void setWindowTitle(string windowTitle)
        {
            this.windowTitle = windowTitle;
        }

       
    }
}
