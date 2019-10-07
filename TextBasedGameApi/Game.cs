using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using TextBasedGameApi.Utilities.FileUtils;
using TextBasedGameApi.GameObjects;
using System.IO;
using System.Linq;

namespace TextBasedGameApi
{
    public class Game
    {
        public const string requiredSceneFileNameAppendage = "Scene";
        public const string scenesFolderName = @"\Scenes";
        public const string courseFileName = "course.txt";
        public const int entryStepNumber = 1;

        private static string currentDirectory = Environment.CurrentDirectory;

        public string name { get; private set; }
        public string gameFolder { get; private set; }
        public string scenesFolder { get; private set; }
        public string courseFile { get; private set; }

        public static Game CurrentGame { get; set; }

        public Scenes scenes { get; set; }
        public Course course { get; set; }

        public Dictionary<int, string> sceneFilePaths { get; }
        public Dictionary<int, string> sceneScripts { get; }
        public List<Choice> choices { get; }
        

        public Game(out List<Game> games)
        {
            games = GamesFromAppSettings();
        }

        public Game(string name, string directory)
        {
            this.name = name;
            sceneFilePaths = new Dictionary<int, string>();
            sceneScripts = new Dictionary<int, string>();
            choices = new List<Choice>();

            BaseGameFileUtil.CheckForDirectories(directory);
            gameFolder = directory;
            scenesFolder = gameFolder + scenesFolderName;
            courseFile = gameFolder + @"\" + courseFileName;
            scenes = new Scenes(this, scenesFolder);
            course = new Course(this, courseFile);

            BaseGameFileUtil.CheckForDirectories(gameFolder);
        }

        private List<Game> GamesFromAppSettings()
        {
            List<Game> result = new List<Game>();
            foreach(string gameName in ConfigurationManager.AppSettings.Keys)
            {
                result.Add(new Game(gameName, ConfigurationManager.AppSettings[gameName]));
            }
            return result;

        }
    }
    public static class GameExtensions
    {
        public static bool SelectGame(this List<Game> games, int gameIndex)
        {
            bool result = false;
            if (games.Count > gameIndex && gameIndex > -1)
            {
                Game.CurrentGame = games?[gameIndex];
                result = true;
            }
            else
            {
                Console.WriteLine("Invalid selection, please try again.");
                Console.Clear();
            }
            return result;
        }

        public static bool SelectGame(this List<Game>games, string gameName)
        {
            bool result = false;
            if (int.TryParse(gameName, out int gameIndex))
            {
                result = games.SelectGame(gameIndex-1);
            }
            else
            {
                Game game = games?.Where(x => x.name == gameName).FirstOrDefault();
                if (game != null)
                {
                    result = games.SelectGame(games.IndexOf(game));
                }
                else
                {
                    Console.WriteLine("Invalid selection, please try again.");
                    Console.Clear();
                }
            }
            return result;
        }
    }
}
