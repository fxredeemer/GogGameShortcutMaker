namespace GogGameShortcutMaker.Models
{
    internal interface IGame
    {
        string Name { get; }
        string Path { get; }

    }

    internal class Game : IGame
    {
        public string Path { get; }

        public string Name { get; }


        public Game(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
