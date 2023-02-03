using System;
using System.Collections.Generic;
//using SFML.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ModelViewerOpentk.Logic;

namespace ModelViewerOpentk
{
    class Window : GameWindow
    {

        string path1 = "cube.obj";
        string path2 = "sphere.obj";
        string path3 = "sphere2.obj";
        string path4 = "monkey.obj";

        public Window(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title, Flags = ContextFlags.Default, Profile = ContextProfile.Compatability })
        {
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (input.IsKeyDown(Keys.D1))
            {
                vao = vao1;
            }
            if (input.IsKeyDown(Keys.D2))
            {
                vao = vao2;
            }
            if (input.IsKeyDown(Keys.D3))
            {
                vao = vao3;
            }            
            if (input.IsKeyDown(Keys.D4))
            {
                vao = vao4;
            }
        }
        ArrayObject vao1;
        ArrayObject vao2;
        ArrayObject vao3;
        ArrayObject vao4;
        ArrayObject vao;
        
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            vao1 = ObjLoader.LoadObj(path1);
            vao2 = ObjLoader.LoadObj(path2);
            vao3 = ObjLoader.LoadObj(path3);
            vao4 = ObjLoader.LoadObj(path4);
            vao = vao1;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            vao.Draw();
            SwapBuffers();
        }
    }
}