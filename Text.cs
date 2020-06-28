using System;
using System.Collections.Generic;

public class Text {
    Font _font;
    List<CharacterSprite> _bitmapText = new List<CharacterSprite>();
    string _text;
    Color _color;
    Vector _dimensions;
    int _maxWidth;
    
    public double Width {
        get { return _dimensions.X; }
    }

    public double Height {
        get { return _dimensions.Y; }
    }

    public List<CharacterSprite> CharacterSprites {
        get { return _bitmapText; }
    }

    // Is this the only way to do constuctor overriding? Looks kinda gross. 
    public Text(string text, Font font) : this(text, font, -1) {} 
    public Text(string text, Font font, int maxWidth) {
        _text = text;
        _font = font;
        _maxWidth = maxWidth;
        CreateText(0,0, _maxWidth);
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
        CreateText(x, y, _maxWidth);
    }

    private void CreateText(double x, double y, double maxWidth) {
        _bitmapText.Clear();
        double currentX = x;
        double currentY = y;
        string[] words = _text.Split(' ');
        foreach (string word in words) {
            Vector nextWordLength = _font.MeasureFont(word);
            if (maxWidth != -1 && (currentX + nextWordLength.X) > maxWidth) {
                currentX = 0;
                currentY += nextWordLength.Y; 
            }
            string wordWithSpace = word + " "; // add the space character that was removed
            foreach(char c in wordWithSpace) {
                CharacterSprite sprite = _font.CreateSprite(c);
                float xOffset = (((float)sprite.Data.Width) * 0.5f) + ((float)sprite.Data.XOffset);
                float yOffset = (((float)sprite.Data.Height) * 0.5f) + ((float)sprite.Data.YOffset);
                sprite.Sprite.SetPosition(x + currentX + xOffset, y - currentY - yOffset);
                currentX += sprite.Data.XAdvance + sprite.Data.XOffset;
                _bitmapText.Add(sprite);
            }
        }
        _dimensions = _font.MeasureFont(_text);
        _dimensions.Y = currentY;
        SetColor();
    }
}