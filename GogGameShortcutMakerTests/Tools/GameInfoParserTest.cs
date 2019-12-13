using System;
using GogGameShortcutMaker;
using GogGameShortcutMaker.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GogGameShortcutMakerTests.Tools
{
    [TestClass]
    public class GameInfoParserTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var parser = new GameInfoParser();
            var shortcutMaker = new DesktopShortcutMaker();
            
            var gameInfo = parser.ParseGameInfo(@"C:\Program Files (x86)\GOG Galaxy\Games\Into the Breach\goggame-2004253604.info");
            shortcutMaker.MakeShortcut(gameInfo);
            

        }
    }
}
