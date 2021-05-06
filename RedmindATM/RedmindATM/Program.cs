using System;
using System.Runtime.InteropServices;

namespace RedmindATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Atm atm = new()
            {
                ThousandAmount = 2,
                FiveHundredAmount = 3,
                OneHundredAmount = 5
            };

            Console.WriteLine(atm.TotalAmount);

            Console.WriteLine("Withdraw 300");
            var isSuccessful = atm.Withdraw(300);
            Console.WriteLine($"Success: {isSuccessful}\n");

        }
    }
}
