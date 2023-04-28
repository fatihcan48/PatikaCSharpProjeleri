using System.ComponentModel;
using VotingApp.Business.Abstract;
using VotingApp.Business.Concrete;
using VotingApp.DataAccess.Abstract;
using VotingApp.DataAccess.InMemory;
using VotingApp.Entities;

namespace VotingApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserManager(new UserDal());
            ICategoryService categoryService = new CategoryManager(new CategoryDal());
            IVoteService voteService = new VoteManager(new VoteDal(), new UserDal(),new CategoryDal());
            
            Console.WriteLine("\n********************************************\n");

            foreach (var item in categoryService.GetAll())
            {
                Console.WriteLine("{0}- {1}", item.Id, item.CategoryName);
            }
            
            Console.WriteLine("\n********************************************\n");
           
            var user =  CheckUserName(userService,voteService);    // Kullanıcı adını kontrol ediyoruz, yoksa kayıt ediyoruz.

            Console.Write("Lütfen yukarıda verilen kategorilerin hangisinden daha fazla" +
                "içerik üretilmesini istiyorsanız seçiminizi belirtiniz :  ");
            string secim = Console.ReadLine();

            Console.WriteLine("\n********************************************\n");

            voteService.Add(user, int.Parse(secim));   // Yapılan seçimi kaydediyoruz...
            
            Console.WriteLine("\n********************************************\n");

            // Her bir kategoriye verilen oyları gösteriyoruz.
            foreach (var item in categoryService.GetAll())
            {
                Console.WriteLine("{0,-2}- {1,-25} -> Verilen oy : {2} (%{3:.#})", item.Id, item.CategoryName,
                   voteService.GetByCategoryName(item.CategoryName).Count,
                   (Convert.ToDouble(voteService.GetByCategoryName(item.CategoryName).Count)/
                   Convert.ToDouble(voteService.GetAll().Count))*100);
            }

            Console.ReadKey();
        }

        
        private static User CheckUserName(IUserService userService, IVoteService voteService)
        {
            int sayac = 0;
            Back:
            Console.Write("Lütfen kullanıcı adınızı giriniz : ");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                goto Back;
            }

            if (CheckIfUserVoted(voteService,userName))
            {
                goto Back;
            }

            if (userService.GetByUserName(userName) == null)
            {
                Console.WriteLine("Girmiş olduğunuz kullanıcı adı bulunamadı! Lütfen tekrar deneyiniz...");
                sayac++;
                if (sayac == 3)
                {
                    Console.WriteLine("\nLütfen kayıt olunuz!");
                    RegisterUser(userService);
                }
                goto Back;  
            }

            return userService.GetByUserName(userName);
        }
        private static bool CheckIfUserVoted(IVoteService voteService, string userName)
        {
            if (voteService.GetByUserName(userName) != null)
            {
                Console.WriteLine("Girmiş olduğunuz kullanıcı daha önceden oylamaya katılmıştır!");
                return true;
            }
            return false;
        }
        private static void RegisterUser(IUserService userService)
        {
            User yeniKullanici = new User();

            yeniKullanici.Id = userService.GetAll().Count()+1;

            KullaniciAdi:
            Console.Write("Lütfen kullanıcı adınızı giriniz : ");
            string userName = Console.ReadLine();
            yeniKullanici.UserName = userName;
            Console.WriteLine();

            if (userService.GetByUserName(userName)!=null)
            {
                Console.WriteLine("Girmiş olduğunuz kullanıcı adı zaten mevcuttur! Yeni bir kullanıcı adı giriniz!");
                goto KullaniciAdi;   
            } 

            Console.Write("Lütfen şifrenizi giriniz : ");
            string password = Console.ReadLine();
            yeniKullanici.Password = password;
            Console.WriteLine();

            Console.Write("Lütfen email adresinizi giriniz : ");
            string email = Console.ReadLine();
            yeniKullanici.Email = email;
            Console.WriteLine();

            userService.Add(yeniKullanici);
            Console.WriteLine("Kayıt işlemi başarılı!");

        }
    }
}