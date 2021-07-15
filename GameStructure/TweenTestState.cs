using GameStructure;

class TweenTestState: IGameObject {
    Tween _tween = new Tween(0, 256, 5);
    Sprite _sprite = new Sprite();

    public SpriteTweenState(TextureManager textureManager) {
        _sprite.Texture = textureManager.Get("face");
        _sprite.SetHeight(0);
        _sprite.SetWidth(0);
    }

    public void Render() {
        // Rendering code goes here
    }

    public void Update(double elapsedTime) {
        if (_tween.IsFinished() != true) {
            _tween.Update(elapsedTime);
            _tween.SetWidth((float)_tween.Value());
            _tween.SetHeight((float)_tween.Value());
        }
    }
}