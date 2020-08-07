using CurrencyConversionProgram.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversionProgram.CurrencyConversion
{
    interface ICurrencyConvertion
    {
        public double Convert(CurrencyConversionContext cccCurrencyConversionContext);
    }
}
