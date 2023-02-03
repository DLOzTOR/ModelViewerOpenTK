using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;
using OpenTK.Graphics.OpenGL4;

namespace ModelViewerOpentk.Logic
{
    internal sealed class ObjLoader
    {
        public static ArrayObject LoadObj(string path)
        {
            if(File.Exists(path) == false)
            {
                throw new FileNotFoundException("Coudn't fint file: " + path);
            }
            
            List<float> vertives = new List<float>();
            string[] objToStr = File.ReadAllLines(path);
            List<string[]> args = new List<string[]>();
            List<float> vertices = new List<float>();
            List<uint> idicies = new List<uint>();
            foreach (string str in objToStr)
            {
                args.Add(str.Split(' '));
            }
            foreach (string[] arg in args){
                switch (arg[0])
                {
                    case "v":   
                        vertices.Add((float)Convert.ToDouble(arg[1], CultureInfo.InvariantCulture));
                        vertices.Add((float)Convert.ToDouble(arg[2], CultureInfo.InvariantCulture));    
                        vertices.Add((float)Convert.ToDouble(arg[3], CultureInfo.InvariantCulture));
                        break;
                    case "f":
                        idicies.Add(uint.Parse(arg[1].Split('/')[0])-1);
                        idicies.Add(uint.Parse(arg[2].Split('/')[0])-1);
                        idicies.Add(uint.Parse(arg[3].Split('/')[0])-1);
                        break;
                }
            }
            BufferObject vbo = new BufferObject(vertices.ToArray(), BufferTarget.ArrayBuffer);
            BufferObject ebo = new BufferObject(idicies.ToArray(), BufferTarget.ElementArrayBuffer);
            
            return new ArrayObject(vbo,ebo,vertices.Count,idicies.Count);
        }
    }
}
