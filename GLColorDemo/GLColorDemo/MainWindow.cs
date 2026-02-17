using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using GLColorDemo.Shaders;

namespace GLColorDemo
{
    public class MainWindow : GameWindow
    {
        private MainDefaultShader shader;
        private Plane plane;

        public MainWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            shader = new MainDefaultShader("Shaders/shader.vert", "Shaders/shader.frag");

            shader.Load();
            plane = new Plane();
            plane.Load(shader);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            StartFrame();
            Render(e.Time);

            SwapBuffers();
        }

        private void Render(double time)
        {
            Matrix4 m = Matrix4.Identity;
            shader.SetModelMatrix(m);
            plane.Renderer();
        }

        internal void StartFrame()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            shader.Use();
            SetupViewMatrices();


        }

        private void SetupViewMatrices()
        {
            float aspectRatio = Size.X / (float)Size.Y;

            Matrix4 pM = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, aspectRatio, 0.01f, 100f);
            Matrix4 vM = Matrix4.LookAt(new Vector3(0, 0, 10), new Vector3(), Vector3.UnitY);

            shader.SetMatrix4("view", vM);
            shader.SetMatrix4("projection", pM);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);


            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }
    }
}

