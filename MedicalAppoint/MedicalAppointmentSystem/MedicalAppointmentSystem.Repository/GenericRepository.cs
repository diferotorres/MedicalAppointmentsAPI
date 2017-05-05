using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MedicalAppointmentSystem.Entities;

namespace MedicalAppointmentSystem.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _entities = null;
        internal DbSet<TEntity> _objectSet;

        public GenericRepository(ApplicationContext _entities)
        {
            this._entities = _entities;
            _objectSet = this._entities.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, object>> include = null)
        {
            IQueryable<TEntity> result = _objectSet;
            if (predicate != null)
            {
                result = _objectSet.Where(predicate);
            }

            if (include != null)
            {
                result.Include(include).Load();
            }

            return result;
        }

        public TEntity Get(Func<TEntity, bool> predicate = null, Expression<Func<TEntity, object>> include = null)
        {
            TEntity result = null;
            if (include != null)
            {
                if (predicate != null) result = _objectSet.Include(include).First(predicate);
            }
            else
            {
                if (predicate != null) result = _objectSet.First(predicate);
            }
            return result;
        }

        public void Add(TEntity entity)
        {
            _objectSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _objectSet.Remove(entity);
        }
        public void SaveChanges()
        {
            _entities.SaveChanges();
        }

        public object GetCurrentContext()
        {
            return _entities;
        }
    }
}