using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class GiroAccountRepository(FinalThesisContext context) : IRepository<GiroAccount>
{
    private readonly FinalThesisContext _context = context;

    public async Task<IEnumerable<GiroAccount>> GetAllAsync()
    {
        return await _context.GiroAccounts
            .Include(g => g.Bank)
            .ToListAsync();
    }

    public async Task<GiroAccount?> GetByIdAsync(int id)
    {
        return await _context.GiroAccounts
            .Include(g => g.Bank)
            .FirstOrDefaultAsync(g => g.IDGiroAccount == id);
    }

    public async Task AddAsync(GiroAccount giroAccount)
    {
        await _context.GiroAccounts.AddAsync(giroAccount);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GiroAccount giroAccount)
    {
        _context.GiroAccounts.Update(giroAccount);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var giroAccount = await GetByIdAsync(id);
        if (giroAccount != null)
        {
            _context.GiroAccounts.Remove(giroAccount);
            await _context.SaveChangesAsync();
        }
    }
}
