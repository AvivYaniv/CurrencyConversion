using CurrencyConversion.API;
using CurrencyConversion.Context;
using CurrencyConversion.InputHandlers;
using CurrencyConversion.Parsers;
using System;
using System.Collections.Generic;

namespace CurrencyConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code Section
            // Get currency file path
            Console.WriteLine(Messages.ENTER_CURRENCY_FILE_PATH_MESSAGE);
            string strCurrencyFilePath = Console.ReadLine();

            // Read file
            string[] arrCurrencyFileContent = FileHandler.ReadFile(strCurrencyFilePath);

            // If error occured reading file
            if (null == arrCurrencyFileContent)
            {
                Console.WriteLine(Messages.ERROR_READING_FILE_ERROR_MESSAGE);
                Environment.Exit(0);
            }

            // Parse currency format to contexts
            ICollection<CurrencyConversionContext> clcCurrencyConversionContext = CurrencyConversionParser.Parse(arrCurrencyFileContent);

            // Converting amounts 
            foreach (CurrencyConversionContext cccCurrencyConversionContext in clcCurrencyConversionContext)
            {
                double dResult = CurrencyConversionAPI.Convert(cccCurrencyConversionContext);
                Console.WriteLine(dResult);
            }
        }
    }
}
