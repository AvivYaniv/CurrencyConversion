using CurrencyConversion.API;
using CurrencyConversion.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.CurrencyConversion
{
    class CurrencyConversion
    {
        public static double Convert(CurrencyConversionContext cccCurrencyConversionContext)
        {
            return CurrencyConversionAPI.Convert(cccCurrencyConversionContext);
        }
    }
}
