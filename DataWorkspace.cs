using System;
using System.IO;

namespace GeniusIdiotConsoleApp
{
    static public class DataWorkspace 
    {
        public static string GetValue(string path)
        {
            StreamReader resultsReader = new StreamReader(path);
            var results = resultsReader.ReadToEnd();
            resultsReader.Close();
            return results;
        }
        public static void Replace(string path, string value)
        {
            var writer = new StreamWriter(path, false);
            writer.WriteLine(value);
            writer.Close();
        }
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}