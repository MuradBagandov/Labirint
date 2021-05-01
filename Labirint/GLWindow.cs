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
        Labirint labirint = new Labirint(100, 100);
        public GLWindow() : base(800, 800, new GraphicsMode(32, 4, 8, 8), "Labirint")
        {

        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Viewport(ClientRectangle);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-51.0f, 51.0f, -51.0f, 51.0f, -1.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            //GL.Enable(EnableCap.AlphaTest);
            //GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            labirint.Generate();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();
            GL.Translate(-49.5, -49.5, 0);
            GL.Color3(0.7f, 0.7, 0.7);

            GL.Begin(BeginMode.Lines);

            LabirintBlock block;

            for (int i = 0; i < labirint.Height; i++)
            {
                for (int j = 0; j < labirint.Width; j++)
                {
                    block = labirint.labirintArray[i, j];

                    if (block.Left)
                    {
                        GL.Vertex2(j - 0.5f, i - 0.5f);
                        GL.Vertex2(j - 0.5f, i + 0.5f);
                    }
                    if (block.Right)
                    {
                        GL.Vertex2(j + 0.5f, i - 0.5f);
                        GL.Vertex2(j + 0.5f, i + 0.5f);
                    }
                    if (block.Top)
                    {
                        GL.Vertex2(j - 0.5f, i + 0.5f);
                        GL.Vertex2(j + 0.5f, i + 0.5f);
                    }
                    if (block.Bottom)
                    {
                        GL.Vertex2(j - 0.5f, i - 0.5f);
                        GL.Vertex2(j + 0.5f, i - 0.5f);
                    }
                }
            }

            GL.End();
            SwapBuffers();
            base.OnRenderFrame(e);
        }

    }
}
