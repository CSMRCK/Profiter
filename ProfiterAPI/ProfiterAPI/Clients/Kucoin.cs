using Kucoin.Net.Clients;
using Kucoin.Net.Objects;

namespace ProfiterAPI.Clients
{
    public class KucoinCli
    {
        //move to secrets
        private readonly string API_KEY = "63b353ea80ec38000154dc15";
        private readonly string API_PASSPHRASE = "TrainWreck";
        private readonly string API_SECRET = "42774f01-5eec-4869-9588-5ea6ae733c20";
        public KucoinClient client;
        public KucoinCli()
        {
            client = new KucoinClient(new KucoinClientOptions()
            {
                ApiCredentials = new KucoinApiCredentials(API_KEY, API_SECRET, API_PASSPHRASE),
                LogLevel = LogLevel.Trace,
                FuturesApiOptions = new KucoinRestApiClientOptions
                {
                    ApiCredentials = new KucoinApiCredentials(API_KEY, API_SECRET, API_PASSPHRASE),
                    AutoTimestamp = false
                }
            });
        }
    }
}
