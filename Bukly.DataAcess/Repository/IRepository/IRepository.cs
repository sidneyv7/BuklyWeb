using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bukly.DataAcess.Repository.IRepository
{
  internal interface IRepository <T> where T : class
  {
    IEnumerable<T> GetAll ();
    T Get(Expression<Func<T,bool>> filter);
    
    void Delete (T entity);
    void Add (T entity);
    void DeleteAll(IEnumerable<T> entities);
  }
}
