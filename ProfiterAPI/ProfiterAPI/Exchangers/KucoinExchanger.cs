using Kucoin.Net.Clients;
using Kucoin.Net.Objects;
using ProfiterAPI.Clients;
using ProfiterAPI.Extensions;
using System.Collections.Concurrent;

namespace ProfiterAPI.Exchangers
{
    public class KucoinExchanger : Exchanger
    {
        KucoinCli kucoin;
        Dictionary<string, decimal> currency = new Dictionary<string, decimal>();
        public KucoinExchanger()
        {
            kucoin = new KucoinCli();
        }
        public override async Task<decimal> GetOutputAmount(decimal inputAmount = 1, string inputCurrency = "BTC", string outputCurrency = "USD")
        {
            try
            {
                decimal kucoinCurrencyValue = await this.GetCurrency(inputCurrency, outputCurrency);
                decimal resultOutputAmount = inputAmount * kucoinCurrencyValue;
                return resultOutputAmount;

            }
            catch (Exception)
            {
                Console.WriteLine("An error occured!");
                return 0;
                // Handel ex
            }
        }
        public override async Task<decimal> GetCurrency(string inputCurrency, string outputCurrency)
        {
            var request = await kucoin.client.SpotApi.ExchangeData.GetFiatPricesAsync(outputCurrency, new List<string>() { inputCurrency });
            foreach (var item in request.Data)
            {
                currency[item.Key] = item.Value;
            }
            decimal value = Helper.GetCurrencyPrice(currency);
            return value;
        }
        public override decimal GetRates(string baseCurrency, string quoteCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
