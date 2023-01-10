using System;
using System.Collections.Generic;
using System.IO;

namespace Helppad.Scripts{

    /// <summary>
    /// Extracts data lines from a file.
    public class ExtractDataLines
    {
        public static void ExtractByLine(string filePath,
        string outputPath,
        string[] headerField,
        string delimiter = ",",
        string[]? ingoreLineStartWith = null){

            // validates headerField
            if (headerField is null || headerField.Length == 0)
            {
                throw new Exception("headerField is empty");
            }

            var lines = File.ReadAllLines(filePath);

            if (null == ingoreLineStartWith)
            {
                ingoreLineStartWith = new string[] { };
            }

            var outputLines = new List<Dictionary<string,string>>();

            foreach (var line in lines)
            {
                var lineFields = line.Split(delimiter);

                if (ingoreLineStartWith.Length > 0)
                {
                    foreach (var ignoreLineStartWith in ingoreLineStartWith)
                    {
                        if (line.StartsWith(ignoreLineStartWith))
                        {
                            continue;
                        }
                    }
                }

                var lineDict = new Dictionary<string, string>();
                
                for (int i = 0; i < headerField.Length; i++){
                    lineDict.Add(headerField[i], lineFields[i]);
                }

                outputLines.Add(lineDict);
            }
        }
    }
}