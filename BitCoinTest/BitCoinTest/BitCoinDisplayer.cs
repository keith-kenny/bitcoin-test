using System;
using BitCoinTest.HTTPHandler;
using BitCoinTest.JSONHandler;
namespace BitCoinTest
{
    public class BitCoinDisplayer
    {
        private readonly IHttpRequester _bitCoinHttpHandler;

        public BitCoinDisplayer(IHttpRequester bitCoinHttpHandler)
        {
            if(bitCoinHttpHandler == null)
            {
                throw new ArgumentNullException($"Cannot use a null HttpHandler");
            }

            _bitCoinHttpHandler = bitCoinHttpHandler;
        }

        public void GetAndDisplayBitCoinPrice()
        {
            var currentBitCoinInfo = GetCurrentBitCoinPrice();
            DisplayBitCoinPrice(currentBitCoinInfo);
        }

        private BitCoinInformation GetCurrentBitCoinPrice()
        {
            var currentInformationAsString =_bitCoinHttpHandler.GetRequest();
            var currentInformation = BitCoinJsonParser.ParseStringToBitCoinInformation(currentInformationAsString);
            return currentInformation;
        }

        private void DisplayBitCoinPrice(BitCoinInformation bitCoinInformation)
        {
            if (bitCoinInformation != null)
            {
                Console.Clear();
                Console.WriteLine(bitCoinInformation.ToString());
            }
        }
    }
}
