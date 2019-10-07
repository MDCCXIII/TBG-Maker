using System;
using System.Collections.Generic;
using System.Text;
using TextBasedGameApi.GameObjects;
using TextBasedGameApi.ProcessManagement;

namespace TextBasedGameApi.Utilities.ConsoleUtils
{
    public static class ConsoleInputUtils
    {
        public static string PromptUser(string promptMessage = "- ")
        {
            ConsoleOutputUtils.slowWrite(promptMessage);
            string result = Console.ReadLine();

            //TODO:: Handle control commands before passing back
            if (result.Contains("--"))
            {
                ProcessCommand(result);
                result = "";
            }


            return result;
        }

        private static void ProcessCommand(string result)
        {
            if (result.Contains("reloadStep-"))
            {
                if (int.TryParse(result.Replace("--reloadStep-", ""), out int stepNumber))
                {
                    Game.CurrentGame.sceneFilePaths.Clear();
                    Game.CurrentGame.sceneScripts.Clear();
                    Game.CurrentGame.scenes = new FileUtils.Scenes(Game.CurrentGame, Game.CurrentGame.scenesFolder);

                    Game.CurrentGame.choices.Clear();
                    Game.CurrentGame.course = new FileUtils.Course(Game.CurrentGame, Game.CurrentGame.courseFile);
                    
                    ChoiceProcessor.ProcessChoice(Game.CurrentGame.choices.GetChoice(stepNumber));
                }
                else
                {
                    Console.WriteLine("Invalid...");
                }
            }
        }
    }
}
