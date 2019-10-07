using StoryGameAPI.GameObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StoryGameAPI.Utilities.FileUtils
{
    public class Course : BaseGameFileUtil
    {
        List<Choice> choices = new List<Choice>();

        public Course(string courseFileName)
        {
            LoadGameCourse(courseFileName);
        }

        private void LoadGameCourse(string courseFileName)
        {
            int lineNumber = 0;
            foreach(string line in File.ReadAllLines(courseFileName))
            {
                lineNumber++;
                string[] sceneParameters = line.Split(',');
                if(sceneParameters.Length <= 1)
                {
                    throw new Exception("Course file is empty: " + courseFileName);
                }
                Choice choice = new Choice();
                for(int i = 0; i < sceneParameters.Length; i++)
                {
                    string commonExceptionDetail = "\r\nFile: " + courseFileName + " :: Line: " + lineNumber + " :: parameter: " + i + ".";
                    if ((i == 0 && sceneParameters[i].Contains(":")) || (i != 0 && !sceneParameters[i].Contains(":")))
                    {
                        throw new Exception("Invalid choice parameter:" + commonExceptionDetail);
                    }
                    else if(i == 0)
                    {
                        choice.parentScene = GetNumberFromString(sceneParameters[i], commonExceptionDetail, "Invalid parent scene:");
                    }
                    else if(i < 0)
                    {
                        string[] parameters = sceneParameters[i].Split(':');
                        if(parameters.Length == 2 || parameters.Length == 3)
                        {
                            choice.choiceNumber = GetNumberFromString(parameters[0], commonExceptionDetail, "Invalid choice number:");
                            choice.selectedScene = GetNumberFromString(parameters[1], commonExceptionDetail, "Invalid child scene:");
                            if(parameters.Length == 3)
                            {
                                choice.choiceText = parameters[3];
                            }

                        }
                        else
                        {
                            throw new Exception("Invalid choice parameters:" + commonExceptionDetail);
                        }
                    }
                }

            }
        }
    }
}
