using CurrencyConversionProgram.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversionProgram.Parsers
{
    class CurrencyConversionParser : ICurrencyConversionParser
    {
        public ICollection<CurrencyConversionContext> Parse(string[] arrCurrencyConversionFormat)
        {
            // Variable Definition
            string  strSourceCurrency                                          = arrCurrencyConversionFormat[0];
            string  strDestinationCurrency                                     = arrCurrencyConversionFormat[1];

            // Data Structures Definition
            ICollection<CurrencyConversionContext> lstCurrencyConversionContext = new LinkedList<CurrencyConversionContext>();

            // Code Section
            // Parsing amounts and adding currency convertion contexts
            for (int nAmountIndex = 2; arrCurrencyConversionFormat.Length > nAmountIndex; ++nAmountIndex)
            {
                // Parse amount
                double dAmount = double.Parse(arrCurrencyConversionFormat[nAmountIndex]);

                // Add currency convertion context
                lstCurrencyConversionContext.Add(new CurrencyConversionContext(strSourceCurrency, strDestinationCurrency, dAmount));
            }

            // Return currency conversion list
            return lstCurrencyConversionContext;
        }
    }
}
