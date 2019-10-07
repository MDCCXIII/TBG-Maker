using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextBasedGameApi.Utilities.FileUtils
{
    public class Scenes
    {
        private Game game;

        public Scenes(Game game, string scenesFolder)
        {
            this.game = game;
            LoadFiles(scenesFolder);
        }

        private void LoadFiles(string directory)
        {
            BaseGameFileUtil.CheckForDirectories(directory);
            game.sceneScripts.Clear();
            game.sceneFilePaths.Clear();
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
            else if (game.sceneScripts.ContainsKey(sceneNumber))
            {
                throw new Exception("Duplicate scene number in scene files. \r\n " + file + "\r\n" + game.sceneFilePaths[sceneNumber]);
            }
            else
            {
                AddFileToScenes(file, sceneNumber);
            }
        }

        private static void ExtractFileInfo(string file, out string fileName, out string stringSceneNumber)
        {
            fileName = Path.GetFileNameWithoutExtension(file);
            stringSceneNumber = fileName.Replace(Game.requiredSceneFileNameAppendage, "").Substring(0, fileName.IndexOf("-", StringComparison.Ordinal) - Game.requiredSceneFileNameAppendage.Length).Trim();
        }

        private void AddFileToScenes(string file, int sceneNumber)
        {
            game.sceneScripts.Add(sceneNumber, File.ReadAllText(file));
            game.sceneFilePaths.Add(sceneNumber, file);
        }
    }
}
