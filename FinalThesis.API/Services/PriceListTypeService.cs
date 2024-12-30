using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class PriceListTypeService(IRepository<PriceListType> priceListTypeRepository, IMapper mapper)
{
    private readonly IRepository<PriceListType> _priceListTypeRepository = priceListTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLPriceListType>> GetAllPriceListTypesAsync()
    {
        var priceListTypes = await _priceListTypeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLPriceListType>>(priceListTypes);
    }

    public async Task<BLPriceListType?> GetPriceListTypeByIdAsync(int id)
    {
        var priceListType = await _priceListTypeRepository.GetByIdAsync(id);
        return _mapper.Map<BLPriceListType>(priceListType);
    }

    public async Task AddPriceListTypeAsync(BLPriceListType blPriceListType)
    {
        var priceListType = _mapper.Map<PriceListType>(blPriceListType);
        await _priceListTypeRepository.AddAsync(priceListType);
        blPriceListType.IDPriceListType = priceListType.IDPriceListType;
    }

    public async Task UpdatePriceListTypeAsync(BLPriceListType blPriceListType)
    {
        var priceListType = _mapper.Map<PriceListType>(blPriceListType);
        await _priceListTypeRepository.UpdateAsync(priceListType);
    }

    public async Task DeletePriceListTypeAsync(int id)
    {
        await _priceListTypeRepository.DeleteAsync(id);
    }
}