using CurrencyConversionProgram.Context;
using CurrencyConversionProgram.CurrencyConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversionUnitTest.CurrencyConvertion
{
    [TestClass]
    public class CurrencyConverterByAPITest
    {
        #region Convertion Tests Section

        [TestMethod]
        public void TestConvertion()
        {
            // Code Section
            // Mock default exchange rate
            Mock<CurrencyConverterByAPI> mock_ccCurrencyConverterByAPI = new Mock<CurrencyConverterByAPI>();
            mock_ccCurrencyConverterByAPI.Setup(x => x.GetExchangeRate(It.IsAny<CurrencyConversionContext>())).Returns(TestConstants.DEFAULT_EXCHANGE_RATE);

            // Convert
            double dConversionResult = mock_ccCurrencyConverterByAPI.Object.Convert(TestConstants.DEFAULT_CURRENCY_CONVERSION_CONTEXT);

            // Assert
            Assert.AreEqual(TestConstants.DEFAULT_AMOUNT * TestConstants.DEFAULT_EXCHANGE_RATE, dConversionResult);
        }

        #endregion
    }
}
