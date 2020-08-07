using CurrencyConversionProgram.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversionProgram.Parsers
{
    interface ICurrencyConversionParser
    {
        public ICollection<CurrencyConversionContext> Parse(string[] arrCurrencyConversionFormat);
    }
}
