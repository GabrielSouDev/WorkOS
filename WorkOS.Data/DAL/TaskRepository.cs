using Microsoft.EntityFrameworkCore;
using WorkOS.Data.Exceptions;
using WorkOS.Data.Entitys;
using WorkOS.Data.Context;

namespace WorkOS.Data.DAL;

public class TaskRepository : IRepository<TaskItem>
{
    private ApplicationDbContext _context { get; }
    public TaskRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<TaskItem>?> GetAllAsync() => 
        await _context.Set<TaskItem>().ToListAsync();

    public async Task<TaskItem?> FindByIdAsync(int id) =>
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
        _context.Set<TaskItem>().Update(task);
        await _context.SaveChangesAsync();
        return _context.Set<TaskItem>().Include(t => t.Author).FirstOrDefault(t => t.Id == task.Id);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var task = await FindByIdAsync(id);
        if (task is null)
            throw new EntityNotFoundException(nameof(task));

        _context.Set<TaskItem>().Remove(task);
        await _context.SaveChangesAsync();
    }
}
