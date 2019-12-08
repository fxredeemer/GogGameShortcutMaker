namespace GogGameShortcutMaker.Models
{
    internal interface IGamePathInfo
    {
        string Name { get; }
        string Path { get; }
        GameInfo GameInfo { get; }
    }

    internal class GamePathInfo : IGamePathInfo
    {
        public string Path { get; }
        public string Name => GameInfo.Name;
        public GameInfo GameInfo { get; }


        public GamePathInfo(
            GameInfo gameInfo,
            string path)
        {
            GameInfo = gameInfo;
            Path = path;
        }
    }
}
