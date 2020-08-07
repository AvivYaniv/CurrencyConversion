using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CurrencyConversionProgram.InputHandlers
{
    class FileHandler
    {
        public static string[] ReadFile(string strFilePath)
        {
            if (!File.Exists(strFilePath))
            {
                return null;
            }

            return File.ReadAllLines(strFilePath);
        }
    }
}
