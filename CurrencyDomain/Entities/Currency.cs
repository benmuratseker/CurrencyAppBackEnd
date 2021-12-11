namespace CurrencyDomain.Entities
{
    public class Currency
    {
        public string BaseCurrency { get; set; }
        public string BaseName { get; set; }
        public string TargetCurrency { get; set; }
        public string TargetName { get; set; }
        public double ExchangeRate { get; set; }
        public double InverseRate { get; set; }
    }
}
