using CurrencyConversion.Context;
using CurrencyConversion.Parsers;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CurrencyConversion.API
{
    class CurrencyConversionAPI
    {
        // Members Decleration
        protected static WebClient m_webClient = new WebClient();

        protected static string DispatchGetAPI(string strURL)
        {
            return m_webClient.DownloadString(strURL);
        }
        
        public static double Convert(CurrencyConversionContext cccCurrencyConversionContext)
        {
            // Constant definition
            const string EXCHANGE_RATE_HEADER = "rates";

            // Code Section
            // Build convertion URL
            string strConversionStringURL =
                $"https://api.exchangeratesapi.io/latest?symbols={cccCurrencyConversionContext.DestinationCurrency}&base={cccCurrencyConversionContext.SourceCurrency}";

            // Get API response
            string strResponse = CurrencyConversionAPI.DispatchGetAPI(strConversionStringURL);

            // Convert API response to object
            dynamic jsonResponse = JsonParser.Parse(strResponse);

            // Get exchnange rate
            double dExchangeRate = (float)(jsonResponse[EXCHANGE_RATE_HEADER][$"{cccCurrencyConversionContext.DestinationCurrency}"]);

            // Return exchange response
            return cccCurrencyConversionContext.Amount * dExchangeRate;
        }
    }
}
