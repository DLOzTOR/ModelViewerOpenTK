using OpenTK.Graphics.OpenGL4;

namespace ModelViewerOpentk.Logic
{
    class ArrayObject
    {
        public int ArrayId { get; private set; }
        BufferObject verticesBuffer;
        BufferObject indexBuffer;
        BufferObject UVBuffer;
        int verticesCount;
        int indexCount;
        public ArrayObject(BufferObject vbo, BufferObject ebo, int verticesCount, int indexCount)
        {
            ArrayId = GL.GenVertexArray();
            verticesBuffer = vbo;
            indexBuffer = ebo;
            this.verticesCount = verticesCount;
            this.indexCount = indexCount;
            GL.BindVertexArray(ArrayId);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo.BufferId);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo.BufferId);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindVertexArray(0);
        }
        ~ArrayObject()
        {
            Desactivate();
            GL.DeleteVertexArray(ArrayId);
        }
        public void Draw()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer.BufferId);
            GL.BindVertexArray(ArrayId);
            GL.DrawElements(PrimitiveType.Triangles, verticesCount * indexCount/3, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
        }
        public void Activate()
        {
            GL.BindVertexArray(ArrayId);
        }
        public void Desactivate()
        {
            GL.BindVertexArray(0);
        }
    }
}
