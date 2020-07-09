using System;
using GameStructure;
using OpenTK.Graphics.OpenGL;

class SpecialEffectState : IGameObject {
    Font _font;
    Text _text;
    Renderer _renderer = new Renderer();
    double _totalTime = 0;

    public SpecialEffectState (TextureManager manager) {
        _font = new Font(manager.Get("font"), FontParser.Parse("Fonts/Arial/font.fnt"));
        _text = new Text("Hello", _font);
    }

    public void Update(double deltaTime)
    {
        double frequency = 7;

        // Text that fades in and out
        // float _wavyNumber = (float)Math.Sin(_totalTime*frequency);
        // _wavyNumber = 0.5f + _wavyNumber * 0.5f; // scale to 0-1
        // _text.SetColor(new Color(1,1,1,_wavyNumber));

        // Some rainbow effects
        // float _wavyNumberR = (float)Math.Sin(_totalTime*frequency);
        // float _wavyNumberG = (float)Math.Sin(_totalTime+0.25*frequency);
        // float _wavyNumberB = (float)Math.Sin(_totalTime+0.5*frequency);
        // _wavyNumberR = 0.5f + _wavyNumberR * 0.5f; // scale to 0-1
        // _wavyNumberG = 0.5f + _wavyNumberG * 0.5f; // scale to 0-1
        // _wavyNumberB = 0.5f + _wavyNumberB * 0.5f; // scale to 0-1
        // _text.SetColor(new Color(_wavyNumberR,_wavyNumberG,_wavyNumberB,1));

        // Moving text around
        // double _wavyNumberX = Math.Sin(_totalTime*frequency) * 15;
        // double _wavyNumberY = Math.Cos(_totalTime*frequency) * 15;
        // _text.SetPosition(_wavyNumberX, _wavyNumberY);

        // Wiggly text
        int xAdvance = 0;
        foreach(CharacterSprite cs in _text.CharacterSprites) {
            Vector position = cs.Sprite.GetPosition();
            position.Y = 0 + Math.Sin((_totalTime + xAdvance) * frequency) * 25;
            cs.Sprite.SetPosition(position);
            xAdvance++;
        }

        _totalTime += deltaTime;
    }

    public void Render()
    {
        GL.ClearColor(0,0,0,1);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        _renderer.DrawText(_text);
        _renderer.Render();
        

    }
}