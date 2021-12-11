using CurrencyDomain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CurrencyService
{
    public class ExchangeService:IExchangeService
    {
        private string message;
        public Currency GetCurrency()
        {
            string xmlPath = @"http://www.floatrates.com/daily/usd.xml";
            
            XmlTextReader reader = new XmlTextReader(xmlPath);
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(reader);
            }
            catch(XmlException e)
            {
                message = $"An error occured while getting information from source:{e.Message}";
            }
           
            XmlNodeList currencyListAsXML = document.GetElementsByTagName("item");

            var currencyList = FillCurrencyList(currencyListAsXML);
            
            return currencyList.FirstOrDefault(c => c.BaseCurrency == "USD");
        }
        private List<Currency> FillCurrencyList(XmlNodeList list)
        {
            var currencyList = new List<Currency>();
            foreach (XmlNode item in list)
            {
                var currency = new Currency()
                {
                    BaseCurrency = item["baseCurrency"].InnerText,
                    BaseName = item["baseName"].InnerText,
                    TargetCurrency = item["targetCurrency"].InnerText,
                    TargetName = item["targetName"].InnerText,
                    ExchangeRate = double.Parse(item["exchangeRate"].InnerText),
                    InverseRate = double.Parse(item["inverseRate"].InnerText)
                };
                currencyList.Add(currency);
            }
            return currencyList;
        }
    }
}
