﻿using System.Linq.Expressions;

namespace RugbyUnion1.Data
{
    public interface IRepositoryBase<T> 
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}