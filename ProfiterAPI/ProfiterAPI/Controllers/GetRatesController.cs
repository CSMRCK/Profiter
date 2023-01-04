using Microsoft.AspNetCore.Mvc;
using ProfiterAPI.Exchangers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProfiterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetRatesController : ControllerBase
    {
        List<Exchanger> exchangerList = new List<Exchanger>() { new KucoinExchanger(), new BinanceExchanger() };

        // GET: api/<GetRatesController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get(string baseCurrency, string quoteCurrency)
        {
            List<string> response = new List<string>();

            foreach (var item in exchangerList)
            {
                var result = await item.GetCurrency(baseCurrency, quoteCurrency);
                if (result == 0)
                {
                    response.Add($"exchangeName: {item.ToString()} has no data!");
                }
                else response.Add($"exchangeName: {item.ToString()}, rate: " + result);
            }

            return response.ToArray();
        }

    }
}
