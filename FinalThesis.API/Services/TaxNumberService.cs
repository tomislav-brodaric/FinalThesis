using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class TaxNumberService(IRepository<TaxNumber> taxNumberRepository, IMapper mapper)
{
    private readonly IRepository<TaxNumber> _taxNumberRepository = taxNumberRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLTaxNumber>> GetAllTaxNumbersAsync()
    {
        var taxNumbers = await _taxNumberRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLTaxNumber>>(taxNumbers);
    }

    public async Task<BLTaxNumber?> GetTaxNumberByIdAsync(int id)
    {
        var taxNumber = await _taxNumberRepository.GetByIdAsync(id);
        return _mapper.Map<BLTaxNumber>(taxNumber);
    }

    public async Task AddTaxNumberAsync(BLTaxNumber blTaxNumber)
    {
        var existingTaxNumbers = await _taxNumberRepository.GetAllAsync();
        if (existingTaxNumbers.Any(t => t.TaxCode == blTaxNumber.TaxCode))
        {
            throw new InvalidOperationException("Tax number with this tax code already exists.");
        }
        var taxNumber = _mapper.Map<TaxNumber>(blTaxNumber);
        await _taxNumberRepository.AddAsync(taxNumber);
        blTaxNumber.IDTaxNumber = taxNumber.IDTaxNumber;
    }

    public async Task UpdateTaxNumberAsync(BLTaxNumber blTaxNumber)
    {
        var taxNumber = _mapper.Map<TaxNumber>(blTaxNumber);
        await _taxNumberRepository.UpdateAsync(taxNumber);
    }

    public async Task DeleteTaxNumberAsync(int id)
    {
        await _taxNumberRepository.DeleteAsync(id);
    }
}