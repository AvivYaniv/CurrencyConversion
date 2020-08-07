using CurrencyConversionProgram.Context;
using CurrencyConversionProgram.InputHandlers;
using CurrencyConversionProgram.Parsers;
using CurrencyConversionProgram.CurrencyConversion;
using System;
using System.Collections.Generic;

namespace CurrencyConversionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Varaible Section
            ICurrencyConvertion         ccCurrencyConverter         = new CurrencyConverterByAPI();
            ICurrencyConversionParser   ccpCurrencyConversionParser = new CurrencyConversionParser();

            // Code Section
            // Get currency file path
            Console.WriteLine(Messages.ENTER_CURRENCY_FILE_PATH_MESSAGE);
            string strCurrencyFilePath = Console.ReadLine();

            // Read file
            string[] arrCurrencyFileContent = FileHandler.ReadFile(strCurrencyFilePath);
            
            // Parse currency format to contexts
            ICollection<CurrencyConversionContext> clcCurrencyConversionContext = ccpCurrencyConversionParser.Parse(arrCurrencyFileContent);

            // Converting amounts 
            foreach (CurrencyConversionContext cccCurrencyConversionContext in clcCurrencyConversionContext)
            {
                double dResult = ccCurrencyConverter.Convert(cccCurrencyConversionContext);
                Console.WriteLine(dResult);
            }
        }
    }
}
