using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedGameApi.GameObjects;
using TextBasedGameApi.Utilities.ConsoleUtils;

namespace TextBasedGameApi.ProcessManagement
{
    public class ChoiceProcessor
    {
        public static void ProcessChoice(Choice choice)
        {
            Console.Clear();
            Console.WriteLine("Step: " + choice.step);
            ConsoleOutputUtils.slowWrite(Game.CurrentGame.sceneScripts[choice.parentScene], 1, 1, true);
            List<Choice> sortedChoices = Game.CurrentGame.choices.GetSortedChoicesForStep(choice.step);
            foreach (Choice c in sortedChoices)
            {
                ConsoleOutputUtils.slowWrite(c.choiceNumber + ". " + c.choiceStatement, endWithNewLine: true);
                Console.WriteLine();
            }

            Choice nextStep = null;
            do
            {
                if (int.TryParse(ConsoleInputUtils.PromptUser(), out int selectedChoiceNumber) && sortedChoices.ChoiceContainsSelectedChoiceNumber(selectedChoiceNumber))
                {
                    Choice selectedChoice = Game.CurrentGame.choices.GetChoiceBySelectedChoiceNumber(choice.step, selectedChoiceNumber);
                    nextStep = Game.CurrentGame.choices.GetChoice(selectedChoice.choiceTargetStep);
                }

            } while (nextStep == null);
            ProcessChoice(nextStep);
        }
    }
}
