using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StoryGameAPI.GameObjects
{
    public class Choice
    {
        public int parentScene { get; set; }
        public int choiceNumber { get; set; }
        public string choiceText { get; set; }
        public int selectedScene { get; set; }


        
    }
    public static class ChoiceExtensions
    {
        public static List<Choice> GetSortedChoicesForScene(this List<Choice> choices, int sceneNumber)
        {
            List<Choice> result = choices.Where(x => x.parentScene == sceneNumber).ToList();
            return result.OrderBy(x=>x.choiceNumber).ToList();
        }
    }
}
