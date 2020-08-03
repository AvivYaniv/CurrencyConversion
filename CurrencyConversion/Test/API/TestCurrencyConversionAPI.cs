using CurrencyConversion.API;
using CurrencyConversion.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Test.API
{
    [TestClass]
    class TestCurrencyConversionAPI
    {
        [TestMethod]
        public void ShouldReturnTestString()
        {
            CurrencyConversionContext cccCurrencyConversionContext = new CurrencyConversionContext("USD", "ILS", 1);
            double dExchangeRate = CurrencyConversionAPI.GetExchangeRate(cccCurrencyConversionContext);

            //Assert
            Assert.AreEqual("test", "sabich");
        }
    }
}
