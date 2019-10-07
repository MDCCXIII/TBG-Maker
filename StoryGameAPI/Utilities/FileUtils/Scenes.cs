using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StoryGameAPI.Utilities.FileUtils
{
    public class Scenes : BaseGameFileUtil
    {
        public Dictionary<int, string> sceneFilePaths = new Dictionary<int, string>();
        public Dictionary<int, string> scripts = new Dictionary<int, string>();

        public Scenes(string gameDirectory)
        {
            LoadFiles(gameDirectory);
        }

        private void LoadFiles(string directory)
        {
            CheckForDirectories(directory);
            scripts.Clear();
            sceneFilePaths.Clear();
            foreach (string file in Directory.GetFiles(directory).Cast<string>().ToList())
            {
                ValidateSceneFile(file);
            }
        }

        private void ValidateSceneFile(string file)
        {
            ExtractFileInfo(file, out string fileName, out string stringSceneNumber);

            if (!fileName.Contains("-"))
            {
                throw new Exception("File " + fileName + " - Bad naming convention, missing '-' character.");
            }
            else if (!file.Contains(Game.requiredSceneFileNameAppendage))
            {
                throw new Exception("File " + fileName + " - missing '" + Game.requiredSceneFileNameAppendage + "' in the file name.");
            }
            else if (!int.TryParse(stringSceneNumber, out int sceneNumber))
            {
                throw new Exception("File " + fileName + " - missing scene number.");
            }
            else if (scripts.ContainsKey(sceneNumber))
            {
                throw new Exception("Duplicate scene number in scene files. \r\n " + file + "\r\n" + sceneFilePaths[sceneNumber]);
            }
            else
            {
                AddFileToScenes(file, sceneNumber);
            }
        }

        private static void ExtractFileInfo(string file, out string fileName, out string stringSceneNumber)
        {
            fileName = Path.GetFileNameWithoutExtension(file);
            stringSceneNumber = fileName.Replace(Game.requiredSceneFileNameAppendage, "").Substring(0, fileName.IndexOf("-") - Game.requiredSceneFileNameAppendage.Length).Trim();
        }

        private void AddFileToScenes(string file, int sceneNumber)
        {
            scripts.Add(sceneNumber, File.ReadAllText(file));
            sceneFilePaths.Add(sceneNumber, file);
        }
    }
}
