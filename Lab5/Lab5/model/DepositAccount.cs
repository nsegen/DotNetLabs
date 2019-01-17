using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.model
{
    public class DepositAccount : BankAccount
    {
        private double percent;
        private int period; // in monthes

        public DepositAccount() : base()
        {
            IsReplenishmentAndWithdrawalAllowed = false;
        }

        public DepositAccount(decimal moneyAmount, int accountNumber, string userName, int period, double percent) : base(moneyAmount, accountNumber, userName)
        {
            IsReplenishmentAndWithdrawalAllowed = false;
            Percent = percent;
            Period = period;
        }

        public double Percent { get => percent; set => percent = value; }
        public int Period { get => period; set => period = value; }

        public override bool Equals(object obj)
        {
            var account = obj as DepositAccount;
            return account != null &&
                   base.Equals(obj) &&
                   Percent == account.Percent &&
                   Period == account.Period;
        }

        public override int GetHashCode()
        {
            var hashCode = 1054278964;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Percent.GetHashCode();
            hashCode = hashCode * -1521134295 + Period.GetHashCode();
            return hashCode;
        }

        public override void ReplenishAmount(decimal amount)
        {
            throw new NotSupportedException("For this type of account replenishment is not allowed");
        }

        public override void WithdrawAmount(decimal amount)
        {
            throw new NotSupportedException("For this type of account withdrawal is not allowed");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
