using System.Collections.Generic;

namespace GogGameShortcutMaker.Models
{
    internal interface IRepository
    {
        IList<IGamePathInfo> Games { get; }
    }

    internal class Repository : IRepository
    {
        public IList<IGamePathInfo> Games { get; } = new List<IGamePathInfo>();
    }
}
