using System;
using System.Text.Json;

namespace BitCoinTest.JSONHandler
{
    public static class BitCoinJsonParser
    {
        public static BitCoinInformation ParseStringToBitCoinInformation(string bitCoinJson)
        {
            BitCoinResponse bitCoinResponse = JsonSerializer.Deserialize<BitCoinResponse>(bitCoinJson);
            BitCoinInformation bitCoinInformation = new BitCoinInformation(bitCoinResponse.bpi.EUR.rate, bitCoinResponse.bpi.EUR.code);
            return bitCoinInformation;
        }
    }
}
