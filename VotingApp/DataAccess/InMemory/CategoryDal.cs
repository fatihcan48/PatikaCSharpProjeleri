using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.DataAccess.Abstract;
using VotingApp.Entities;

namespace VotingApp.DataAccess.InMemory
{
    public class CategoryDal : ICategoryDal
    {
        private List<Category> _categories;

        public CategoryDal()
        {
            _categories = new List<Category>()
            {
                new Category() { Id = 1, CategoryName = "Science and Technology" },
                new Category() { Id = 2 , CategoryName = "Sports"},
                new Category() { Id = 3 , CategoryName = "Movies"},
                new Category() { Id = 4 , CategoryName = "History and Geography"},
                new Category() { Id = 5 , CategoryName = "Animals"},
            };
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            _categories.Remove(category);
        }

        public List<Category> GetAll()
        {
            return _categories.GetRange(0, _categories.Count);
        }

        public Category GetById(int id)
        {
            return _categories.SingleOrDefault(c => c.Id == id);
        }
    }
}
