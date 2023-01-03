
using ProfiterAPI.Exchangers;

namespace ProfiterAPI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            KucoinExchanger ke = new KucoinExchanger();
            var res = await ke.GetOutputAmount(0.3M,"ETH","USD");
            var res2 = await ke.GetOutputAmount(1.0M,"BTC","USD");
            var res3 = await ke.GetOutputAmount(0.3M,"ETH","EUR");
            Console.WriteLine(res +" " +res2 +" "+ res3);



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