using System;
using RedmindATM.Models;

namespace RedmindATM
{
    class Program
    {
        private static void Main()
        {
            var amountsToWithdraw = new[] { 1500, 700, 400, 1100, 1000, 700, 300 };

            Atm atm = new()
            {
                ThousandAmount = 2,
                FiveHundredAmount = 3,
                OneHundredAmount = 5
            };
            
            foreach (var amount in amountsToWithdraw)
            {
                Console.WriteLine($"Atm amount: {atm.TotalAmount}");
                Console.WriteLine($"Withdraw: {amount}");
                var response = atm.Withdraw(amount);

                PrintResponse(response);
            }
        }

        private static void PrintResponse(AtmWithdrawResponse response)
        {
            Console.ForegroundColor = response.IsSuccessful ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(response.IsSuccessful ? "Success" : "Failed");
            Console.ResetColor();
            Console.WriteLine($": {response.Message}");

            if (response.FiveHundredBills <= 0 && response.OneHundredBills <= 0 && response.ThousandBills <= 0)
            {
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Received bills:");
            if (response.ThousandBills > 0)
            {
                Console.WriteLine(response.ThousandBills + " x 1000");
            }

            if (response.FiveHundredBills > 0)
            {
                Console.WriteLine(response.FiveHundredBills + " x 500");
            }

            if (response.OneHundredBills > 0)
            {
                Console.WriteLine(response.OneHundredBills + " x 100");
            }

            Console.WriteLine();
        }
    }
}
