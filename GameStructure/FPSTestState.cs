using OpenTK.Graphics.OpenGL;

namespace GameStructure {
    class FPSTestState : IGameObject
    {
        TextureManager _textureManager;
        Font _font;
        Text _fpsText;
        Renderer _renderer = new Renderer();
        FramesPerSecond _fps = new FramesPerSecond();
        public FPSTestState(TextureManager textureManager) {
            _textureManager = textureManager;
            _font = new Font(textureManager.Get("font"), FontParser.Parse("Fonts/Arial/font.fnt"));
            _fpsText = new Text("FPS:", _font);
        }

        public void Update(double deltaTime)
        {
            _fps.Process(deltaTime);
        }

        public void Render()
        {
            GL.ClearColor(0,0,0,0);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _fpsText = new Text ("FPS: " + _fps.CurrentFPS.ToString("00.0"), _font);
            _fpsText.SetColor(new Color(1,1,1,1));
            _renderer.DrawText(_fpsText);
            _renderer.DrawText(_fpsText);
        }
    }
}