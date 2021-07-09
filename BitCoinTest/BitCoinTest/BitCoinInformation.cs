using System;
namespace BitCoinTest
{
    public class BitCoinInformation
    {
        public string CurrentPrice { get; }
        public string Currency { get; }
        
        public BitCoinInformation(string currentPrice, string currency)
        {
            if(string.IsNullOrWhiteSpace(currentPrice))
            {
                throw new ArgumentNullException($"Cannot display null/whitespace {nameof(CurrentPrice)}, Currently = {currentPrice}");
            }

            if (string.IsNullOrWhiteSpace(currentPrice))
            {
                throw new ArgumentNullException($"Cannot display null/whitespace {nameof(Currency)}, Currently = {currency}");
            }

            CurrentPrice = currentPrice;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"BTC Price {Currency} {CurrentPrice}.";
        }

    }
}
