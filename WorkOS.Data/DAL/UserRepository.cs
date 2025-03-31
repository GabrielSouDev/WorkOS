using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;
using WorkOS.Data.Exceptions;

namespace WorkOS.Data.DAL;

public class UserRepository : IRepository<User>
{
    private ApplicationDbContext _context { get; }
    public UserRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<User?> AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return await _context.Set<User>().Include(g => g.Group).FirstOrDefaultAsync(g => g.Id == user.Id);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var user = await FindByIdAsync(id);
        if (user is null)
            throw new EntityNotFoundException(nameof(user));

        _context.Set<User>().Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> FindByIdAsync(int id) =>
        await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);

    public async Task<IEnumerable<User>?> GetAllAsync() =>
        await _context.Set<User>().ToListAsync();

    public async Task<User?> UpdateAsync(User user)
    {
        _context.Update(user);
        await _context.SaveChangesAsync();
        return await _context.Set<User>().Include(g => g.Group).FirstOrDefaultAsync(g => g.Id == user.Id);
    }
}
