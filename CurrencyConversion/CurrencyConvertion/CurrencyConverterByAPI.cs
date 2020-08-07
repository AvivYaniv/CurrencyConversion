using CurrencyConversionProgram.API;
using CurrencyConversionProgram.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversionProgram.CurrencyConversion
{
    public class CurrencyConverterByAPI : ICurrencyConvertion
    {
        protected IExchangeRateFetcher m_erfExchangeRateFetcher;

        public CurrencyConverterByAPI()
        {
            this.m_erfExchangeRateFetcher = new ExchangeRateFetcherByAPI();
        }

        public virtual double GetExchangeRate(CurrencyConversionContext cccCurrencyConversionContext)
        {
            // Get exchnange rate
            return this.m_erfExchangeRateFetcher.GetExchangeRate(cccCurrencyConversionContext);
        }

        public double Convert(CurrencyConversionContext cccCurrencyConversionContext)
        {
            // Code Section
            // Return exchange response
            return cccCurrencyConversionContext.Amount * this.GetExchangeRate(cccCurrencyConversionContext);
        }
    }
}
