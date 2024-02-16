﻿using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

using Framework.Core;

namespace Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var window = new HelloAttribute(
                GameWindowSettings.Default,
                new NativeWindowSettings()
                {
                    Title = "Hello Attribute",
                    ClientSize = new Vector2i(800, 800),
                    WindowBorder = WindowBorder.Fixed,
                    WindowState = WindowState.Normal,
                    APIVersion = new Version(3, 3),
                    Vsync = VSyncMode.On
                });

            Shader.SetRootPath("Resources/Shader/");

            window.Run();
        }
    }
}
