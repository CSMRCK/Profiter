using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.FileSystemGlobbing;
using Newtonsoft.Json.Linq;

namespace ProfiterAPI.Extensions
{
    public static class Helper
    {
        //public static string GetCurrencyName<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        //{
        //    return dictionary.Keys.First().ToString();
        //}
        public static decimal GetCurrencyPrice(this IDictionary<string, decimal> dictionary)
        {
            decimal result = dictionary.FirstOrDefault().Value;
            return result;
        }
    }
}
