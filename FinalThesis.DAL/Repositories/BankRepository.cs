using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class BankRepository(FinalThesisContext dbContext) : IRepository<Bank>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<Bank>> GetAllAsync()
        => await _dbContext.Banks.Include(b => b.GiroAccounts).ToListAsync();

    public async Task<Bank?> GetByIdAsync(int id)
        => await _dbContext.Banks.Include(b => b.GiroAccounts).FirstOrDefaultAsync(b => b.IDBank == id);

    public async Task AddAsync(Bank bank)
    {
        await _dbContext.Banks.AddAsync(bank);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Bank bank)
    {
        _dbContext.Banks.Update(bank);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var bank = await GetByIdAsync(id);
        if (bank != null)
        {
            _dbContext.Banks.Remove(bank);
            await _dbContext.SaveChangesAsync();
        }
    }
}
