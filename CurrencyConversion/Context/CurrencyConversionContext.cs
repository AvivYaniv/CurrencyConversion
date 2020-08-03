using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Context
{
    public class CurrencyConversionContext
    {
        // Members Section
        string  m_strSourceCurrency;
        string  m_strDestinationCurrency;
        double  m_dAmount;

        // Constructor Section
        public CurrencyConversionContext(string strSourceCurrency, string strDestinationCurrency, double dAmount)
        {
            this.m_strSourceCurrency      = strSourceCurrency;
            this.m_strDestinationCurrency = strDestinationCurrency;
            this.m_dAmount                = dAmount;
        }

        // Getter & Setter Section
        public string SourceCurrency
        {
            get { return this.m_strSourceCurrency; }            
        }

        public string DestinationCurrency
        {
            get { return this.m_strDestinationCurrency; }
        }

        public double Amount
        {
            get { return this.m_dAmount; }
        }
    }
}
