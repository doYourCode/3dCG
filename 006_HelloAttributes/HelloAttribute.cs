﻿using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using Framework.Core;

namespace Examples
{
    internal class HelloAttribute : GameWindow
    {

        private const int POSITION = 0;
        private const int COLOR = 1;
        private readonly int[] OFFSET = { 0, 12 };
        private const int VERTEX_SIZE = 6 * sizeof(float);

        private int vertexBufferObject;
        private int vertexArrayObject;

        private Shader shader;

        public HelloAttribute(
            GameWindowSettings gameWindowSettings,
            NativeWindowSettings nativeWindowSettings) :
            base(gameWindowSettings, nativeWindowSettings) { }

        protected override void OnLoad()
        {
            base.OnLoad();

            float[] data =
            {  // Position          // Color RGB
                -0.75f, -0.75f, 0.0f, 1.0f, 0.0f, 0.0f,
                0.75f , -0.75f, 0.0f, 0.0f, 1.0f, 0.0f,
                0.0f  , 0.75f , 0.0f, 0.0f, 0.0f, 1.0f,
            };

            // Generate the buffer
            vertexBufferObject = GL.GenBuffer();
            // Points to the active buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            // Insert the data into the buffer
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data, BufferUsageHint.StaticDraw);
            // Generate the array object buffer
            vertexArrayObject = GL.GenVertexArray();
            // Points to the array object
            GL.BindVertexArray(vertexArrayObject);
            // Position attribute
            GL.VertexAttribPointer(POSITION, 3, VertexAttribPointerType.Float, false, VERTEX_SIZE, OFFSET[POSITION]);
            GL.EnableVertexAttribArray(POSITION);
            // Color attribute
            GL.VertexAttribPointer(COLOR, 3, VertexAttribPointerType.Float, false, VERTEX_SIZE, OFFSET[COLOR]);
            GL.EnableVertexAttribArray(COLOR);

            shader = new Shader("HelloAttribute");

            GL.ClearColor(0.1f, 0.1f, 0.2f, 1.0f);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            shader.Use();

            GL.BindVertexArray(vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            GL.BindVertexArray(0);

            SwapBuffers();
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.DeleteBuffer(vertexBufferObject);
            GL.DeleteVertexArray(vertexArrayObject);
        }
    }
}
