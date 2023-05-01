using ATMApp.Business.Abstract;
using ATMApp.Business.Concrete;
using ATMApp.Business.Utilities.FileProcesses;
using ATMApp.DataAccess.InMemory;
using ATMApp.Entities;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;

namespace ATMApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserManager(new UserDal());
            IAtmService atmService = new AtmManager(userService);
        Login:
            Console.WriteLine("\n*******************************************\n");

            var user = atmService.Login();

            Console.WriteLine("\n*******************************************\n");

        Menu:
            Console.WriteLine("1 - Withdrawal (Para Çekme) \n2 - Remitment (Para Gönderme)" +
                "\n3 - Deposit (Para Yatırma) \n4 - Balance Inquiry (Bakiye Sorgulama) " +
                "\n5 - End Of The Day (Gün Sonu Raporu) \n6 - Quit (Çıkış)");

            Console.WriteLine("\n*******************************************\n");

        Choose:
            Console.Write("Lütfen yapmak istediğiniz işlemi seçiniz : ");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                atmService.Withdrawal(user);

            }
            else if (secim == 2)
            {
                atmService.Remitment(user);
            }
            else if (secim == 3)
            {
                atmService.Deposit(user);
            }
            else if (secim == 4)
            {
                atmService.BalanceInquiry(user);
            }
            else if (secim == 5)
            {
                atmService.EndOfDay();
            }
            else if (secim == 6)
            {
                Console.Clear();
                goto Login;
            }
            else
            {
                Console.WriteLine("Hatalı giriş yaptınız!");
                Thread.Sleep(1000);
                goto Choose;
            }

            Console.Write("Yapmak istediğiniz başka bir işlem var mı ?(Y/N): ");
            string again = Console.ReadLine();
            if (again.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                goto Menu;
            }
            else
            {
                Console.WriteLine("Çıkış yapılıyor... İyi Günler...");
                Process.GetCurrentProcess().Kill();
            }


            Console.ReadKey();
        }

    }
}