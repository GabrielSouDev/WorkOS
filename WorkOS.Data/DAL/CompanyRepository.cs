using Microsoft.EntityFrameworkCore;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;
using WorkOS.Data.Exceptions;

namespace WorkOS.Data.DAL;

public class CompanyRepository : IRepository<Company>
{
    private ApplicationDbContext _context { get; }
    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Company?> AddAsync(Company company)
    {
        if (company is null)
            throw new ArgumentNullException(nameof(company));

        await _context.Set<Company>().AddAsync(company);
        await _context.SaveChangesAsync();
        return company;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var company = await FindByIdAsync(id);
        if (company is null)
            throw new EntityNotFoundException(nameof(company));

        _context.Set<Company>().Remove(company);
        await _context.SaveChangesAsync();
    }

    public async Task<Company?> FindByIdAsync(int id) => 
        await _context.Set<Company>().FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Company>?> GetAllAsync() => 
        await _context.Set<Company>().ToListAsync();

    public async Task<Company?> UpdateAsync(Company company)
    {
        _context.Set<Company>().Update(company);
        await _context.SaveChangesAsync();
        return company;
    }
}
