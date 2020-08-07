using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using CurrencyConversionProgram.API;
using CurrencyConversionProgram.Context;
using System.Diagnostics;
using System.Net;
using CurrencyConversionProgram.Parsers;
using Moq;

namespace CurrencyConversionUnitTest.Test.API
{
    [TestClass]
    public class ExchangeRateFetcherByAPITests
    {
        #region API Connectivity Tests Section

        [TestMethod]
        public void TestExchangeRateWithConnectivityAPI()
        {
            // Constant definition
            const string EXCHANGE_RATE_HEADER = "rates";

            // Variable Decleration
            WebClient webClient                              = new WebClient();
            IExchangeRateFetcher ccaICurrencyConversionAPI = new ExchangeRateFetcherByAPI();

            // Code Section
            // Build convertion URL
            string strConversionStringURL =
                $"https://api.exchangeratesapi.io/latest?" +
                $"symbols={TestConstants.DEFAULT_DESTINATION_CURRENCY}&" +
                $"base={TestConstants.DEFAULT_SOURCE_CURRENCY}";

            // Get API response
            string strResponse = webClient.DownloadString(strConversionStringURL);

            // Convert API response to object
            dynamic jsonResponse = JsonParser.Parse(strResponse);

            // Get exchnange rate
            double dExpectedExchangeRate = (float)(jsonResponse[EXCHANGE_RATE_HEADER][$"{TestConstants.DEFAULT_DESTINATION_CURRENCY}"]);

            // Assert
            Assert.AreEqual(dExpectedExchangeRate, ccaICurrencyConversionAPI.GetExchangeRate(TestConstants.DEFAULT_CURRENCY_CONVERSION_CONTEXT));
        }

        #endregion
    }
}
