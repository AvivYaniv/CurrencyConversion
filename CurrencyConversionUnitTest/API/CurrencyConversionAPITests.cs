using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using CurrencyConversion.API;
using CurrencyConversion.Context;
using System.Diagnostics;
using System.Net;
using CurrencyConversion.Parsers;

namespace CurrencyConversionUnitTest.Test.API
{
    [TestClass]
    public class CurrencyConversionAPITests
    {
        public static string                    DEFAULT_SOURCE_CURRENCY             = "USD";
        public static string                    DEFAULT_DESTINATION_CURRENCY        = "ILS";
        public static int                       DEFAULT_AMOUNT                      = 5;

        public static CurrencyConversionContext DEFAULT_CURRENCY_CONVERSION_CONTEXT = new CurrencyConversionContext(DEFAULT_SOURCE_CURRENCY, DEFAULT_DESTINATION_CURRENCY, DEFAULT_AMOUNT);

        [TestMethod]
        public void TestConvertion()
        {
            // Code Section
            // Get exchange rate
            CurrencyConversionContext cccCurrencyConversionContext = DEFAULT_CURRENCY_CONVERSION_CONTEXT;
            double dExchangeRate                                   = CurrencyConversionAPI.GetExchangeRate(cccCurrencyConversionContext);

            // Convert
            double dConversionResult                               = CurrencyConversionAPI.Convert(cccCurrencyConversionContext);

            // Assert
            Assert.AreEqual(DEFAULT_AMOUNT * dExchangeRate, dConversionResult);
        }

        [TestMethod]
        public void TestExchangeRate()
        {
            // Constant definition
            const string EXCHANGE_RATE_HEADER = "rates";

            // Variable Decleration
            WebClient webClient = new WebClient();

            // Code Section
            // Build convertion URL
            string strConversionStringURL =
                $"https://api.exchangeratesapi.io/latest?" +
                $"symbols={DEFAULT_DESTINATION_CURRENCY}&" +
                $"base={DEFAULT_SOURCE_CURRENCY}";

            // Get API response
            string strResponse = webClient.DownloadString(strConversionStringURL);

            // Convert API response to object
            dynamic jsonResponse = JsonParser.Parse(strResponse);

            // Get exchnange rate
            double dExpectedExchangeRate = (float)(jsonResponse[EXCHANGE_RATE_HEADER][$"{DEFAULT_DESTINATION_CURRENCY}"]);

            // Assert
            Assert.AreEqual(dExpectedExchangeRate, CurrencyConversionAPI.GetExchangeRate(DEFAULT_CURRENCY_CONVERSION_CONTEXT));
        }
    }
}
