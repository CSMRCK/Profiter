using CryptoExchange.Net.Requests;
using Newtonsoft.Json.Linq;
using ProfiterAPI.Clients;
using ProfiterAPI.Models;
using System.Globalization;
using System.Text.Json;

namespace ProfiterAPI.Exchangers
{
    public class BinanceExchanger : Exchanger
    {
        BinanceCli binance;
        CurrencyBinance? currency;
        public BinanceExchanger()
        {
            binance = new BinanceCli();
            currency = new CurrencyBinance();
        }

        public override async Task<decimal> GetOutputAmount(decimal inputAmount, string inputCurrency, string outputCurrency )
        {
            try
            {
                decimal binanceCurrencyValue = await this.GetCurrency(inputCurrency, outputCurrency);
                decimal resultOutputAmount = inputAmount * binanceCurrencyValue;
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
                var response = await binance.market.CurrentAveragePrice(inputCurrency+outputCurrency);
                if (response == null)
                {
                    return 0;
                }
                currency = JsonSerializer.Deserialize<CurrencyBinance>(response);
                decimal convertDecimal = Decimal.Parse(currency?.price, CultureInfo.InvariantCulture);
                return convertDecimal;

            }
            catch (Exception)
            {
                // TODO: Handle Exception
                return 0;
            }
        }

        public override string ToString()
        {
            return "Binance";
        }
    }
}
