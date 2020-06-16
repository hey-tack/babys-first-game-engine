using OpenTK.Graphics.OpenGL;

namespace GameStructure {
    class FPSTestState : IGameObject
    {
        TextureManager _textureManager;
        Font _font;
        Text _fpsText;
        Renderer _renderer = new Renderer();
        public FPSTestState(TextureManager textureManager) {
            _textureManager = textureManager;
            _font = new Font(textureManager.Get("font"), FontParser.Parse("Fonts/Arial/font.fnt"));
            _fpsText = new Text("FPS:", _font);
        }

        public void Update(double deltaTime)
        {
        }

        public void Render()
        {
            GL.ClearColor(0,0,0,0);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _renderer.DrawText(_fpsText);
        }
    }
}