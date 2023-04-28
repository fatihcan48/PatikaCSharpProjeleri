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
    public class VoteManager : IVoteService
    {
        private IVoteDal _voteDal;
        private ICategoryService _categoryService;

        public VoteManager(IVoteDal voteDal, ICategoryService categoryService)
        {
            _voteDal = voteDal;
            _categoryService = categoryService;
        }

        public void Add(User user, int categoryId)
        {
            Vote vote = new Vote();
            var category = _categoryService.GetById(categoryId);
            vote.Id = GetAll().Count() + 1;
            vote.User = user;
            vote.Category = category;
            _voteDal.Add(vote);
        }

        public void Delete(Vote vote)
        {
            _voteDal.Delete(vote);
        }

        public List<Vote> GetAll()
        {
            return _voteDal.GetAll();
        }

        public List<Vote> GetByCategoryName(string categoryName)
        {
            return _voteDal.GetByCategoryName(categoryName);
        }

        public Vote GetByUserName(string userName)
        {
            return _voteDal.GetByUserName(userName);
        }

       
    }
}
