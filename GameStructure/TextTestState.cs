using OpenTK.Graphics.OpenGL;

namespace GameStructure {
    class TextTestState : IGameObject
    {
        TextureManager _textureManager;
        Font _font;
        Text _hellowWorld;
        Renderer _renderer = new Renderer();

        public TextTestState(TextureManager textureManager) {
            _textureManager = textureManager;
            _font = new Font(textureManager.Get("font"), FontParser.Parse("Fonts/Arial/font.fnt"));
            _hellowWorld = new Text("Hello", _font);
        }

        public void Update(double deltaTime)
        {
            // System.Console.WriteLine("Updating Text Test State");
        }

        public void Render()
        {
            GL.ClearColor(0,0,0,1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _renderer.DrawText(_hellowWorld);
        }
    }
}