using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Entities;

namespace VotingApp.Business.Abstract
{
    public interface IVoteService
    {
        List<Vote> GetAll();
        List<Vote> GetByCategoryName(string categoryName);
        Vote GetByUserName(string userName);
        void Add(User user, int categoryId);
        void Delete(Vote vote);
    }
}
