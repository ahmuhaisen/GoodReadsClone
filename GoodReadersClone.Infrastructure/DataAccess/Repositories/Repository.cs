﻿using GoodReadersClone.Infrastructure.DataAccess.Abstractions;
using GoodReadersClone.Infrastructure.DataAccess.Data;
using GoodReadersClone.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoodReadersClone.Infrastructure.DataAccess.Repositories;


public class Repository<T>(ApplicationDbContext _context) : IRepository<T> where T : class
{
    //Create
    public T Create(T entity)
    {
        _context.Add(entity);

        return entity;
    }

    //Read
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = _context.Set<T>();

        return await query.Where(filter).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.Where(filter).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, int skip, int take)
    {
        return await _context.Set<T>()
            .Where(filter)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, int? skip, int? take,
    Expression<Func<T, object>> orderBy = null!, string orderDirection = OrderByDirections.ASC)
    {
        IQueryable<T> query = _context.Set<T>().Where(filter);

        if(skip.HasValue) query = query.Skip(skip.Value);
        if(take.HasValue) query = query.Take(take.Value);

        if(orderBy is not null)
        {
            if(orderDirection == OrderByDirections.ASC)
                query = query.OrderBy(orderBy);
            else
                query = query.OrderByDescending(orderBy);
        }

        return await query.ToListAsync();
    }

    //Update
    public T Update(T entity)
    {
        _context.Update(entity);

        return entity;
    }

    //Delete
    public T Delete(T entity)
    {
        _context.Remove(entity);

        return entity;
    }
}