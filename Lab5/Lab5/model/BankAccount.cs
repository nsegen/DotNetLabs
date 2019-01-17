using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.model
{
   public abstract class BankAccount
    {
        private decimal moneyAmount;
        private bool isBlocked;
        private int accountNumber;
        private string userName;
        private bool isReplenishmentAndWithdrawalAllowed;
        private DateTime accountOpeningDate;

        public BankAccount()
        {
            MoneyAmount = 0;
            IsBlocked = false;
            AccountOpeningDate = DateTime.Now;
        }

        public BankAccount(int accountNumber, string userName)
        {
            MoneyAmount = 0;
            IsBlocked = false;
            AccountNumber = accountNumber;
            UserName = userName;
            AccountOpeningDate = DateTime.Now;
        }

        public BankAccount(decimal moneyAmount, int accountNumber, string userName)
        {
            MoneyAmount = moneyAmount;
            IsBlocked = false;
            AccountNumber = accountNumber;
            UserName = userName;
            AccountOpeningDate = DateTime.Now;
        }

        public BankAccount(decimal moneyAmount, int accountNumber, string userName, DateTime openindDate)
        {
            MoneyAmount = moneyAmount;
            AccountNumber = accountNumber;
            UserName = userName;
            AccountOpeningDate = openindDate;
        }

        public decimal MoneyAmount { get => moneyAmount; set => moneyAmount = value; }
        public bool IsBlocked { get => isBlocked; set => isBlocked = value; }
        public int AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string UserName { get => userName; set => userName = value; }
        public DateTime AccountOpeningDate { get => accountOpeningDate; set => accountOpeningDate = value; }
        public bool IsReplenishmentAndWithdrawalAllowed { get => isReplenishmentAndWithdrawalAllowed; set => isReplenishmentAndWithdrawalAllowed = value; }


        public abstract void ReplenishAmount(decimal amount);
        public abstract void WithdrawAmount(decimal amount);

        public void BlockAccount()
        {
            IsBlocked = true;
        }

        public void UnblockAccount()
        {
            IsBlocked = false;
        }

        public override bool Equals(object obj)
        {
            var account = obj as BankAccount;
            return account != null &&
                   MoneyAmount == account.MoneyAmount &&
                   IsBlocked == account.IsBlocked &&
                   AccountNumber == account.AccountNumber &&
                   UserName == account.UserName &&
                   AccountOpeningDate == account.AccountOpeningDate &&
                   IsReplenishmentAndWithdrawalAllowed == account.IsReplenishmentAndWithdrawalAllowed;
        }

        public override int GetHashCode()
        {
            var hashCode = -156944985;
            hashCode = hashCode * -1521134295 + MoneyAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + IsBlocked.GetHashCode();
            hashCode = hashCode * -1521134295 + AccountNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + AccountOpeningDate.GetHashCode();
            hashCode = hashCode * -1521134295 + IsReplenishmentAndWithdrawalAllowed.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
