//using FinalThesis.DAL.DALModels;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;

//namespace FinalThesis.DAL.Repositories;

//public class ExemptionBasisRepository(FinalThesisContext dbContext) : IRepository<ExemptionBasis>
//{
//    private readonly FinalThesisContext _dbContext = dbContext;

//    public async Task<IEnumerable<ExemptionBasis>> GetAllAsync()
//        => await _dbContext.ExemptionBases.Include(eb => eb.PDVExemptions).ToListAsync();

//    public async Task<ExemptionBasis?> GetByIdAsync(int id)
//        => await _dbContext.ExemptionBases.Include(eb => eb.PDVExemptions).FirstOrDefaultAsync(eb => eb.IDBasis == id);

//    public async Task AddAsync(ExemptionBasis exemptionBasis)
//    {
//        await _dbContext.ExemptionBases.AddAsync(exemptionBasis);
//        await _dbContext.SaveChangesAsync();
//    }

//    public async Task UpdateAsync(ExemptionBasis exemptionBasis)
//    {
//        _dbContext.ExemptionBases.Update(exemptionBasis);
//        await _dbContext.SaveChangesAsync();
//    }

//    public async Task DeleteAsync(int id)
//    {
//        var exemptionBasis = await GetByIdAsync(id);
//        if (exemptionBasis != null)
//        {
//            _dbContext.ExemptionBases.Remove(exemptionBasis);
//            await _dbContext.SaveChangesAsync();
//        }
//    }

//    public async Task<bool> AnyAsync(Expression<Func<ExemptionBasis, bool>> predicate)
//    {
//        return await _dbContext.ExemptionBases.AnyAsync(predicate);
//    }

//}