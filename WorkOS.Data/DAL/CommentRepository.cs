using Microsoft.EntityFrameworkCore;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;
using WorkOS.Data.Exceptions;

namespace WorkOS.Data.DAL;

public class CommentRepository : IRepository<Comment>
{
    private ApplicationDbContext _context { get; }
    public CommentRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Comment?> AddAsync(Comment comment)
    {
        await _context.Set<Comment>().AddAsync(comment);
        await _context.SaveChangesAsync();
        return await _context.Set<Comment>().Include(g => g.Task).FirstOrDefaultAsync(g => g.Id == comment.Id);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var comment = await FindByIdAsync(id);
        if (comment is null)
            throw new EntityNotFoundException(nameof(comment));
        
        _context.Set<Comment>().Remove(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<Comment?> FindByIdAsync(int id) => 
        await _context.Set<Comment>().FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Comment>?> GetAllAsync()
    {
        return await _context.Set<Comment>().ToListAsync();
    }

    public async Task<Comment?> UpdateAsync(Comment comment)
    {
        _context.Set<Comment>().Update(comment);
        await _context.SaveChangesAsync();
        return await _context.Set<Comment>().Include(g => g.Task).FirstOrDefaultAsync(g => g.Id == comment.Id);
    }
}
