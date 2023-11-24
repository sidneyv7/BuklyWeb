using Bukly.DataAcess.Repository.IRepository;
using Bukly7.Bukly.DataAcess.Data;
using Bukly7.Bukly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bukly.DataAcess.Repository.IRepository;

namespace Bukly.DataAcess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository

    {
        private BulkyContext _db;
        public CategoryRepository(BulkyContext db) : base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }

    void ICategoryRepository.Save()
    {
      throw new NotImplementedException();
    }

    void ICategoryRepository.Update(Category obj)
    {
      throw new NotImplementedException();
    }
  }
}
