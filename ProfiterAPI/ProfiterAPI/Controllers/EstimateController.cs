using Microsoft.AspNetCore.Mvc;
using ProfiterAPI.Exchangers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProfiterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        // GET: api/<CheckController>
        KucoinExchanger kucoin = new KucoinExchanger();
        BinanceExchanger binance = new BinanceExchanger();

        [HttpGet]
        public async Task<IEnumerable<string>> Get(decimal inputAmount, string inputCurrency, string outputCurrency)
        {
            decimal kucoinRequest = await kucoin.GetOutputAmount(inputAmount, inputCurrency, outputCurrency);
            string kucoinResult = ("exchangeName: Kucoin, outputAmount: " + kucoinRequest);

            decimal binanceRequest = await binance.GetOutputAmount(inputAmount, inputCurrency, outputCurrency);
            string binanceResult = ("exchangeName: Binance, outputAmount: " + binanceRequest);

            if (kucoinRequest == 0 && binanceRequest == 0)
            {
                return new string[] {"No data!"};
            }
            
            else if (kucoinRequest == 0)
            {
                return new string[] { "Kucoin has no data!", binanceResult, "Binance offers better value" };
            }
            else if (binanceRequest == 0)
            {
                return new string[] { kucoinResult, "Binance has no data!", "Kucoin offers better value" };
            }

            if (kucoinRequest < binanceRequest)
            {
                return new string[] { kucoinResult, binanceResult, "Kucoin offers better value" };
            }
            else return new string[] { kucoinResult, binanceResult, "Binance offers better value" };
        }
    }
}
