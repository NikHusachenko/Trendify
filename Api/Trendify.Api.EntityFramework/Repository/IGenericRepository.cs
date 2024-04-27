﻿using System.Linq.Expressions;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task Create(T entity);
    Task Update(T entity);
    Task DeleteSoft(T entity);
    Task DeleteHard(T entity);

    Task<T?> GetById(Guid id);
    Task<T?> GetBy(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetAll();
    IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate);
}