using System;
using GameStructure;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class Game : GameWindow
    {
        StateSystem _system = new StateSystem();
        TextureManager _textureManager = new TextureManager();
        Input _input = new Input();
        double deltaTime = 0.0f;

        public Game(int width, int height) : base(width, height) 
        {
            // Load textures
            _textureManager.LoadTexture("penguin", "Images/penguin.png");
            _textureManager.LoadTexture("font", "Fonts/Arial/font.png");

            // Add all states that will be used
            _system.AddState("splash", new SplashScreenState(_system));
            _system.AddState("title_menu", new TitleMenuState());
            _system.AddState("settings", new SettingsMenuState());
            _system.AddState("playing", new PlayingGameState());
            _system.AddState("sprite_test", new DrawSpriteState(_textureManager));
            _system.AddState("new_sprite_test", new TestSpriteClassState(_textureManager));
            _system.AddState("text_test_state", new TextTestState(_textureManager));
            _system.AddState("fps_test_state", new FPSTestState(_textureManager));
            _system.AddState("wave_graph_state", new WaveformGraphState());
            _system.AddState("special_eff_state", new SpecialEffectState(_textureManager));
            _system.AddState("circle", new CircleIntersectionState(_input));

            // select the start state
            _system.ChangeState("circle");

            // Setup orthographic view
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);

        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            base.OnUpdateFrame(e);

            UpdateInput();

            deltaTime = e.Time;
            _system.Update(deltaTime);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            _system.Render();
            GL.Flush();
            SwapBuffers();

        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            GL.Viewport(0,0,this.ClientSize.Width, this.ClientSize.Height);

            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        private void Setup2DGraphics(double width, double height) {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        private void UpdateInput() {
            MouseState mouseState = Mouse.GetCursorState();
            OpenTK.Point mousePos = this.PointToClient(new OpenTK.Point(mouseState.X, mouseState.Y));
        
            // Now use our point definition
            Point adjustedMousePoint = new Point();
            adjustedMousePoint.X = (float)mousePos.X - ((float)ClientSize.Width / 2);
            adjustedMousePoint.Y = ((float)ClientSize.Height / 2) - (float)mousePos.Y;

            _input.MousePosition = new Point(adjustedMousePoint.X, adjustedMousePoint.Y);
        }
    }