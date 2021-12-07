using System;
using System.IO;
using System.Net;

namespace BitCoinCalculator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            BitCoinRate currentBitcoin = GetRates();
            Console.WriteLine($"current rate: {currentBitcoin.bpi.EUR.code} {currentBitcoin.bpi.EUR.rate_float}");

            Console.WriteLine("calculate in: EUR/USD/GBP");
            string userChoice = Console.ReadLine();
            Console.WriteLine("enter the amout of bitcoins");
            float userCoins = float.Parse(Console.ReadLine());
            float currentRate = 0;

            if(userChoice == "EUR")
            {
                currentRate = currentBitcoin.bpi.EUR.rate_float;
            }
            float result = currentRate * userCoins;
            Console.WriteLine($"your bitcoins are worth {result} {userChoice}");

            //programm küsib, mitu bitcoini kasutajal on
            //programm küsib, mis valuutas (EUR/USD/GBP) ta arvutab tulemuse
            //programm kuvab tulemuse konsoolis
        }

        public static BitCoinRate GetRates()
        {
            string url = "https://api.coindesk.com/vl/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var WebSteram = webResponse.GetResponseStream();

            BitCoinRate bitcoinData;
            using(var responseReader = new StreamReader (webStream))
            {
                var respone = responseReader.ReadToEnd();
                bitcoinData = JsonConvert.DeserializeObject

            }
        }
    }
}
