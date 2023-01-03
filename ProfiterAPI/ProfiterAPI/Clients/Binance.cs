using Binance.Spot;

namespace ProfiterAPI.Clients
{
    public class BinanceCli
    {
        public Market market;

        public BinanceCli()
        {
            market = new Market();
        }
    }
}
