using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetByUserName(string userName);
        void Add(User user);
        void Delete(User user);
        User CheckUserNameAndAdd();
    }
}
