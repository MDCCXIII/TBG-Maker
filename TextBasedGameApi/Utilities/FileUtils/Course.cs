using System;
using System.Collections.Generic;
using System.IO;
using TextBasedGameApi.GameObjects;

namespace TextBasedGameApi.Utilities.FileUtils
{
    public class Course
    {
        private Game game;
        public Course(Game game, string courseFileName)
        {
            this.game = game;
            LoadGameCourse(courseFileName);
        }

        private void LoadGameCourse(string courseFileName)
        {
            int lineNumber = 0;
            foreach (string line in File.ReadAllLines(courseFileName))
            {
                lineNumber++;
                if (!line.StartsWith("#", StringComparison.Ordinal))
                {
                    string[] sceneParameters = line.Split(',');
                    if (sceneParameters.Length <= 1)
                    {
                        throw new Exception("Course file is empty: " + courseFileName);
                    }
                    int step = 0;
                    int parentScene = 0;
                    int choiceNumber = 0;
                    for (int i = 0; i < sceneParameters.Length; i++)
                    {
                        string commonExceptionDetail = "\r\nFile: " + courseFileName + " :: Line: " + lineNumber + " :: parameter: " + i + ".";
                        if ((i == 0 && sceneParameters[i].Contains(":")) || (i == 1 && sceneParameters[i].Contains(":")) || (i > 1 && !sceneParameters[i].Contains(":")))
                        {
                            throw new Exception("Invalid choice parameter:" + commonExceptionDetail);
                        }
                        else if (i == 0)
                        {
                            step = BaseGameFileUtil.GetNumberFromString(sceneParameters[i], commonExceptionDetail, "Invalid stepNumber:");
                        }
                        else if (i == 1)
                        {
                            parentScene = BaseGameFileUtil.GetNumberFromString(sceneParameters[i], commonExceptionDetail, "Invalid parentScene:");
                        }
                        else if (i > 1)
                        {
                            Choice choice = new Choice();
                            choice.step = step;
                            choice.parentScene = parentScene;
                            string[] parameters = sceneParameters[i].Split(':');
                            if (parameters.Length == 2)
                            {
                                choice.choiceTargetStep = BaseGameFileUtil.GetNumberFromString(parameters[0], commonExceptionDetail, "Invalid choiceTargetStep:");
                                choice.choiceNumber = ++choiceNumber;
                                choice.choiceStatement = parameters[1];
                            }
                            else
                            {
                                throw new Exception("Invalid choice parameters:" + commonExceptionDetail);
                            }
                            game.choices.Add(choice);
                        }
                    }
                }
            }
        }
    }
}
