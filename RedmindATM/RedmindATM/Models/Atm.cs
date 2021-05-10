namespace RedmindATM.Models
{
    public class Atm
    {
        public int ThousandAmount { get; set; }
        public int FiveHundredAmount { get; set; }
        public int OneHundredAmount { get; set; }

        public int TotalAmount =>
            (
                ThousandAmount * 1000 +
                FiveHundredAmount * 500 +
                OneHundredAmount * 100
            );

        public AtmWithdrawResponse Withdraw(int amount)
        {
            if (TotalAmount < amount) return new AtmWithdrawResponse { IsSuccessful = false, Message = "Atm bill amount is insufficient" };
            if (amount <= 0) return new AtmWithdrawResponse { IsSuccessful = false, Message = $"Can't withdraw {amount}" };

            int numOfThousands = 0, numOfFiveHundreds = 0, numOfOneHundreds = 0, withdrawAmount = amount;

            while (withdrawAmount != 0)
            {
                switch (withdrawAmount)
                {
                    case >= 1000 when ThousandAmount > 0:
                        ThousandAmount--;
                        numOfThousands++;
                        withdrawAmount -= 1000;
                        break;
                    case >= 500 when FiveHundredAmount > 0:
                        FiveHundredAmount--;
                        numOfFiveHundreds++;
                        withdrawAmount -= 500;
                        break;
                    case >= 100 when OneHundredAmount > 0:
                        OneHundredAmount--;
                        numOfOneHundreds++;
                        withdrawAmount -= 100;
                        break;
                    default:
                        ThousandAmount += numOfThousands;
                        FiveHundredAmount += numOfFiveHundreds;
                        OneHundredAmount += numOfOneHundreds;
                        return new AtmWithdrawResponse { IsSuccessful = false, Message = "Failed to withdraw that amount" };
                }
            }

            return new AtmWithdrawResponse
            {
                IsSuccessful = true,
                ThousandBills = numOfThousands,
                FiveHundredBills = numOfFiveHundreds,
                OneHundredBills = numOfOneHundreds,
                Message = $"Successfully withdrew {amount}"
            };
        }
    }
}