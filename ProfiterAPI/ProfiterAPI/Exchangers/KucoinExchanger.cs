using Kucoin.Net.Clients;
using Kucoin.Net.Objects;
using ProfiterAPI.Clients;
using System.Collections.Concurrent;

namespace ProfiterAPI.Exchangers
{
    public class KucoinExchanger : Exchanger
    {
        KucoinCli kucoin;
        public KucoinExchanger()
        {
            kucoin = new KucoinCli();
        }
        public override async Task<decimal> GetOutputAmount(decimal inputAmount = 1, string inputCurrency = "BTC", string outputCurrency = "USD")
        {
            try
            {
                decimal kucoinCurrencyValue = await this.GetCurrency(inputCurrency, outputCurrency);
                //TODO: Handle multiply by zero
                decimal resultOutputAmount = inputAmount * kucoinCurrencyValue;
                return resultOutputAmount;

            }
            catch (Exception)
            {
                // TODO: Handle Exception
                return 0;
            }
        }
        public override async Task<decimal> GetCurrency(string inputCurrency, string outputCurrency)
        {
            try
            {
                var response = await kucoin.client.SpotApi.ExchangeData.GetTickerAsync(inputCurrency + "-" + outputCurrency);
                if(response.Data == null)
                {
                    return 0;
                }
                decimal? value = response.Data.LastPrice;
                return (decimal)value;

            }
            catch (Exception)
            {
                //TODO: Handle an exception
                return 0;
            }
        }

        public override string ToString()
        {
            return "Kucoin";
        }
    }
}
