using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.DataAccess.Abstract;
using VotingApp.Entities;

namespace VotingApp.DataAccess.InMemory
{
    public class UserDal : IUserDal
    {
        private List<User> _users;

        public UserDal()
        {
            _users = new List<User>()
            {
                new User{ Id = 1 , UserName = "hasan48" , Password = "123456", Email="hasancan@gmail.com"},
                new User{ Id = 2 , UserName = "ali48" , Password = "123456", Email="alican@gmail.com"},
                new User{ Id = 3 , UserName = "hakan48" , Password = "123456", Email="hakancan@gmail.com"},
                new User{ Id = 4 , UserName = "halil48" , Password = "123456", Email="halilcan@gmail.com"},
                new User{ Id = 5 , UserName = "mustafa48" , Password = "123456", Email="mustafacan@gmail.com"},
                new User{ Id = 6 , UserName = "safa48" , Password = "123456", Email="safacan@gmail.com"},
                new User{ Id = 6 , UserName = "fatih48" , Password = "123456", Email="fatihcan@gmail.com"},
                new User{ Id = 6 , UserName = "yusuf48" , Password = "123456", Email="yusufcan@gmail.com"},
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

        public User GetByUserName(string userName)
        {
            return _users.SingleOrDefault(u => u.UserName == userName);
        }
    }
}
