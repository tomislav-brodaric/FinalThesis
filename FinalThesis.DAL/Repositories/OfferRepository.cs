using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

public class OfferRepository(FinalThesisContext dbContext) : IRepository<Offer>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<Offer>> GetAllAsync()
        => await _dbContext.Offers.Include(o => o.Partner)
                                  //.Include(o => o.Exemption)
                                  .Include(o => o.OfferProducts)
                                  .ToListAsync();

    public async Task<Offer?> GetByIdAsync(int id)
        => await _dbContext.Offers.Include(o => o.Partner)
                                  //.Include(o => o.Exemption)
                                  .Include(o => o.OfferProducts)
                                  .FirstOrDefaultAsync(o => o.IDOffer == id);

    public async Task AddAsync(Offer offer)
    {
        await _dbContext.Offers.AddAsync(offer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Offer offer)
    {
        _dbContext.Offers.Update(offer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var offer = await GetByIdAsync(id);
        if (offer != null)
        {
            _dbContext.OfferProducts.RemoveRange(offer.OfferProducts);
            _dbContext.Offers.Remove(offer);
            await _dbContext.SaveChangesAsync();
        }
    }
}