using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedmindATM.Models;

namespace RedmindATMTests
{
    [TestClass]
    public class AtmTests
    {
        [TestMethod]
        public void Withdraw_NegativeAmount_CorrectFailedResponse()
        {
            // Arrange
            Atm atm = new() { ThousandAmount = 1, FiveHundredAmount = 1, OneHundredAmount = 1 };
            const string expectedResponseMessage = "Can't withdraw -1";

            // Act
            var response = atm.Withdraw(-1);

            // Assert
            Assert.IsFalse(response.IsSuccessful);
            Assert.AreEqual(expectedResponseMessage, response.Message);
            Assert.AreEqual(0, response.ThousandBills);
            Assert.AreEqual(0, response.FiveHundredBills);
            Assert.AreEqual(0, response.OneHundredBills);
            Assert.AreEqual(1600, atm.TotalAmount);
        }

        [TestMethod]
        public void Withdraw_ZeroAmount_CorrectFailedResponse()
        {
            // Arrange
            Atm atm = new() { ThousandAmount = 1, FiveHundredAmount = 1, OneHundredAmount = 1 };
            const string expectedResponseMessage = "Can't withdraw 0";

            // Act
            var response = atm.Withdraw(0);

            // Assert
            Assert.IsFalse(response.IsSuccessful);
            Assert.AreEqual(expectedResponseMessage, response.Message);
            Assert.AreEqual(0, response.ThousandBills);
            Assert.AreEqual(0, response.FiveHundredBills);
            Assert.AreEqual(0, response.OneHundredBills);
            Assert.AreEqual(1600, atm.TotalAmount);
        }

        [TestMethod]
        public void Withdraw_LargerAmountThanAtmTotalAmount_CorrectFailResponse()
        {
            // Arrange
            Atm atm = new() { ThousandAmount = 1, FiveHundredAmount = 1, OneHundredAmount = 1 };
            const string expectedResponseMessage = "Atm bill amount is insufficient";

            // Act
            var response = atm.Withdraw(1601);

            // Assert
            Assert.IsFalse(response.IsSuccessful);
            Assert.AreEqual(expectedResponseMessage, response.Message);
            Assert.AreEqual(0, response.ThousandBills);
            Assert.AreEqual(0, response.FiveHundredBills);
            Assert.AreEqual(0, response.OneHundredBills);
            Assert.AreEqual(1600, atm.TotalAmount);
        }

        [TestMethod]
        public void Withdraw_ValidAmount_CorrectSuccessResponse()
        {
            // Arrange
            Atm atm = new() { ThousandAmount = 1, FiveHundredAmount = 1, OneHundredAmount = 1 };
            const string expectedResponseMessage = "Successfully withdrew 1000";

            // Act
            var response = atm.Withdraw(1000);

            // Assert
            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual(expectedResponseMessage, response.Message);
            Assert.AreEqual(1, response.ThousandBills);
            Assert.AreEqual(0, response.FiveHundredBills);
            Assert.AreEqual(0, response.OneHundredBills);
            Assert.AreEqual(600, atm.TotalAmount);
        }

        [TestMethod]
        public void Withdraw_ValidAmountInsufficientAtmBills_CorrectFailedResponse()
        {
            // Arrange
            Atm atm = new() { ThousandAmount = 1, FiveHundredAmount = 1, OneHundredAmount = 0};
            const string expectedResponseMessage = "Failed to withdraw that amount";

            // Act
            var response = atm.Withdraw(300);

            // Assert
            Assert.IsFalse(response.IsSuccessful);
            Assert.AreEqual(expectedResponseMessage, response.Message);
            Assert.AreEqual(0, response.ThousandBills);
            Assert.AreEqual(0, response.FiveHundredBills);
            Assert.AreEqual(0, response.OneHundredBills);
            Assert.AreEqual(1500, atm.TotalAmount);
        }
    }
}
