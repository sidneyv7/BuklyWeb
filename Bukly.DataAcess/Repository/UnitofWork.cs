using Bukly.DataAcess.Repository.IRepository;
using Bukly7.Bukly.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukly.DataAcess.Repository
{
  public class UnitofWork : IUnitofWork
  {

    private BulkyContext _context;

        public UnitofWork(BulkyContext context)
        {
      _context = context;
      category = new CategoryRepository(_context);
      product = new ProductRepository(_context);

        }

        public ICategoryRepository category {  get; private set; }

    public IProductRepository product { get; private set; }


    public void save()
    {
      _context.SaveChanges();
    }
  }
}
