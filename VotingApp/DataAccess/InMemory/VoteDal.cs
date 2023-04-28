using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.DataAccess.Abstract;
using VotingApp.Entities;

namespace VotingApp.DataAccess.InMemory
{
    public class VoteDal : IVoteDal
    {
        private List<Vote> _votes;

        public VoteDal()
        {
            _votes = new List<Vote>()
            {
                new Vote
                {  Id = 1 , 
                   User = new User{ Id =1 , UserName = "hasan48", Email="hasancan48@gmail.com", Password="123456"},
                   Category = new Category{ Id = 4 , CategoryName = "History and Geography" }
                },
                new Vote
                {  Id = 1 ,
                   User = new User{ Id =2 , UserName = "ali48", Email="alican48@gmail.com", Password="123456"},
                   Category = new Category{ Id = 5 , CategoryName = "Animals" }
                },
                new Vote
                {  Id = 1 ,
                   User = new User{ Id =1 , UserName = "hakan48", Email="hakancan48@gmail.com", Password="123456"},
                   Category = new Category{ Id = 1 , CategoryName = "Science and Technology" }
                },
                new Vote
                {  Id = 1 ,
                   User = new User{ Id =1 , UserName = "halil48", Email="halilcan48@gmail.com", Password="123456"},
                   Category = new Category{ Id = 1 , CategoryName = "Science and Technology" }
                },
                new Vote
                {  Id = 1 ,
                   User = new User{ Id =1 , UserName = "mustafa48", Email="mustafacan48@gmail.com", Password="123456"},
                   Category = new Category{ Id = 2 , CategoryName = "Sports" }
                },
                new Vote
                {  Id = 1 ,
                   User = new User{ Id = 6 , UserName = "safa48" , Password = "123456", Email="safacan@gmail.com"},
                   Category = new Category{ Id = 1 , CategoryName = "History and Geography" }
                }
            };
        }

        public void Add(Vote vote)
        {
            _votes.Add(vote);
        }

        public void Delete(Vote vote)
        {
            _votes.Remove(vote);
        }

        public List<Vote> GetAll()
        {
            return _votes.GetRange(0,_votes.Count);
        }

        public List<Vote> GetByCategoryName(string categoryName)
        {
           return GetAll().Where(c=>c.Category.CategoryName == categoryName).ToList();  
        }

        public Vote GetByUserName(string userName)
        {
            return _votes.SingleOrDefault(v => v.User.UserName == userName);
        }
    }
}
