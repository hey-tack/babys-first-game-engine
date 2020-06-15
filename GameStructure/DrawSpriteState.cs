using OpenTK.Graphics.OpenGL;

namespace GameStructure
{
    public class DrawSpriteState : IGameObject
    {
        TextureManager _textureManager;

        double height;
        double width;
        double halfHeight;
        double halfWidth;

        float topUV = 0;
        float bottomUV = 1;
        float leftUV = 0;
        float rightUV = 1;

        float red = 1;
        float green = 0;
        float blue = 0;
        float alpha = 1;

        double x = 0;
        double y = 0;
        double z = 0;

        public DrawSpriteState(TextureManager textureManager) {
            _textureManager = textureManager;

            height = 200;
            width = 200;
            halfHeight = height / 2;
            halfWidth = width / 2;
        }


        public void Update(double deltaTime)
        {
        }

        public void Render()
        {
            GL.ClearColor(1,0,0,1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Texture texture = _textureManager.Get("penguin");

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture.Id);

            // Enable alpha blending
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Begin(PrimitiveType.Triangles); 
            GL.Color4(red, green, blue, alpha);
            GL.TexCoord2(leftUV, topUV);
            GL.Vertex3(x - halfWidth, y + halfHeight, z);
            GL.TexCoord2(rightUV, topUV);
            GL.Vertex3(x + halfWidth, y + halfHeight, z);
            GL.TexCoord2(leftUV, bottomUV);
            GL.Vertex3(x - halfWidth, y - halfHeight, z);
            GL.TexCoord2(rightUV, topUV);
            GL.Vertex3(x + halfWidth, y + halfHeight, z);
            GL.TexCoord2(rightUV, bottomUV);
            GL.Vertex3(x + halfWidth, y - halfHeight, z);
            GL.TexCoord2(leftUV, bottomUV);
            GL.Vertex3(x - halfWidth, y - halfHeight, z);
            GL.End();
        }
    }
}