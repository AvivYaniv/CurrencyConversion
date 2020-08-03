using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Parsers
{
    public class JsonParser
    {
        public static dynamic Parse(string strJSON)
        {
            return JsonConvert.DeserializeObject(strJSON);
        }
    }
}
