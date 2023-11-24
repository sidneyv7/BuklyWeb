using Bukly.DataAcess.Repository.IRepository;
using Bukly7.Bukly.DataAcess.Data;
using Bukly7.Bukly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukly.DataAcess.Repository
{
  public class ProductRepository : Repository<Product>, IProductRepository

  {
    private BulkyContext _db;

        public ProductRepository(BulkyContext db) : base(db)
        {
      _db = db;
            
        }
        public void Update(Product product)
    {
     _db.Products.Update(product);
    }
  }
}
