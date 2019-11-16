using System.Collections.Generic;

namespace GogGameShortcutMaker.Models
{
    internal interface IRepository
    {
        IList<IGame> Games { get; }
    }

    internal class Repository : IRepository
    {
        public IList<IGame> Games { get; } = new List<IGame>();
    }
}
