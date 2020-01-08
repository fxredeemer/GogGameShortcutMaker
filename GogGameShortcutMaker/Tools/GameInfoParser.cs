using GogGameShortcutMaker.Models;
using Newtonsoft.Json;
using System.IO;

namespace GogGameShortcutMaker.Tools
{
    internal interface IGameInfoParser
    {
        GameInfo ParseGameInfo(string path);
    }

    internal class GameInfoParser : IGameInfoParser
    {
        public GameInfo ParseGameInfo(string path)
        {
            var fileContent = File.ReadAllText(path);

            var gameInfo = JsonConvert.DeserializeObject<GameInfo>(fileContent);

            TryAddIcon(gameInfo, path);
            gameInfo.Path = path;

            return gameInfo;
        }

        private void TryAddIcon(GameInfo gameInfo, string path)
        {
            var iconPath = $"{Path.GetDirectoryName(path)}\\{Path.GetFileNameWithoutExtension(path)}.ico";
            if (File.Exists(iconPath))
            {
                gameInfo.Icon = iconPath;
            }
        }
    }
}
