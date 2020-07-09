using OpenTK.Graphics.OpenGL;

namespace GameStructure {
    class FPSTestState : IGameObject
    {
        TextureManager _textureManager;
        Font _font;
        Text _fpsText;
        Text _longText;
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
            _fpsText.SetPosition(-(_fpsText.Width / 2),0);
            _fpsText.SetColor(new Color(1,1,1,1));

            // Let's simulate drawing a ton of sprites
            // for (int i = 0; i < 10000; i++) {
            //     _renderer.DrawText(_fpsText);
            // }

            _longText = new Text("The quick brown fox jumps over the lazy dog", _font, 300);
            _longText.SetPosition(-(_longText.Width / 2), -30);
            _longText.SetColor(new Color(1,1,1,1));
            _renderer.DrawText(_longText);

            _renderer.Render();
        }
    }
}