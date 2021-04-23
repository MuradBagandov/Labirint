using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Labirint
{
    public class GLWindow : GameWindow
    {
        public GLWindow() : base(800, 800,new GraphicsMode(32,4,8,8), "Labirint")
        {

        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Viewport(ClientRectangle);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-10.0f, 10.0f, -10.0f, 10.0f, -1.0f, 1.0f);



            base.OnLoad(e); 
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Color3(1.0f, 0.0, 0.0);
            GL.Begin(BeginMode.Quads);

            GL.Vertex2(-1.0f, -1.0f);
            GL.Vertex2(1.0f, -1.0f);
            GL.Vertex2(1.0f, 1.0f);
            GL.Vertex2(-1.0f, 1.0f);

            GL.End();

            SwapBuffers();
            base.OnRenderFrame(e);
        }

    }
}
