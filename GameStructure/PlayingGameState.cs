namespace GameStructure {
    class PlayingGameState : IGameObject
    {
        public void Update(double deltaTime)
        {
            // throw new System.NotImplementedException();
            System.Console.WriteLine("Updating Playing");
        }

        public void Render()
        {
            System.Console.WriteLine("Rendering Playing");
            // throw new System.NotImplementedException();
        }
    }
}