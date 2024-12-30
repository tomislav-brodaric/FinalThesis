using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class CityService(IRepository<City> cityRepository, IMapper mapper)
{
    private readonly IRepository<City> _cityRepository = cityRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLCity>> GetAllCitiesAsync()
    {
        var cities = await _cityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLCity>>(cities);
    }

    public async Task<BLCity?> GetCityByIdAsync(int id)
    {
        var city = await _cityRepository.GetByIdAsync(id);
        return _mapper.Map<BLCity>(city);
    }

    public async Task AddCityAsync(BLCity blCity)
    {
        var existingCities = await _cityRepository.GetAllAsync();
        if (existingCities.Any(c => c.CityName == blCity.CityName))
        {
            throw new InvalidOperationException("City with this name already exists.");
        }

        var city = _mapper.Map<City>(blCity);
        await _cityRepository.AddAsync(city);
        blCity.IDCity = city.IDCity;
    }

    public async Task UpdateCityAsync(BLCity blCity)
    {
        var city = _mapper.Map<City>(blCity);
        await _cityRepository.UpdateAsync(city);
    }

    public async Task DeleteCityAsync(int id)
    {
        await _cityRepository.DeleteAsync(id);
    }
}