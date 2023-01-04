namespace ProfiterAPI.Exchangers
{
    public abstract class Exchanger
    {

        public abstract Task<decimal> GetOutputAmount(decimal inputAmount, string inputCurrency, string outputCurrency);
        public abstract Task<decimal> GetCurrency(string inputCurrency, string outputCurrency);

    }
}
