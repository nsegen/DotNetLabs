using Lab5.comparer;
using Lab5.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.collection
{
    public class UserAccounts
    {
        private String userName;
        private List<BankAccount> accounts;

        public UserAccounts()
        {
            this.Accounts = new List<BankAccount>();
        }

        public UserAccounts(String userName, List<BankAccount> accounts)
        {
            this.UserName = userName;
            this.Accounts = accounts;
        }

        public List<BankAccount> Accounts { get => accounts; set => accounts = value; }
        public string UserName { get => userName; set => userName = value; }

        public override bool Equals(object obj)
        {
            var collection = obj as UserAccounts;
            return collection != null &&
                   Accounts.SequenceEqual(collection.Accounts) &&
                   UserName == collection.UserName;
        }

       

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("User name: " + UserName + ", Accounts: ");
            foreach (BankAccount acc in Accounts)
            {
                result.Append(acc.ToString());
                result.Append("/n");
            }
            return result.ToString();
        }

        public void AddAccount(BankAccount acc)
        {
            this.Accounts.Add(acc);
        }

        public decimal CalculateAllAccountsSum()
        {
            decimal result = 0;
            foreach (BankAccount acc in Accounts)
            {
                result += acc.MoneyAmount;
            }
            return result;
        }

        public decimal CalculatePositiveAccountsSum()
        {
            decimal result = 0;
            foreach (BankAccount acc in Accounts)
            {
                if (acc.MoneyAmount >= 0)
                {
                    result += acc.MoneyAmount;
                }
            }
            return result;
        }

        public decimal CalculateNegativeAccountsSum()
        {
            decimal result = 0;
            foreach (BankAccount acc in Accounts)
            {
                if (acc.MoneyAmount < 0)
                {
                    result += acc.MoneyAmount;
                }
            }
            return result;
        }

        public BankAccount FindAccountByNumber(int number)
        {
            BankAccount result = null;
            foreach (BankAccount acc in Accounts)
            {
                if (acc.AccountNumber == number)
                {
                    result = acc;
                    break;
                }
            }
            return result;
        }

        public List<BankAccount> SortAccountByNumber(int number)
        {
            List<BankAccount> result = new List<BankAccount>();
            result.AddRange(Accounts);
            result.Sort(new AccountNumberComparer());
            return result;
        }

        public override int GetHashCode()
        {
            var hashCode = 1932969374;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BankAccount>>.Default.GetHashCode(Accounts);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            return hashCode;
        }
    }
}
