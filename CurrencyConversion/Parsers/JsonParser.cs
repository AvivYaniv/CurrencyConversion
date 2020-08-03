using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConversion.Parsers
{
    class JsonParser
    {
        public static dynamic Parse(string strJSON)
        {
            return JsonConvert.DeserializeObject(strJSON);
        }
    }
}
