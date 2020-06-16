using OpenTK.Graphics.OpenGL;

namespace GameStructure {
    public class Renderer {
        public Renderer() {
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        public void DrawImmediateModeVertex(Vector position, Color color, Point uvs) {
            GL.Color4(color.Red, color.Green, color.Blue, color.Alpha);
            GL.TexCoord2(uvs.X, uvs.Y);
            GL.Vertex3(position.X, position.Y, position.Z);
        }

        public void DrawSprite(Sprite sprite) {
            GL.Begin(PrimitiveType.Triangles);
            {
                for (int i = 0; i < Sprite.VertexAmount; i++) {
                    DrawImmediateModeVertex(
                        sprite.VertexPositions[i],
                        sprite.VertexColors[i],
                        sprite.VertexUVs[i]);
                }
            }
            GL.End();
        }

        public void DrawText(Text text) {
            foreach(CharacterSprite c in text.CharacterSprites) {
                DrawSprite(c.Sprite);
            }
        }
    }
}