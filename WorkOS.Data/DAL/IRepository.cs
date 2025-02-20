using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOS.Data.Entitys;

namespace WorkOS.Data.DAL;

internal interface IRepository<T> where T : class
{
    Task<IEnumerable<TaskItem>?> GetAllAsync();
    Task<T?> FindByIdAsync(int id);
    Task<T?> AddAsync(T task);
    Task<T?> UpdateAsync(T task);
    Task DeleteByIdAsync(int id);
}
