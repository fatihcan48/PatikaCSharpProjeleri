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
            ICategoryService categoryService = new CategoryManager(new CategoryDal());
            IVoteService voteService = new VoteManager(new VoteDal(), categoryService);
            IUserService userService = new UserManager(new UserDal(),voteService);
  
            Console.WriteLine("\n********************************************\n");

            foreach (var item in categoryService.GetAll())
            {
                Console.WriteLine("{0}- {1}", item.Id, item.CategoryName);
            }
            
            Console.WriteLine("\n********************************************\n");

            // Kullanıcı adını kontrol ediyoruz, kayıt yoksa kayıt ediyoruz.
            var user = userService.CheckUserNameAndAdd();   

            Console.Write("Yukarıda verilen kategorilerin hangisinden daha fazla" +
                " içerik üretilmesini istiyorsanız belirtiniz : ");
            string secim = Console.ReadLine();

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
        
    }
}