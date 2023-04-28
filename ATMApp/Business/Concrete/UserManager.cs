using ATMApp.Business.Abstract;
using ATMApp.DataAccess.Abstract;
using ATMApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetByAccountNo(string accountNo)
        {
            return _userDal.GetByAccountNo(accountNo);
        }

        public User GetByPassword(string password)
        {
            return _userDal.GetByPassword(password);
        }
    }
}
