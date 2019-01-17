using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.model
{
    public class SavingAccount : BankAccount
    {
        private double percentPerMonth;

        public SavingAccount()
        {
        }

        public SavingAccount(decimal moneyAmount, int accountNumber, string userName, double percentPerMonth) : base(moneyAmount, accountNumber, userName)
        {
            IsReplenishmentAndWithdrawalAllowed = false;
            PercentPerMonth = percentPerMonth;
        }

        public double PercentPerMonth { get => percentPerMonth; set => percentPerMonth = value; }

        public override bool Equals(object obj)
        {
            var account = obj as SavingAccount;
            return account != null &&
                   base.Equals(obj) &&
                   PercentPerMonth == account.PercentPerMonth;
        }

        public override int GetHashCode()
        {
            var hashCode = 2041399;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + PercentPerMonth.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void ReplenishAmount(decimal amount)
        {
            MoneyAmount += amount;
        }

        public override void WithdrawAmount(decimal amount)
        {
            if (amount > MoneyAmount)
            {
                throw new InvalidOperationException("Sorry, you cannot withdraw more than you have");
            }
            MoneyAmount -= amount;
        }
    }
}
