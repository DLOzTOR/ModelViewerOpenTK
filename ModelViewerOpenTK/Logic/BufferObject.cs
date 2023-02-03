using OpenTK.Graphics.OpenGL4;

namespace ModelViewerOpentk.Logic
{
    class BufferObject
    {
        public int BufferId { get; private set; }
        private BufferTarget _target;
        public BufferObject(float[] data, BufferTarget target)
        {
            baseConstructor(target);
            GL.BufferData(_target, sizeof(float) * data.Length, data, BufferUsageHint.StreamDraw);
            Desactivate();
        }
        public BufferObject(uint[] data, BufferTarget target)
        {
            baseConstructor(target);
            GL.BufferData(_target, sizeof(uint) * data.Length, data, BufferUsageHint.StreamDraw);
            Desactivate();
        }
        void baseConstructor(BufferTarget target)
        {
            _target = target;
            BufferId = GL.GenBuffer();
            GL.BindBuffer(_target, BufferId);
        }
        ~BufferObject()
        {
            Desactivate();
            GL.DeleteBuffer(BufferId);
        }
        public void Activate()
        {
            GL.BindBuffer(_target, BufferId);
        }
        public void Desactivate()
        {
            GL.BindBuffer(_target, 0);
        }
    }
}
