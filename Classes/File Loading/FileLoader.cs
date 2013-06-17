using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NotJustSokoban
{
    public static class FileLoader
    {
        public static string Load(string fileName, string fileType = "txt", string filePath = "")
        {
            string file = filePath + fileName + fileType;
            string fileBody = "";

            if (Directory.Exists(filePath))
            {
                if (File.Exists(file))
                {
                    StreamReader fileReader = new StreamReader(file);

                    using (fileReader)
                    {
                        fileBody = fileReader.ReadToEnd();
                    }

                    return fileBody;
                }
                else
                {
                    throw new FileNotFoundException(string.Format("File '{0}' was not found in directory '{1}'", (fileName + fileType), filePath));
                }
            }
            else
            {
                throw new DirectoryNotFoundException(string.Format("Directory '{0}' not found", filePath));
            }
        }
    }
}
