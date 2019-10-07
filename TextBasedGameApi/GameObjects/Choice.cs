using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextBasedGameApi.GameObjects
{
    public class Choice
    {
        public int step { get; set; }
        public int parentScene { get; set; }
        public int choiceNumber { get; set; }
        public int choiceTargetStep { get; set; }
        public string choiceStatement { get; set; }
        public int selectedScene { get; set; }


        
    }
    public static class ChoiceExtensions
    {
        public static List<Choice> GetSortedChoicesForStep(this List<Choice> choices, int stepNumber)
        {
            List<Choice> result = choices.Where(x => x.step == stepNumber).ToList();
            
            return result.OrderBy(x=>x.choiceNumber).ToList();
            
        }

        public static Choice GetChoice(this List<Choice> choices, int stepNumber)
        {
            Choice result = choices.Where(x => x.step == stepNumber).FirstOrDefault();
            if(result == null)
            {
                throw new Exception("Unimplimented step requested: " + stepNumber);
            }
            return result;
        }

        public static Choice GetChoiceBySelectedChoiceNumber(this List<Choice> choices, int stepNumber, int selectedChoiceNumber)
        {
            Choice result = choices.Where(x => x.step == stepNumber && x.choiceNumber == selectedChoiceNumber).FirstOrDefault();
            if (result == null)
            {
                throw new Exception("Unimplimented choice requested - Step: " + stepNumber + " Choice: " + selectedChoiceNumber);
            }
            return result;
        }

        public static bool ChoiceContainsSelectedChoiceNumber(this List<Choice> choices, int selectedChoiceNumber)
        {
            return choices.Any(x => x.choiceNumber == selectedChoiceNumber);
        }
    }
}
