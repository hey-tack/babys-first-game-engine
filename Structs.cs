using System;
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

    public double Length() {
        return Math.Sqrt(LengthSquared());
    }

    public double LengthSquared() {
        return (X * X + Y * Y + Z * Z);
    }

    public bool Equals(Vector v) {
        return (X == v.X) && (Y == v.Y) && (Z == v.Z);
    }

    public override int GetHashCode() {
        return (int)X^ (int)Y^ (int)Z;
    }

    public static bool operator == (Vector v1, Vector v2) {
        // If they're the same object, or both null, return true
        if (System.Object.ReferenceEquals(v1, v2)) {
            return true;
        }

        // if one is null, but not both, return false
        if (v1 == null || v2 == null) {
            return false;
        }

        return v1.Equals(v2);
    }

    public override bool Equals(object? obj) {
        if (obj is Vector) {
            return Equals((Vector)obj);
        }
        return base.Equals(obj);
    }

    public static bool operator != (Vector v1, Vector v2) {
        return !v1.Equals(v2);
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