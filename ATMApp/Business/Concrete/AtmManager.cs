using ATMApp.Business.Abstract;
using ATMApp.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Business.Concrete
{
    public class AtmManager : IAtmService
    {
        private IUserService _userService;

        public AtmManager(IUserService userService)
        {
            _userService = userService;
        }

        public void BalanceInquiry(User user)
        {
            Console.WriteLine("{0} TL bakiyeniz bulunmaktadır.",user.AccountBalance);
        }

        public User Login()
        {
            byte meter = 0;
            Login:
            Console.Write("Lütfen şifrenizi giriniz :");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(password) || !_userService.GetAll().Any(u=>u.Password==password))
            {
                Console.WriteLine("Şifre hatalı! Girişe yönlendiriliyorsunuz..." );
                Thread.Sleep(1000);
                meter++;
                if (meter == 3 )
                {
                    Console.WriteLine("Hatalı giriş limiti aşıldı programı kapatmak için bir tuşa basınız...");
                    Process.GetCurrentProcess().Kill();
                }
                goto Login;
            }
            return _userService.GetByPassword(password);
        }

        public void Remitment(User sender)
        {
            var amount = CheckEnteredAmountForUser(sender);

            Console.Write("Lütfen para göndermek istediğiniz hesap numarasını giriniz : ");
            string accountNo = Console.ReadLine();
            User receiver = _userService.GetByAccountNo(accountNo);
            if (string.IsNullOrEmpty(accountNo) || receiver==null)
            {
                Console.WriteLine("Lütfen geçerli bir hesap numarası giriniz!");
            }

            var lastBalanceOfSender = sender.AccountBalance - amount;

            Console.WriteLine("Para gönderme işleminiz başarılıdır! Kalan bakiyeniz: {0} TL", lastBalanceOfSender);
        }

        public void Withdrawal(User user)
        {

            var amount = CheckEnteredAmountForUser(user);

            var lastBalance = user.AccountBalance - amount;

            Console.WriteLine("Para çekme işlemi başarılı! Kalan bakiyeniz : {0} TL", lastBalance);

        }

        private decimal CheckEnteredAmountForUser(User user)
        {
        EnterAmount:
            Console.Write("Lütfen tutarı giriniz : ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(amount.ToString()) || amount <= 0
                || amount.GetType() != typeof(decimal) || amount > user.AccountBalance)
            {
                Console.WriteLine("Lütfen geçerli bir miktar giriniz!");
                goto EnterAmount;
            }
            return amount;
        }
    }
}
