using Newtonsoft.Json;
using System.IO;

namespace GogGameShortcutMaker.Models
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

            return JsonConvert.DeserializeObject<GameInfo>(fileContent);
        }
    }
}
