using Lab5.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.comparer
{
    public class AccountNumberComparer : IComparer<BankAccount>
    {
        public int Compare(BankAccount x, BankAccount y)
        {
            return x.AccountNumber.CompareTo(y.AccountNumber);
        }
    }
}
