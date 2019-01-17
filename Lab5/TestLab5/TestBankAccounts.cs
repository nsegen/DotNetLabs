using Lab5.collection;
using Lab5.model;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        private BankAccount depositAccount;
        private BankAccount savingAccount1;
        private BankAccount savingAccount2;
        private UserAccounts accounts;

        [SetUp]
        public void Setup()
        {
            depositAccount = new DepositAccount(100, 16345, "Vasya", 2, 2.1);
            savingAccount1 = new SavingAccount(100, 12345, "Vasya", 3);
            savingAccount2 = new SavingAccount(100, 12340, "Vasya", 3);

            accounts = new UserAccounts();
            accounts.UserName = "Vasya";
            accounts.AddAccount(depositAccount);
            accounts.AddAccount(savingAccount1);
            accounts.AddAccount(savingAccount2);
        }

        [Test]
        public void Test_DepositReplenishment()
        {
            try
            {
                depositAccount.ReplenishAmount(100);
            }
            catch (NotSupportedException ex)
            {
                Assert.AreEqual("For this type of account replenishment is not allowed", ex.Message);
            }
            catch (Exception ex)
            {
                // not the right kind of exception
                Assert.Fail();
            }
        }

        [Test]
        public void Test_DepositWitdraw()
        {
            try
            {
                depositAccount.WithdrawAmount(30);
            }
            catch (NotSupportedException ex)
            {
                Assert.AreEqual("For this type of account withdrawal is not allowed", ex.Message);
            }
            catch (Exception ex)
            {
                // not the right kind of exception
                Assert.Fail();
            }
        }

        [Test]
        public void Test_SavingWitdraw()
        {
            savingAccount1.WithdrawAmount(30);
            decimal expectedAmount = 70;
            Assert.AreEqual(expectedAmount, savingAccount1.MoneyAmount);
        }

        [Test]
        public void Test_SavingWitdraw_Negative()
        {
            try
            {
                savingAccount1.WithdrawAmount(15000);
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Sorry, you cannot withdraw more than you have", ex.Message);
            }
            catch (Exception ex)
            {
                // not the right kind of exception
                Assert.Fail();
            }
        }

        [Test]
        public void Test_SavingReplenishment()
        {
            savingAccount1.ReplenishAmount(30);
            decimal expectedAmount = 130;
            Assert.AreEqual(expectedAmount, savingAccount1.MoneyAmount);
        }

        [Test]
        public void Test_AccountBlocking()
        {
            savingAccount1.BlockAccount();
            bool expectedBlocking = true;
            Assert.AreEqual(expectedBlocking, savingAccount1.IsBlocked);
        }

        [Test]
        public void Test_FindAccountByNumber()
        {
            BankAccount actualRresult = accounts.FindAccountByNumber(12340);
            BankAccount expected = savingAccount2;
            Assert.AreEqual(expected, actualRresult);
        }

        [Test]
        public void Test_CalculateAllAccountsSum()
        {
            decimal actualRresult = accounts.CalculateAllAccountsSum();
            decimal expected = 300;
            Assert.AreEqual(expected, actualRresult);
        }
    }
}