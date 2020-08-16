using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using CurrencyConversionProgram.Context;
using CurrencyConversionProgram.InputHandlers;
using CurrencyConversionProgram.Parsers;
using CurrencyConversionProgram.CurrencyConversion;
using System.Reflection;

namespace CurrencyConversionProgram
{
    class ProgramModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder cbContainerBuilder)
        {
            Assembly asmExecutingAssembly = Assembly.GetExecutingAssembly();

            cbContainerBuilder.RegisterAssemblyTypes(asmExecutingAssembly)
               .Where(t => t.Name.StartsWith("CurrencyConversionParser"))
               .As<ICurrencyConversionParser>();

            cbContainerBuilder.RegisterAssemblyTypes(asmExecutingAssembly)
               .Where(t => t.Name.StartsWith("CurrencyConverter"))
               .As<ICurrencyConvertion>();
        }
    }
}
