using CurrencyConversionProgram.Context;
using CurrencyConversionProgram.InputHandlers;
using CurrencyConversionProgram.Parsers;
using CurrencyConversionProgram.CurrencyConversion;
using System;
using System.Collections.Generic;
using Autofac;

namespace CurrencyConversionProgram
{
    class Program
    {
        static readonly string DEFAULT_FILE_PATH = "convert.txt";

        static void Main(string[] args)
        {
            // Container Building
            ContainerBuilder                cbContainerBuilder          = new ContainerBuilder();

            // Loading Registered Types
            cbContainerBuilder.RegisterModule<ProgramModule>();

            // Creating Container
            IContainer cContainer                                       = cbContainerBuilder.Build();

            // Depandancy Injection
            ICurrencyConvertion             ccCurrencyConverter         = cContainer.Resolve<ICurrencyConvertion>();      
            ICurrencyConversionParser       ccpCurrencyConversionParser = cContainer.Resolve<ICurrencyConversionParser>();

            // Code Section
            // Get currency file path
            Console.WriteLine(Messages.ENTER_CURRENCY_FILE_PATH_MESSAGE);
            string strCurrencyFilePath = Console.ReadLine();

            // Resolve default currency file path
            strCurrencyFilePath = (string.Empty != strCurrencyFilePath) ? strCurrencyFilePath : DEFAULT_FILE_PATH;

            // Read file
            string[] arrCurrencyFileContent = FileHandler.ReadFile(strCurrencyFilePath);
            
            // Parse currency format to contexts
            ICollection<CurrencyConversionContext> clcCurrencyConversionContextList = ccpCurrencyConversionParser.Parse(arrCurrencyFileContent);

            // Converting amounts 
            foreach (CurrencyConversionContext cccCurrencyConversionContextElement in clcCurrencyConversionContextList)
            {
                double dResult = ccCurrencyConverter.Convert(cccCurrencyConversionContextElement);
                Console.WriteLine(dResult);
            }
        }
    }
}
