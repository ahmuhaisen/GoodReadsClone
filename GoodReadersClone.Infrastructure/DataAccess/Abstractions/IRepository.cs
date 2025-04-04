﻿using GoodReadsClone.Domain.Models;
using GoodReadsClone.Infrastructure.Utils;
using System.Linq.Expressions;

namespace GoodReadsClone.Infrastructure.DataAccess.Abstractions;


public interface IRepository<T> where T : class
{
    //Create
    T Create(T entity);

    //Read
    Task<bool> IsExist(Expression<Func<T, bool>> filter);

    Task<T?> GetByIdAsync(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter, string[]? includes = null);

    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(string[] includes);
    Task<PaginatedList<T>> GetAllAsync(int pageIndex, int pageSize);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, string[] includes);
    Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>> filter, int skip, int take);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, int? skip, int? take,
        Expression<Func<T, object>> orderBy = null!, string orderDirection = OrderByDirections.ASC);

    //Update
    T Update(T entity);

    //Delete
    T Delete(T entity);
}
