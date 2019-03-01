using System.Collections.Generic;
using System.Linq;
using ExampleProject.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DataAccess
{
    internal sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
    }
}