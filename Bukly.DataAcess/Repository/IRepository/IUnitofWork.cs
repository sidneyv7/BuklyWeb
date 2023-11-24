using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukly.DataAcess.Repository.IRepository
{
  public interface IUnitofWork
  {
    ICategoryRepository category { get; }
    IProductRepository  product { get; }

    void save();
  }
}
