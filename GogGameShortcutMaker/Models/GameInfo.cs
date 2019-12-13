using System.Collections.Generic;

namespace GogGameShortcutMaker.Models
{

    internal class GameInfo
    {
        public string GameId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<PlayTask> PlayTasks { get; set; }
    }

    internal class PlayTask
    {
        public string Path { get; set; }
    }
}