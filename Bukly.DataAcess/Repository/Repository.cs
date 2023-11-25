using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bukly7.Bukly.Models;
using Bukly7.Bukly.DataAcess.Data;
using Bukly.DataAcess.Repository.IRepository;

namespace Bukly.DataAcess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BulkyContext _db;
        internal DbSet<T> dbSet;
        public Repository(BulkyContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
      _db.Products.Include(u => u.Category).Include(u => u.CategoryId);

      //_db.Categories == dbSet

    }


    public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteAll(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

    T IRepository<T>.Get(Expression<Func<T, bool>> filter, string? includeProperties)
    {
      IQueryable<T> query = dbSet;
      query = query.Where(filter);
      if (!string.IsNullOrEmpty(includeProperties))
      {
        foreach (var includeProp in includeProperties
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }
      return query.FirstOrDefault();
    }

    IEnumerable<T> IRepository<T>.GetAll(string? includeProperties)
    {
      IQueryable<T> query = dbSet;
      if (!string.IsNullOrEmpty(includeProperties))
      {
        foreach (var includeProp in includeProperties
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }
      return query.ToList();
    }
  }
}
