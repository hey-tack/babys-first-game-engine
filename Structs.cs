using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
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

    public static Vector Zero = new Vector(0,0,0);

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

    public override bool Equals(object obj) {
        if (obj is Vector) {
            return Equals((Vector)obj);
        }
        return base.Equals(obj);
    }

    public static bool operator != (Vector v1, Vector v2) {
        return !v1.Equals(v2);
    }

    public Vector Add(Vector r) {
        return new Vector (X + r.X, Y + r.Y, Z + r.Z);
    }

    // Overriding mathematical operators? Interesting. 
    public static Vector operator+ (Vector v1, Vector v2) {
        return v1.Add(v2);
    }

    public Vector Subtract(Vector r) {
        return new Vector(X - r.X, Y - r.Y, Z - r.Z);
    }

    public static Vector operator- (Vector v1, Vector v2) {
        return v1.Subtract(v2);
    }

    public Vector Multiply(double v) {
        return new Vector(X * v, Y * v, Z * v);
    }

    public static Vector operator* (Vector v1, Double s) {
        return v1.Multiply(s);
    }

    public Vector Normalize(Vector v) {
        double r = v.Length();
        if (r != 0.0) // Guard against divide by zero
        {
            return new Vector(v.X / r, v.Y / r, v.Z / r); // Normalize and return
        }
        else {
            return new Vector(0,0,0);
        }
    }

    public double DotProduct(Vector v) {
        return (X * v.X) + (Y * v.Y) + (Z * v.Z);
    }

    public static double operator* (Vector v1, Vector v2) {
        return v1.DotProduct(v2);
    }

    public Vector CrossProduct(Vector v) {
        double nx = Y * v.Z - Z * v.Y;
        double ny = Z * v.X - X * v.Z;
        double nz = X * v.Y - Y * v.X;
        return new Vector(nx, ny, nz);
    }

    public override string ToString() {
        return string.Format($"X:{X}, Y:{Y}, Z:{Z}");
    }
}

[StructLayout(LayoutKind.Sequential)]
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
    public Color(float red, float green, float blue, float alpha = 1) : this() {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }
}