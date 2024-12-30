using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class TaxNumberTypeService(IRepository<TaxNumberType> taxNumberTypeRepository, IMapper mapper)
{
    private readonly IRepository<TaxNumberType> _taxNumberTypeRepository = taxNumberTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLTaxNumberType>> GetAllTaxNumberTypesAsync()
    {
        var taxNumberTypes = await _taxNumberTypeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLTaxNumberType>>(taxNumberTypes);
    }

    public async Task<BLTaxNumberType?> GetTaxNumberTypeByIdAsync(int id)
    {
        var taxNumberType = await _taxNumberTypeRepository.GetByIdAsync(id);
        return _mapper.Map<BLTaxNumberType>(taxNumberType);
    }

    public async Task AddTaxNumberTypeAsync(BLTaxNumberType blTaxNumberType)
    {
        var taxNumberType = _mapper.Map<TaxNumberType>(blTaxNumberType);
        await _taxNumberTypeRepository.AddAsync(taxNumberType);
        blTaxNumberType.IDTaxNumberType = taxNumberType.IDTaxNumberType;
    }

    public async Task UpdateTaxNumberTypeAsync(BLTaxNumberType blTaxNumberType)
    {
        var taxNumberType = _mapper.Map<TaxNumberType>(blTaxNumberType);
        await _taxNumberTypeRepository.UpdateAsync(taxNumberType);
    }

    public async Task DeleteTaxNumberTypeAsync(int id)
    {
        await _taxNumberTypeRepository.DeleteAsync(id);
    }
}