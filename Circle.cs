using System;
using OpenTK.Graphics.OpenGL;

public class Circle {
    Color _color = new Color(1,1,1,1);

    Vector Position { get; set; }
    double Radius { get; set; }
    Color color { 
        get { return _color; } 
        set { _color = value; } 
    }

    public Circle() {
        Position = Vector.Zero;
        Radius = 1;
    }

    public Circle(Vector position, double radius) {
        Position = position;
        Radius = radius;
    }

    public void Draw() {
        // Determines how round the circle will appear
        int vertexAmount = 20;
        double tau = 2.0 * Math.PI;

        // A line loop connects all the vertecies with lines
        // The last vertex is connected to the first vertex
        // to make a loop.
        GL.Color3(_color.Red, _color.Green, _color.Blue);
        GL.Begin(PrimitiveType.LineLoop);
        {
            for (int i = 0; i <= vertexAmount; i++) {
                double xPos = Position.X + Radius * Math.Cos(i * tau / vertexAmount);
                double yPos = Position.Y + Radius * Math.Sin(i * tau / vertexAmount);
                GL.Vertex2(xPos, yPos);
            }
        }
        GL.End();
    }
}