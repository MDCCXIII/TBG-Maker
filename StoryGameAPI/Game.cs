using StoryGameAPI.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using StoryGameAPI.Utilities.FileUtils;
using System.Collections.Specialized;

namespace StoryGameAPI
{
    public class Game : BaseGameFileUtil
    {
        public const string requiredSceneFileNameAppendage = "Scene";
        public const string scenesFolderName = @"\Scenes";
        public const string courseFileName = "course.txt";

        private static string currentDirectory = Environment.CurrentDirectory;

        public string name { get; private set; }
        public string gameFolder { get; private set; }
        public string scenesFolder { get; private set; }
        public string courseFile { get; private set; }

        public Scenes scenes { get; set; }
        public Course course { get; set; }

        public Dictionary<int, string> sceneFilePaths = new Dictionary<int, string>();
        public Dictionary<int, string> sceneScripts = new Dictionary<int, string>();
        

        public Game(out List<Game> games)
        {
            games = GamesFromAppSettings();
        }

        public Game(string name, string directory)
        {
            this.name = name;
            gameFolder = currentDirectory + directory;
            scenesFolder = gameFolder + scenesFolderName;
            courseFile = gameFolder + @"\" + courseFileName;
            scenes = new Scenes(scenesFolder);
            course = new Course(courseFile);

            CheckForDirectories(gameFolder);
        }

        private List<Game> GamesFromAppSettings()
        {
            List<Game> result = new List<Game>();
            NameValueCollection nameValueCollection = ConfigurationManager.AppSettings;
            foreach(KeyValuePair<string,string> kvp in nameValueCollection)
            {
                result.Add(new Game(kvp.Key, kvp.Value));
            }
            return result;

        }
    }
}
