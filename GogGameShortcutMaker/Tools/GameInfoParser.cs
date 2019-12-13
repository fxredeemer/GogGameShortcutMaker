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
            string fileContent = File.ReadAllText(path);

            var gameInfo = JsonConvert.DeserializeObject<GameInfo>(fileContent);

            gameInfo.Path = path;

            return gameInfo;
        }
    }
}
