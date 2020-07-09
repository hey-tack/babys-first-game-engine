using GameStructure;
using OpenTK.Graphics.OpenGL;

public class Batch {
    const int MaxVertexNumber = 1000;
    Vector[] _vertexPositions = new Vector[MaxVertexNumber];
    Color[] _vertexColors = new Color[MaxVertexNumber];
    Point[] _vertexUVs = new Point[MaxVertexNumber];
    int _batchSize = 0;
    
    const int VertexDimensions = 3;
    const int ColorDimensions = 4;
    const int UVDimensions = 2;

    void SetupPointers() {
        GL.EnableClientState(ArrayCap.ColorArray);
        GL.EnableClientState(ArrayCap.VertexArray);
        GL.EnableClientState(ArrayCap.TextureCoordArray);
        GL.VertexPointer(VertexDimensions, VertexPointerType.Double, 0, _vertexPositions);
        GL.ColorPointer(ColorDimensions, ColorPointerType.Float, 0, _vertexColors);
        GL.TexCoordPointer(UVDimensions, TexCoordPointerType.Float, 0, _vertexUVs);
    }

    public void Draw() {
        if (_batchSize == 0) {
            return;
        } 
        SetupPointers();
        GL.DrawArrays(PrimitiveType.Triangles, 0, _batchSize);
        _batchSize = 0;
    }

    public void AddSprite(Sprite sprite) {
        // If the batch is full, draw it, empty and start again.
        if (sprite.VertexPositions.Length + _batchSize > MaxVertexNumber) {
            Draw();
        }
        // Add the current sprite verticies to the batch
        for (int i = 0; i < sprite.VertexPositions.Length; i++) {
            int vertexIndex = _batchSize + i;
            _vertexPositions[vertexIndex] = sprite.VertexPositions[i];
            _vertexColors[vertexIndex] = sprite.VertexColors[i];
            _vertexUVs[vertexIndex] = sprite.VertexUVs[i];
        }
        _batchSize += sprite.VertexPositions.Length;
    }
}