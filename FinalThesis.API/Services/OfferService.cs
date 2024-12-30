using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class OfferService(IRepository<Offer> offerRepository, IMapper mapper)
{
    private readonly IRepository<Offer> _offerRepository = offerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLOffer>> GetAllOffersAsync()
    {
        var offers = await _offerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLOffer>>(offers);
    }

    public async Task<BLOffer?> GetOfferByIdAsync(int id)
    {
        var offer = await _offerRepository.GetByIdAsync(id);
        return _mapper.Map<BLOffer>(offer);
    }

    public async Task AddOfferAsync(BLOffer blOffer)
    {
        var offer = _mapper.Map<Offer>(blOffer);
        await _offerRepository.AddAsync(offer);
        blOffer.IDOffer = offer.IDOffer;
    }

    public async Task UpdateOfferAsync(BLOffer blOffer)
    {
        var offer = _mapper.Map<Offer>(blOffer);
        await _offerRepository.UpdateAsync(offer);
    }

    public async Task DeleteOfferAsync(int id)
    {
        await _offerRepository.DeleteAsync(id);
    }
}
