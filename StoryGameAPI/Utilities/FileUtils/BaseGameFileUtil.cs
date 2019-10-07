using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StoryGameAPI.Utilities.FileUtils
{
    public class BaseGameFileUtil
    {
        internal void CheckForDirectories(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                throw new Exception("Missing files in directory " + directory);
            }
        }

        internal int GetNumberFromString(string parameter, string exceptionDetail, string commonExceptionDetail)
        {
            if (!int.TryParse(parameter, out int result))
            {
                throw new Exception(exceptionDetail + commonExceptionDetail);
            }
            return result;
        }
    }
}
