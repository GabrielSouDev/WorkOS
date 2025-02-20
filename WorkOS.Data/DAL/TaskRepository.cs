using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOS.Data.Entitys;

namespace WorkOS.Data.DAL
{
    public class TaskRepository : IRepository<TaskItem>
    {
        private DbContext _context { get; }
        public TaskRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<TaskItem>?> GetAllAsync() => 
            await _context.Set<TaskItem>().ToListAsync();

        public async Task<TaskItem?> FindByIdAsync(int id) =>
            // da pra fazer uma verificação de nulidade aqui
            await _context.Set<TaskItem>().FirstOrDefaultAsync(t => t.Id == id);

        public async Task<TaskItem?> AddAsync(TaskItem task)
        {
            if(task is null) 
                throw new ArgumentNullException(nameof(task));

            await _context.Set<TaskItem>().AddAsync(task);
            await _context.SaveChangesAsync();
            return _context.Set<TaskItem>().Include(t => t.Author).FirstOrDefault(t => t.Id == task.Id);
        }

        public async Task<TaskItem?> UpdateAsync(TaskItem task)
        {
            var taskEntity = await FindByIdAsync(task.Id);
            if (taskEntity is null)
                throw new NullReferenceException();  // alterar para taskitemnotfoundexception, precisa separar ele em outra camada

            _context.Set<TaskItem>().Update(task);
            await _context.SaveChangesAsync();
            return _context.Set<TaskItem>().Include(t => t.Author).FirstOrDefault(t => t.Id == task.Id);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var task = await FindByIdAsync(id);
            if (task is null)
                throw new NullReferenceException(); // alterar para taskitemnotfoundexception, precisa separar ele em outra camada

            _context.Set<TaskItem>().Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
