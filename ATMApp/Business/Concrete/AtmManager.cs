using ATMApp.Business.Abstract;
using ATMApp.Business.Utilities.FileProcesses;
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

            Files.WriteToFile(DateTime.UtcNow + " --> " + 
                $"{user.AccountNo} --> {user.AccountBalance} TL bakiyeniz bulunmaktadır.");

        }

        public void Deposit(User user)
        {
            var amount = CheckEnteredAmountForUser(user);

            var lastBalance = user.AccountBalance + amount;

            var message = $"{user.AccountNo} --> Para yatırma işlemi başarılı! Toplam bakiyeniz : {lastBalance} TL"; 

            Console.WriteLine(message);
            Files.WriteToFile(DateTime.UtcNow + " --> " + message  );
        }

        public void EndOfDay()
        {
            Files.ReadFromFile();
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

                Files.WriteToFile($"{DateTime.UtcNow} --> {_userService.GetByAccountNo("null").AccountNo} -->" +
                   $"Şifre hatalı! Girişe yönlendiriliyorsunuz...");

                Thread.Sleep(1000);
                meter++;
                if (meter == 3 )
                {
                    Console.WriteLine("Hatalı giriş limiti aşıldı programı kapatmak için bir tuşa basınız...");

                    Files.WriteToFile($"{DateTime.UtcNow}  --> {_userService.GetByAccountNo("null").AccountNo} -->" +
                        $" Hatalı giriş limiti aşıldı!");
                    
                    Process.GetCurrentProcess().Kill();
                }
                goto Login;
            }

            Files.WriteToFile($"{DateTime.UtcNow} --> {_userService.GetByPassword(password).AccountNo} -->" +
                $" Giriş işlemi başarılı...");


            return _userService.GetByPassword(password);
        }

        public void Remitment(User sender)
        {
            var amount = CheckEnteredAmountForSender(sender);

            Console.Write("Lütfen para göndermek istediğiniz hesap numarasını giriniz : ");
            string accountNo = Console.ReadLine();
            User receiver = _userService.GetByAccountNo(accountNo);
            if (string.IsNullOrEmpty(accountNo) || receiver==null)
            {
                Console.WriteLine("Lütfen geçerli bir hesap numarası giriniz!");
            }

            var lastBalanceOfSender = sender.AccountBalance - amount;
            
            Console.WriteLine("Para gönderme işleminiz başarılıdır! Kalan bakiyeniz: {0} TL", lastBalanceOfSender);

            var message = $"{sender.AccountNo} --> {receiver.AccountNo}" + " " + "numaralı hesaba para gönderme işleminiz başarılı..."
                + $"Kalan bakiyeniz: {lastBalanceOfSender} TL";

            Files.WriteToFile(DateTime.UtcNow + " --> " + message);
        }

        public void Withdrawal(User user)
        {

            var amount = CheckEnteredAmountForSender(user);

            var lastBalance = user.AccountBalance - amount;

            var message =$"{user.AccountNo} --> Para çekme işlemi başarılı! Toplam bakiyeniz : {lastBalance} TL";

            Console.WriteLine(message);

            Files.WriteToFile(DateTime.UtcNow + " --> " + message);

        }

        private decimal CheckEnteredAmountForSender(User user)
        {
        EnterAmount:
            Console.Write("Lütfen tutarı giriniz : ");
            var amount = decimal.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(amount.ToString()) || amount <= 0 || amount > user.AccountBalance)
            {
                Console.WriteLine("Lütfen geçerli bir miktar giriniz!");
                Files.WriteToFile($"{DateTime.UtcNow}  --> {user.AccountNo}  --> Lütfen geçerli bir miktar giriniz!");
                goto EnterAmount;
            }
            return amount;
        }

        private decimal CheckEnteredAmountForUser(User user)
        {
        EnterAmount:
            Console.Write("Lütfen tutarı giriniz : ");
            var amount = decimal.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(amount.ToString()) || amount <= 0)
            {
                Console.WriteLine("Lütfen geçerli bir miktar giriniz!");
                Files.WriteToFile($"{DateTime.UtcNow}  --> {user.AccountNo}  --> Lütfen geçerli bir miktar giriniz!");
                Thread.Sleep(1000);
                goto EnterAmount;
            }
            return amount;
        }
    }
}
