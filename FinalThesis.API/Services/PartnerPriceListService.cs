using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class PartnerPriceListService(IRepository<PartnerPriceList> priceListRepository, IMapper mapper)
{
    private readonly IRepository<PartnerPriceList> _priceListRepository = priceListRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLPartnerPriceList>> GetAllPriceListsAsync()
    {
        var priceLists = await _priceListRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLPartnerPriceList>>(priceLists);
    }

    public async Task<BLPartnerPriceList?> GetPriceListByIdAsync(int id)
    {
        var priceList = await _priceListRepository.GetByIdAsync(id);
        return _mapper.Map<BLPartnerPriceList>(priceList);
    }

    public async Task AddPriceListAsync(BLPartnerPriceList blPriceList)
    {
        var priceList = _mapper.Map<PartnerPriceList>(blPriceList);
        await _priceListRepository.AddAsync(priceList);
        blPriceList.IDPriceList = priceList.IDPriceList;
    }

    public async Task UpdatePriceListAsync(BLPartnerPriceList blPriceList)
    {
        var priceList = _mapper.Map<PartnerPriceList>(blPriceList);
        await _priceListRepository.UpdateAsync(priceList);
    }

    public async Task DeletePriceListAsync(int id)
    {
        await _priceListRepository.DeleteAsync(id);
    }
}
