using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Entities
{
    public class Vote : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
