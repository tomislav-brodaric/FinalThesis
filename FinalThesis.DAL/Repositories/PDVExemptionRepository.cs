//using FinalThesis.DAL.DALModels;
//using Microsoft.EntityFrameworkCore;

//namespace FinalThesis.DAL.Repositories;

//public class PDVExemptionRepository(FinalThesisContext dbContext) : IRepository<PDVExemption>
//{
//    private readonly FinalThesisContext _dbContext = dbContext;

//    public async Task<IEnumerable<PDVExemption>> GetAllAsync()
//        => await _dbContext.PDVExemptions.Include(pdv => pdv.Basis).ToListAsync();

//    public async Task<PDVExemption?> GetByIdAsync(int id)
//        => await _dbContext.PDVExemptions.Include(pdv => pdv.Basis).FirstOrDefaultAsync(p => p.IDExemption == id);

//    public async Task AddAsync(PDVExemption pdvExemptions)
//    {
//        await _dbContext.PDVExemptions.AddAsync(pdvExemptions);
//        await _dbContext.SaveChangesAsync();
//    }

//    public async Task UpdateAsync(PDVExemption pdvExemption)
//    {
//        _dbContext.PDVExemptions.Update(pdvExemption);
//        await _dbContext.SaveChangesAsync();
//    }

//    public async Task DeleteAsync(int id)
//    {
//        var pdvExemption = await GetByIdAsync(id);
//        if (pdvExemption != null)
//        {
//            _dbContext.PDVExemptions.Remove(pdvExemption);
//            await _dbContext.SaveChangesAsync();
//        }
//    }
//}