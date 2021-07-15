using OpenTK.Graphics.OpenGL;

class CircleIntersectionState: IGameObject {
    Circle _circle = new Circle(Vector.Zero, 200);
    Input _input;

    public CircleIntersectionState(Input input) 
    {
        _input = input;
        GL.LineWidth(3);
        GL.Disable(EnableCap.Texture2D);
    }

    public void Update(double deltaTime)
    {
        if (_circle.Intersects(_input.MousePosition)) {
            _circle.Color = new Color(1, 0, 0, 1);
        } else {
            _circle.Color = new Color(1, 1, 1, 1);
        }
    }

    public void Render()
    {
        GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        _circle.Draw();

        // Draw the mouse cursor as a point
        GL.PointSize(5);
        GL.Begin(PrimitiveType.Points);
        {
            GL.Vertex2(_input.MousePosition.X, _input.MousePosition.Y);
        }
        GL.End();
    }
}