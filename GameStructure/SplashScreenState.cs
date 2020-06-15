using OpenTK.Graphics.OpenGL;


namespace GameStructure {
    class SplashScreenState : IGameObject
    {
        StateSystem _system;
        double _delayInSeconds = 3;

        public SplashScreenState(StateSystem system) {
            _system = system;
        }

        public void Update(double deltaTime)
        {
            _delayInSeconds -= deltaTime;
            if (_delayInSeconds <= 0) {
                _delayInSeconds = 3;
                _system.ChangeState("title_menu");
            }
        }

        public void Render()
        {
            GL.ClearColor(1,1,1,1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Finish();
        }
    }
}