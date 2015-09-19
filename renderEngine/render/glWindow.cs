using cube_thing.renderEngine.core;
using OpenTK;
using System;

namespace cube_thing.renderEngine.render
{
    class glWindow : GameWindow
    {
        Action<EventArgs> load;
        Action<EventArgs> resize;
        Action<FrameEventArgs> update;
        Action<FrameEventArgs> render;

        public glWindow(Action<EventArgs> load, Action<EventArgs> resize, Action<FrameEventArgs> update, Action<FrameEventArgs> render)
        {
            Title = Settings.getInstance().getWindowTitle();
            Width = Settings.getInstance().getCurrentWindowSize()[0];
            Height = Settings.getInstance().getCurrentWindowSize()[1];
            VSync = (Settings.getInstance().isVsync()? VSyncMode.On : VSyncMode.Off);

            this.load = load;
            this.resize = resize;
            this.update = update;
            this.render = render;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            load(e);
        }
        protected override void OnResize(EventArgs e)
        {
            Console.WriteLine("reize");
            base.OnResize(e);
            resize(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            update(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            render(e);
        }
    }
}
