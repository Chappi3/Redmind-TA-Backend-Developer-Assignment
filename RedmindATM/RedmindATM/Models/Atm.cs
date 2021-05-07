using System;

namespace RedmindATM.Models
{
    public class Atm
    {
        public int ThousandAmount { get; set; }
        public int FiveHundredAmount { get; set; }
        public int OneHundredAmount { get; set; }

        public int TotalAmount =>
            (
                (ThousandAmount * 1000) +
                (FiveHundredAmount * 500) +
                (OneHundredAmount * 100)
            );

        public bool Withdraw(int amount)
        {
            if (TotalAmount < amount) return false;

            int numOfThousands = 0, numOfFiveHundreds = 0, numOfOneHundreds = 0;

            while (amount != 0)
            {
                switch (amount)
                {
                    case >= 1000 when ThousandAmount > 0:
                        ThousandAmount--;
                        numOfThousands++;
                        amount -= 1000;
                        break;
                    case >= 500 when FiveHundredAmount > 0:
                        FiveHundredAmount--;
                        numOfFiveHundreds++;
                        amount -= 500;
                        break;
                    case >= 100 when OneHundredAmount > 0:
                        OneHundredAmount--;
                        numOfOneHundreds++;
                        amount -= 100;
                        break;
                    default:
                        ThousandAmount += numOfThousands;
                        FiveHundredAmount += numOfFiveHundreds;
                        OneHundredAmount += numOfOneHundreds;
                        return false;
                }
            }

            Console.WriteLine($"Thousands: {numOfThousands}, Five hundreds: {numOfFiveHundreds}, One hundreds: {numOfOneHundreds}, Atm amount left: {TotalAmount}");
            return true;
        }
    }
}