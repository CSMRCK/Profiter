using Microsoft.AspNetCore.Mvc;
using ProfiterAPI.Exchangers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProfiterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        List<Exchanger> exchangerList = new List<Exchanger>() { new KucoinExchanger(), new BinanceExchanger() };

        [HttpGet]
        public async Task<IEnumerable<string>> Get(decimal inputAmount, string inputCurrency, string outputCurrency)
        {
            List<string> response = new List<string>();
            Dictionary<string, decimal> prices = new Dictionary<string, decimal>();

            foreach (var item in exchangerList)
            {
                var result = await item.GetOutputAmount(inputAmount, inputCurrency, outputCurrency);

                if (result == 0)
                {
                    response.Add($"exchangeName: {item.ToString()} has no data!");
                }
                else
                {
                    response.Add($"exchangeName: {item.ToString()}, outputAmount: " + result);
                    prices.Add(item.ToString(), result);
                }
            }

            if (prices.Any())
            {
                var price = prices.MinBy(p => p.Value);
                string bestPrice = $"Best price has {price.Key} {price.Value}";
                var data = String.Join(", ", response.ToArray());
                return new string[] { data, bestPrice };
            }

            else return new string[] { "No data found!" };

        }
    }
}
