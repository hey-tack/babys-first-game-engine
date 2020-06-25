using System;
using System.Collections.Generic;

public class Text {
    Font _font;
    List<CharacterSprite> _bitmapText = new List<CharacterSprite>();
    string _text;
    Color _color;
    Vector _dimensions;

    public double Width {
        get { return _dimensions.X; }
    }

    public double Height {
        get { return _dimensions.Y; }
    }

    public List<CharacterSprite> CharacterSprites {
        get { return _bitmapText; }
    }

    public Text(string text, Font font) {
        _text = text;
        _font = font;
        CreateText(0,0);
    }

    public void SetPosition(double x, double y) {
        CreateText(x, y);
    }

    public void SetColor(Color color) {
        _color = color;
        foreach(CharacterSprite s in _bitmapText) {
            s.Sprite.SetColor(_color);
        }
    }

    public void SetColor() {
        foreach(CharacterSprite s in _bitmapText) {
            s.Sprite.SetColor(_color);
        }
    }

    private void CreateText(double x, double y) {
        _bitmapText.Clear();
        double currentX = x;
        double currentY = y;

        foreach(char c in _text) {
            CharacterSprite sprite = _font.CreateSprite(c);
            float xOffset = ((float)sprite.Data.XOffset) / 2;
            float yOffset = ((float)sprite.Data.YOffset) / 2;
            sprite.Sprite.SetPosition(currentX + xOffset, currentY - yOffset);
            currentX += sprite.Data.XAdvance;
            _bitmapText.Add(sprite);
        }
        _dimensions = _font.MeasureFont(_text);
        SetColor();
    }
}