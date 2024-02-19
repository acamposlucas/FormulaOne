﻿using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly ILogger _logger;
    protected AppDbContext _context;
    internal DbSet<T> _dbSet;

    public GenericRepository(ILogger logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
