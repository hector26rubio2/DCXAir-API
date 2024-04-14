using Domain.Enums;

namespace Infrastructure.Helpers
{
    public class CurrencyConverter
    {
        private static readonly Dictionary<CurrencyType, double> ConversionRates = new Dictionary<CurrencyType, double>
    {
        { CurrencyType.Dolar, 1 },
        { CurrencyType.Euro, 0.83 },
        { CurrencyType.Peso, 20.08 }
    };

        public static double Convert(double amount, CurrencyType toCurrency)
        {

            double toRate = ConversionRates[toCurrency];

 
            return amount * toRate;
        }
    }
}
