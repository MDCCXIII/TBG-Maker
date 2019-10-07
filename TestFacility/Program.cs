
using StoryGameAPI;
using StoryGameAPI.Utilities.ConsoleUtils;
using StoryGameAPI.Utilities.FileUtils;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace TestFacility
{
    class Program
    {
        static List<Game> games;

        static void Main(string[] args)
        {
            new Game(out games);
            testLoadScenes();
        }

        private static void testLoadScenes()
        {
            Console.WriteLine("From Scene file: " + games[0].sceneFilePaths[1]);
            ConsoleOutputUtils.slowWrite(games[0].scenes.scripts[1]);
        }
    }
}
