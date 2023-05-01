using ATMApp.DataAccess.Abstract;
using ATMApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.DataAccess.InMemory
{
    public class UserDal : IUserDal
    {
        private List<User> _users;

        public UserDal()
        {
            _users = new List<User>()
            {
                new User
                {
                    Id = 1, FirstName = "null", LastName = "null", AccountNo = "null",
                    Password="null", AccountBalance = 0
                },
                new User
                {   Id = 2, FirstName = "Fatih", LastName="Can" , AccountNo = "10000001",
                    Password ="1234", AccountBalance=25000
                },

                new User{
                    Id = 3, FirstName = "Yusuf", LastName="Asaf" , AccountNo = "10000002",
                    Password ="4321", AccountBalance=45000
                },
                new User{
                    Id = 4, FirstName = "Ahmet", LastName="Can" ,  AccountNo = "10000003",
                    Password ="1111", AccountBalance=5000
                },
            };
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public List<User> GetAll()
        {
            return _users.GetRange(0,_users.Count); 
        }

        public User GetByAccountNo(string accountNo)
        {
            return _users.SingleOrDefault(u => u.AccountNo == accountNo);
        }

        public User GetByPassword(string password)
        {
            return _users.SingleOrDefault(u => u.Password == password);
        }
    }
}
