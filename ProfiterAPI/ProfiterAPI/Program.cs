
using Kucoin.Net.Clients;
using Kucoin.Net.Objects;
using ProfiterAPI.Exchangers;
using System.Globalization;

namespace ProfiterAPI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            KucoinExchanger ke = new KucoinExchanger();
            //var res = await ke.GetOutputAmount(0.3M, "ETH", "USD");
            //var res2 = await ke.GetOutputAmount(1.0M, "BTC", "USD");
            //var res3 = await ke.GetOutputAmount(0.3M, "ETH", "EUR");
            //Console.WriteLine("Kucoin result:\n"+ "0.3 ETH to USD: " + res + "\n1 BTC to USD: " + res2 + "\n0.3 ETH to EUR: " + res3);

            //var res = await client.SpotApi.ExchangeData.GetTickerAsync("BTC-USDT");
            //decimal? val = res.Data.BestBidPrice;
            //Console.WriteLine(res.Data.BestAskPrice.GetType());
            //decimal s = await ke.GetCurrency("BTC", "USDT");
            //decimal s1 = await ke.GetCurrency("ETH", "USDT");
            //decimal s2 = await ke.GetOutputAmount(0.3M,"BTC", "USDT");
            //Console.WriteLine("Kucoin get currency : " + s + '\n' + s1 + '\n' + s2);

            //BinanceExchanger bb = new BinanceExchanger();
            //var d = await bb.GetOutputAmount(0.3M, "BTC", "ETH");
            //var da = await bb.GetOutputAmount(0.3M, "BTC", "USDT");
            //var dad = await bb.GetOutputAmount(0.3M, "ETH", "EUR");
            //Console.WriteLine("Binance result:\n" + "0.3 ETH to USD: " + d + "\n1 BTC to USD: " + da + "\n0.3 ETH to EUR: " + dad);



            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}