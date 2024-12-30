using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class TaxRateService(IRepository<TaxRate> taxRateRepository, IMapper mapper)
{
    private readonly IRepository<TaxRate> _taxRateRepository = taxRateRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLTaxRate>> GetAllTaxRatesAsync()
    {
        var taxRates = await _taxRateRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLTaxRate>>(taxRates);
    }

    public async Task<BLTaxRate?> GetTaxRateByIdAsync(int id)
    {
        var taxRate = await _taxRateRepository.GetByIdAsync(id);
        return _mapper.Map<BLTaxRate>(taxRate);
    }

    public async Task AddTaxRateAsync(BLTaxRate blTaxRate)
    {
        var existingTaxRates = await _taxRateRepository.GetAllAsync();
        if (existingTaxRates.Any(t => t.TaxRateName == blTaxRate.TaxRateName))
        {
            throw new InvalidOperationException("Tax rate with this tax rate name already exists.");
        }
        var taxRate = _mapper.Map<TaxRate>(blTaxRate);
        await _taxRateRepository.AddAsync(taxRate);
        blTaxRate.IDTaxRate = taxRate.IDTaxRate;
    }

    public async Task UpdateTaxRateAsync(BLTaxRate blTaxRate)
    {
        var taxRate = _mapper.Map<TaxRate>(blTaxRate);
        await _taxRateRepository.UpdateAsync(taxRate);
    }

    public async Task DeleteTaxRateAsync(int id)
    {
        await _taxRateRepository.DeleteAsync(id);
    }
}
