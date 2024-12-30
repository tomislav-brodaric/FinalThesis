using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class ConnectionTypeService(IRepository<ConnectionType> connectionTypeRepository, IMapper mapper)
{
    private readonly IRepository<ConnectionType> _connectionTypeRepository = connectionTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLConnectionType>> GetAllConnectionTypesAsync()
    {
        var connectionTypes = await _connectionTypeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLConnectionType>>(connectionTypes);
    }

    public async Task<BLConnectionType?> GetConnectionTypeByIdAsync(int id)
    {
        var connectionType = await _connectionTypeRepository.GetByIdAsync(id);
        return _mapper.Map<BLConnectionType>(connectionType);
    }

    public async Task AddConnectionTypeAsync(BLConnectionType blConnectionType)
    {
        var connectionType = _mapper.Map<ConnectionType>(blConnectionType);
        await _connectionTypeRepository.AddAsync(connectionType);
        blConnectionType.IDConnectionType = connectionType.IDConnectionType;
    }

    public async Task UpdateConnectionTypeAsync(BLConnectionType blConnectionType)
    {
        var connectionType = _mapper.Map<ConnectionType>(blConnectionType);
        await _connectionTypeRepository.UpdateAsync(connectionType);
    }

    public async Task DeleteConnectionTypeAsync(int id)
    {
        await _connectionTypeRepository.DeleteAsync(id);
    }
}
