using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

public class TextureManager {
    Dictionary<string, Texture> _textureDatabase = new Dictionary<string, Texture>();

    public Texture Get(string textureId) {
        return _textureDatabase[textureId];
    }

    public void LoadTexture(string textureId, string path) {
        Bitmap bitmap = new Bitmap(path);

        int openGlId = GL.GenTexture();

        BitmapData bmpData = bitmap.LockBits(
            new Rectangle(0,0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        GL.BindTexture(TextureTarget.Texture2D, openGlId);
        GL.TexImage2D(TextureTarget.Texture2D, 0,
            PixelInternalFormat.Rgba,
            bitmap.Width, bitmap.Height, 0,
            OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
            PixelType.UnsignedByte,
            bmpData.Scan0);

        bitmap.UnlockBits(bmpData);

        //Linear for smoothing, but you can use Nearest for harder edges (more pixelated)
        GL.TexParameter(TextureTarget.Texture2D,
            TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D,
            TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Linear);

        _textureDatabase.Add(textureId, new Texture(openGlId, bitmap.Width, bitmap.Height));
    }

    public void Dispose() {
        foreach(Texture texture in _textureDatabase.Values) {
            // This could use some micro optimization :/
            GL.DeleteTextures(1, new int[] { texture.Id });
        }
    }
}