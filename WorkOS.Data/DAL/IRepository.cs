using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;

namespace WorkOS.Data.DAL;

internal interface IRepository<T> where T : class
{
    Task<IEnumerable<T>?> GetAllAsync();
    Task<T?> FindByIdAsync(int id);
    Task<T?> AddAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task DeleteByIdAsync(int id);
}
