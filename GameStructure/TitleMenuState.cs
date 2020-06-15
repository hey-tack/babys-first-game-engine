using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GameStructure {
    class TitleMenuState : IGameObject
    {
        double _currentRotation = 0;

        public void Update(double deltaTime)
        {
            _currentRotation = 10 * deltaTime;
        }

        public void Render()
        {
            GL.ClearColor(1.0f, 0.0f, 0.0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.PointSize(5f);

            GL.Rotate(_currentRotation, 0, 1, 0);
            GL.Begin(PrimitiveType.TriangleStrip); 
            // I've since overridden the meaning of "color" as a primitive, so yeah... that sucks. 
            // GL.Color3(Color.Red);
            // GL.Vertex3(-50,0,0);
            // GL.Color3(Color.Blue);
            // GL.Vertex3(50,0,0);
            // GL.Color3(Color.Green);
            GL.Vertex3(0,50,0);
            GL.End();
            GL.Finish();

        }
    }
}