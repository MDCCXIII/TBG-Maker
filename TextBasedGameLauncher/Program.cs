using System;
using System.Collections.Generic;
using TextBasedGameApi;
using TextBasedGameApi.GameObjects;
using TextBasedGameApi.ProcessManagement;
using TextBasedGameApi.Utilities.ConsoleUtils;

namespace TextBasedGameLauncher
{
    class Program
    {
        static List<Game> games;
        static void Main()
        {
            _=new Game(out games);
            while (true)
            {
                PromptUserForGameSelection();

                Choice entryStep = Game.CurrentGame.choices.GetChoice(Game.entryStepNumber);

                ChoiceProcessor.ProcessChoice(entryStep);
            }
        }

        private static void PromptUserForGameSelection()
        {
            do {
                
                ConsoleOutputUtils.slowWrite("Please select a game: ", endWithNewLine:true);
                int gameNumber = 1;
                foreach (Game game in games)
                {
                    ConsoleOutputUtils.slowWrite(gameNumber + ". " + game.name, endWithNewLine: true);
                    gameNumber++;
                }
            }
            while(!games.SelectGame(ConsoleInputUtils.PromptUser()));
        }

        private static void TestLoadScenes()
        {
            //Console.WriteLine("From Scene file: " + games[0].sceneFilePaths[1]);
            
            ConsoleOutputUtils.slowWrite(Game.CurrentGame.sceneScripts[1],1,1,true);
        }
    }
}
