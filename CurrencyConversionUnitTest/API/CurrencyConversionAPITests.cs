using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using CurrencyConversion.API;
using CurrencyConversion.Context;

namespace CurrencyConversionUnitTest.Test.API
{
    [TestClass]
    public class CurrencyConversionAPITests
    {
        [TestMethod]
        public void TestConvertion()
        {
            // Variable Definition
            int nAmount = 5;

            // Code Section
            // Get exchange rate
            CurrencyConversionContext cccCurrencyConversionContext = new CurrencyConversionContext("USD", "ILS", nAmount);
            double dExchangeRate                                   = CurrencyConversionAPI.GetExchangeRate(cccCurrencyConversionContext);

            // Convert
            double dConversionResult                               = CurrencyConversionAPI.Convert(cccCurrencyConversionContext);

            //Assert
            Assert.AreEqual(nAmount * dExchangeRate, dConversionResult);
        }
    }
}
