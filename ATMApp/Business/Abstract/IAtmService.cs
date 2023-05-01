using ATMApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Business.Abstract
{
    public interface IAtmService
    {
        void Deposit(User user);
        void Withdrawal(User user);
        void Remitment(User sender);
        void BalanceInquiry(User user);
        void EndOfDay();
        User Login();
    }
}
