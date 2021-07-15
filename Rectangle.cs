using System;
using OpenTK.Graphics.OpenGL;

public class Rectangle {
    Vector BottomLeft {get;set;}
    Vector TopRight {get;set;}
    Color _color = new Color(1,1,1,1);
    public Color Color{
        get {return _color;}
        set {_color = value;}
    }

    public Rectangle(Vector bottomLeft, Vector topRight) {
        BottomLeft = bottomLeft;
        TopRight = topRight;
    }

    // TODO: why is this Render(), but the circle has Draw()? Consolidate to one or the other maybe?
    public void Render() {
        GL.Color3(_color.Red, _color.Green, _color.Blue);
        GL.Begin(PrimitiveType.LineLoop);
        {
            GL.Vertex2(BottomLeft.X, BottomLeft.Y);
            GL.Vertex2(BottomLeft.X, TopRight.Y);
            GL.Vertex2(TopRight.X, TopRight.Y);
            GL.Vertex2(TopRight.X, BottomLeft.Y);
        }
        GL.End();
    }

    public bool Intersects(Point point) {
        if (
            point.X >= BottomLeft.X &&
            point.X <= TopRight.X &&
            point.Y <= TopRight.Y &&
            point.Y >= BottomLeft.Y
        ) {
            return true;
        } else {
            return false;
        }
    }
}