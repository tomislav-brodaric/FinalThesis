using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class CountryService(IRepository<Country> countryRepository, IMapper mapper)
{
    private readonly IRepository<Country> _countryRepository = countryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLCountry>> GetAllCountriesAsync()
    {
        var countries = await _countryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLCountry>>(countries);
    }

    public async Task<BLCountry?> GetCountryByIdAsync(int id)
    {
        var country = await _countryRepository.GetByIdAsync(id);
        return _mapper.Map<BLCountry>(country);
    }

    public async Task AddCountryAsync(BLCountry blCountry)
    {
        var existingCountries = await _countryRepository.GetAllAsync();
        if (existingCountries.Any(c => c.ShortNameHr == blCountry.ShortNameHr))
        {
            throw new InvalidOperationException("Country with this short name already exists.");
        }

        var country = _mapper.Map<Country>(blCountry);
        await _countryRepository.AddAsync(country);
        blCountry.IDCountry = country.IDCountry;
    }

    public async Task UpdateCountryAsync(BLCountry blCountry)
    {
        var country = _mapper.Map<Country>(blCountry);
        await _countryRepository.UpdateAsync(country);
    }

    public async Task DeleteCountryAsync(int id)
    {
        await _countryRepository.DeleteAsync(id);
    }
}