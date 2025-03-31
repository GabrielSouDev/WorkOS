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

public class GroupRepository : IRepository<Group>
{
    private ApplicationDbContext _context { get; }
    public GroupRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Group?> AddAsync(Group group)
    {
        await _context.Set<Group>().AddAsync(group);
        await _context.SaveChangesAsync();
        return await _context.Set<Group>().Include(g => g.Company).FirstOrDefaultAsync(g=> g.Id == group.Id);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var group = await FindByIdAsync(id);
        if (group is null)
            throw new EntityNotFoundException(nameof(group));

        _context.Set<Group>().Remove(group);
        await _context.SaveChangesAsync();
    }

    public async Task<Group?> FindByIdAsync(int id) =>
        await _context.Set<Group>().FirstOrDefaultAsync(g=> g.Id == id);

    public async Task<IEnumerable<Group>?> GetAllAsync() =>
        await _context.Set<Group>().ToListAsync();

    public async Task<Group?> UpdateAsync(Group group)
    {
        _context.Set<Group>().Update(group);
        await _context.SaveChangesAsync();
        return await _context.Set<Group>().Include(g => g.Company).FirstOrDefaultAsync(g => g.Id == group.Id);
    }
}
