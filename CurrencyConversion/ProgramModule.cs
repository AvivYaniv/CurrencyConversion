using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CurrencyConversionProgram.Context;
using CurrencyConversionProgram.InputHandlers;
using CurrencyConversionProgram.Parsers;
using CurrencyConversionProgram.CurrencyConversion;

namespace CurrencyConversionProgram
{
    class ProgramModule : Module
    {
        protected override void Load(ContainerBuilder cbContainerBuilder)
        {
            // Registering Types
            cbContainerBuilder.RegisterType<CurrencyConverterByAPI>().As<ICurrencyConvertion>();
            cbContainerBuilder.RegisterType<CurrencyConversionParser>().As<ICurrencyConversionParser>();
        }
    }
}
