class RectangleIntersectionState : IGameObject {
    Input _input;
    Rectangle _rectangle = new Rectangle(new Vector(0,0,0), new Vector(200,200,0));
    public RectangleIntersectionState(Input input) {
        _input = input;
    }

    public void Update(double elapsedTime) {
        if (_rectangle.Intersects(_input.MousePosition)) {
            _rectangle.Color = new Color(1,0,0,1);
        } else {
            _rectangle.Color = new Color(1,1,1,1);
        }
    }

    public void Render() {
        _rectangle.Render();
    }
}