﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using WorkOS.Data.Context;

namespace WorkOS.Data.DAL;

//TEMPORARIO, IRA SER ALTERADO PELOS REPOSITORY
public class DAL<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public DAL(ApplicationDbContext _context)
    {
        this._context = _context;
    }

    public async Task<IEnumerable<T>> IncludeAsync<T, TProperty>(Expression<Func<T, TProperty>> expression) where T : class
    {
        return await _context.Set<T>()
                             .Include(expression)
                             .ToListAsync();
    }

    public async Task<IEnumerable<T>> ToListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    //Retorna Lista de <U> aonde <T> é a tabela pai e <U> é a tabela filha.
    public async Task<IEnumerable<U>> ToListAsync<U>() where U : T
    {
        return await _context.Set<T>().OfType<U>().ToListAsync();
    }
    public async Task AddAsync(T t)
    {
        await _context.Set<T>().AddAsync(t);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(T t)
    {
        _context.Set<T>().Update(t);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(T t)
    {
        _context.Set<T>().Remove(t);
        await _context.SaveChangesAsync();
    }
    public async Task<T?> FindByAsync(Expression<Func<T, bool>> e)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(e);
    }
    //Retorna <U> aonde <T> é a tabela pai e <U> é a tabela filha.
    public async Task<U?> FindByAsync<U>(Expression<Func<U, bool>> e) where U : T
    {
        return await _context.Set<T>().OfType<U>().FirstOrDefaultAsync(e);
    }
}
