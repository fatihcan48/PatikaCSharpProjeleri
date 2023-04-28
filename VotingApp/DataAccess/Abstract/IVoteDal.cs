using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.DataAccess.Abstract
{
    public interface IVoteDal
    {
        List<Vote> GetAll();
        List<Vote> GetByCategoryName(string categoryName);
        Vote GetByUserName(string userName);
        void Add(Vote vote);
        void Delete(Vote vote);
    }
}
