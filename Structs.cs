using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
// Should probably just rename this to Vector3d
public struct Vector 
{
    public double X {get; set;}
    public double Y {get; set;}
    public double Z {get; set;}

    public Vector (double x, double y, double z) : this() {
        X = x;
        Y = y;
        Z = z;
    }
}

[StructLayout(LayoutKind.Sequential)]
// Should probably just rename this to Vector2d
public struct Point {
    public float X {get;set;}
    public float Y {get;set;}
    public Point(float x, float y) : this() {
        X = x;
        Y = y;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct Color {
    public float Red {get;set;}
    public float Green {get;set;}
    public float Blue {get;set;}
    public float Alpha {get;set;}
    public Color(float red, float green, float blue, float alpha) : this() {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }
}