using OpenTK.Graphics.OpenGL;

namespace GameStructure {
    public class TestSpriteClassState : IGameObject
    {
        Renderer _renderer = new Renderer();
        TextureManager _textureManager;
        Sprite _testSprite = new Sprite();
        Sprite _testSprite2 = new Sprite();

        public TestSpriteClassState(TextureManager textureManager) {
            _textureManager = textureManager;
            _testSprite.Texture = _textureManager.Get("penguin");
            _testSprite.SetHeight(256 * 0.5f);

            _testSprite2.Texture = _textureManager.Get("penguin");
            _testSprite.SetPosition(-256, -256);
            _testSprite.SetColor(new Color(1,0,0,1));
        }

        public void Render()
        {
            GL.ClearColor(1,0,0,1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _renderer.DrawSprite(_testSprite);
            _renderer.DrawSprite(_testSprite2);
            GL.Finish();
        }

        public void Update(double deltaTime)
        {
            // throw new System.NotImplementedException();
        }
    }
}
