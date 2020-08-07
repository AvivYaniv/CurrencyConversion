using CurrencyConversionProgram.Context;
using CurrencyConversionProgram.Parsers;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CurrencyConversionProgram.API
{
    public class ExchangeRateFetcherByAPI : IExchangeRateFetcher
    {
        // Members Decleration
        protected static WebClient m_webClient = new WebClient();

        protected string DispatchGetAPI(string strURL)
        {
            return m_webClient.DownloadString(strURL);
        }

        public double GetExchangeRate(CurrencyConversionContext cccCurrencyConversionContext)
        {
            // Constant definition
            const string EXCHANGE_RATE_HEADER = "rates";

            // Code Section
            // Build convertion URL
            string strConversionStringURL =
                $"https://api.exchangeratesapi.io/latest?"                      + 
                $"symbols={cccCurrencyConversionContext.DestinationCurrency}&"  + 
                $"base={cccCurrencyConversionContext.SourceCurrency}";

            // Get API response
            string strResponse = this.DispatchGetAPI(strConversionStringURL);

            // Convert API response to object
            dynamic jsonResponse = JsonParser.Parse(strResponse);

            // Get exchnange rate
            double dExchangeRate = (float)(jsonResponse[EXCHANGE_RATE_HEADER][$"{cccCurrencyConversionContext.DestinationCurrency}"]);

            // Return exchange response
            return dExchangeRate;
        }        
    }
}
