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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            if (_categoryDal.GetById(category.Id)!=null)
            {
                throw new Exception("Aynı id numarasına sahip kategori mevcuttur!");
            }
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category Get(int id)
        {
            if (_categoryDal.GetById(id)==null)
            {
                throw new Exception("Girmiş olduğunuz id'ye ait kayıt bulunamamıştır!");
            }
            return _categoryDal.GetById(id);
        }

        public List<Category> GetAll()
        {
            return  _categoryDal.GetAll();
        }
    }
}
