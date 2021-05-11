using System;
using System.Net.Http;

namespace TestClientAsyncConsoleApp
{
    class Program
    {
        static int _localOperationCounter = 0;
        static int _webAPIOperationCounter = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Click Local press 1");
            Console.WriteLine("Click Local press 2");

            var input = Console.ReadLine();
            while (input != "0")
            {
                if (input == "1")
                    LocalOperation();

                if (input == "2")
                    WebAPICall_Operation();

                input = Console.ReadLine();
            }

            Console.ReadLine();

        }

        public static void LocalOperation()
        {
            _localOperationCounter++;
            AddTextToConsoleScreen($"Fast Local Operation Completed {_localOperationCounter}");
        }

        public static async void WebAPICall_Operation()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:62833/TestLongOperation");

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            _webAPIOperationCounter++;

            AddTextToConsoleScreen($"{result} {_webAPIOperationCounter}");


        }

        private static void AddTextToConsoleScreen(string text)
        {
            Console.WriteLine(text);
        }
    }
}
