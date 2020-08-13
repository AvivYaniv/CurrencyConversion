using CurrencyConversionProgram.Context;
using CurrencyConversionProgram.InputHandlers;
using CurrencyConversionProgram.Parsers;
using CurrencyConversionProgram.CurrencyConversion;
using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;

namespace CurrencyConversionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Container Building
            ContainerBuilder                cbContainerBuilder          = new ContainerBuilder();
            
            // Registering Types
            cbContainerBuilder.RegisterType<CurrencyConverterByAPI>().As<ICurrencyConvertion>();
            cbContainerBuilder.RegisterType<CurrencyConversionParser>().As<ICurrencyConversionParser>();

            // Creating Container
            IContainer cContainer                                       = cbContainerBuilder.Build();

            // Depandancy Injection
            ICurrencyConvertion             ccCurrencyConverter         = cContainer.Resolve<ICurrencyConvertion>();      
            ICurrencyConversionParser       ccpCurrencyConversionParser = cContainer.Resolve<ICurrencyConversionParser>();

            // Code Section
            // Get currency file path
            Console.WriteLine(Messages.ENTER_CURRENCY_FILE_PATH_MESSAGE);
            string strCurrencyFilePath = Console.ReadLine();

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
