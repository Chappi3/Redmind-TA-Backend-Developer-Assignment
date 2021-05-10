namespace RedmindATM.Models
{
    public class AtmWithdrawResponse
    {
        public bool IsSuccessful { get; set; }
        public int ThousandBills { get; set; }
        public int FiveHundredBills { get; set; }
        public int OneHundredBills { get; set; }
        public string Message { get; set; }
    }
}
