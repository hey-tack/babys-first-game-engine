namespace OpenTKExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game(640, 480))
            {
                game.Run();
            }
        }
    }
}