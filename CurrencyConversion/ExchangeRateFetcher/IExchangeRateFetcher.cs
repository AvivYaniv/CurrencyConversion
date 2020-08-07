using CurrencyConversionProgram.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversionProgram.API
{
    public interface IExchangeRateFetcher
    {
        public double GetExchangeRate(CurrencyConversionContext cccCurrencyConversionContext);        
    }
}
