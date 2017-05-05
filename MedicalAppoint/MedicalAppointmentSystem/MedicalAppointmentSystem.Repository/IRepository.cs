using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MedicalAppointmentSystem.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, object>> include = null);
        TEntity Get(Func<TEntity, bool> predicate, Expression<Func<TEntity, object>> include = null);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
        object GetCurrentContext();
    }
}