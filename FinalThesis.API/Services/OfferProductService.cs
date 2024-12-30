using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class OfferProductService(IRepository<OfferProduct> offerProductRepository, IMapper mapper)
{
    private readonly IRepository<OfferProduct> _offerProductRepository = offerProductRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLOfferProduct>> GetAllOfferProductsAsync()
    {
        var offerProducts = await _offerProductRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLOfferProduct>>(offerProducts);
    }

    public async Task<BLOfferProduct?> GetOfferProductByIdAsync(int id)
    {
        var offerProduct = await _offerProductRepository.GetByIdAsync(id);
        return _mapper.Map<BLOfferProduct>(offerProduct);
    }

    public async Task AddOfferProductAsync(BLOfferProduct blOfferProduct)
    {
        var offerProduct = _mapper.Map<OfferProduct>(blOfferProduct);
        await _offerProductRepository.AddAsync(offerProduct);
        blOfferProduct.IDOfferProduct = offerProduct.IDOfferProduct;
    }

    public async Task UpdateOfferProductAsync(BLOfferProduct blOfferProduct)
    {
        var offerProduct = _mapper.Map<OfferProduct>(blOfferProduct);
        await _offerProductRepository.UpdateAsync(offerProduct);
    }

    public async Task DeleteOfferProductAsync(int id)
    {
        await _offerProductRepository.DeleteAsync(id);
    }
}
