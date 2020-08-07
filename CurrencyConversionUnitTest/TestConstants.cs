using CurrencyConversionProgram.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversionUnitTest
{
    class TestConstants
    {
        #region Constatns Definition Section

        public static string                    DEFAULT_SOURCE_CURRENCY             = "USD";
        public static string                    DEFAULT_DESTINATION_CURRENCY        = "ILS";
        public static int                       DEFAULT_AMOUNT                      = 5;
        public static double                    DEFAULT_EXCHANGE_RATE               = 3.5;

        public static CurrencyConversionContext DEFAULT_CURRENCY_CONVERSION_CONTEXT = new CurrencyConversionContext(DEFAULT_SOURCE_CURRENCY, DEFAULT_DESTINATION_CURRENCY, DEFAULT_AMOUNT);

        #endregion
    }
}
