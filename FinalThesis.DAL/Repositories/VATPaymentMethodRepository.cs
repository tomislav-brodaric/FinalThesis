using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class VATPaymentMethodRepository(FinalThesisContext dbContext) : IRepository<VATPaymentMethod>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<VATPaymentMethod>> GetAllAsync()
        => await _dbContext.VATPaymentMethods.ToListAsync();

    public async Task<VATPaymentMethod?> GetByIdAsync(int id)
        => await _dbContext.VATPaymentMethods.FirstOrDefaultAsync(vpm => vpm.IDVATPaymentMethod == id);

    public async Task AddAsync(VATPaymentMethod vatPaymentMethod)
    {
        await _dbContext.VATPaymentMethods.AddAsync(vatPaymentMethod);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(VATPaymentMethod vatPaymentMethod)
    {
        _dbContext.VATPaymentMethods.Update(vatPaymentMethod);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var vatPaymentMethod = await GetByIdAsync(id);
        if (vatPaymentMethod != null)
        {
            _dbContext.VATPaymentMethods.Remove(vatPaymentMethod);
            await _dbContext.SaveChangesAsync();
        }
    }
}
