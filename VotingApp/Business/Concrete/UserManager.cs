using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Business.Abstract;
using VotingApp.DataAccess.Abstract;
using VotingApp.Entities;

namespace VotingApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IVoteService _voteService;

        public UserManager(IUserDal userDal, IVoteService voteService)
        {
            _userDal = userDal;
            _voteService = voteService;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetByUserName(string userName)
        {
            return _userDal.GetByUserName(userName);
        }

        public User CheckUserNameAndAdd()
        {
            int sayac = 0;
        Back:
            Console.Write("Lütfen kullanıcı adınızı giriniz : ");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                goto Back;
            }

            if (CheckIfUserVoted(userName))
            {
                goto Back;
            }
            
            if (_userDal.GetByUserName(userName) == null)
            {
                Console.WriteLine("Girmiş olduğunuz kullanıcı adı bulunamadı! Lütfen tekrar deneyiniz...");
                sayac++;
                if (sayac == 3)
                {
                    Console.WriteLine("\nLütfen kayıt olunuz!");
                    RegisterUser();
                }
                goto Back;
            }

            return _userDal.GetByUserName(userName);
        }
        public void RegisterUser()
        {
            User yeniKullanici = new User();

            yeniKullanici.Id = _userDal.GetAll().Count() + 1;

        KullaniciAdi:
            Console.Write("Lütfen kullanıcı adınızı giriniz : ");
            string userName = Console.ReadLine();
            yeniKullanici.UserName = userName;
            Console.WriteLine();

            if (_userDal.GetByUserName(userName) != null)
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

            _userDal.Add(yeniKullanici);
            Console.WriteLine("Kayıt işlemi başarılı!");

        }
        public bool CheckIfUserVoted(string userName)
        {
            if (_voteService.GetByUserName(userName) != null)
            {
                Console.WriteLine("Girmiş olduğunuz kullanıcı daha önceden oylamaya katılmıştır!");
                return true;
            }
            return false;
        }
    }
}
