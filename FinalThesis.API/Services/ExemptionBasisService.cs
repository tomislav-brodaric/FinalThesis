//using AutoMapper;
//using FinalThesis.API.BLModels;
//using FinalThesis.DAL.DALModels;
//using FinalThesis.DAL.Repositories;

//namespace FinalThesis.API.Services;

//public class ExemptionBasisService(ExemptionBasisRepository exemptionBasisRepository, IMapper mapper)
//{
//    private readonly ExemptionBasisRepository _exemptionBasisRepository = exemptionBasisRepository;
//    private readonly IMapper _mapper = mapper;

//    public async Task<IEnumerable<BLExemptionBasis>> GetAllExemptionBasisAsync()
//    {
//        var exemptionBasis = await _exemptionBasisRepository.GetAllAsync();
//        return _mapper.Map<IEnumerable<BLExemptionBasis>>(exemptionBasis);
//    }

//    public async Task<BLExemptionBasis?> GetExemptionBasisByIdAsync(int id)
//    {
//        var exemptionBasis = await _exemptionBasisRepository.GetByIdAsync(id);
//        return _mapper.Map<BLExemptionBasis>(exemptionBasis);
//    }

//    public async Task AddExemptionBasisAsync(BLExemptionBasis blExemptionBasis)
//    {
//        var existingExemptionBasis = await _exemptionBasisRepository.GetAllAsync();
//        if (existingExemptionBasis.Any(b => b.BasisName == blExemptionBasis.BasisName))
//        {
//            throw new InvalidOperationException("Exemption basis with this name already exists.");
//        }

//        var exemptionBasis = _mapper.Map<ExemptionBasis>(blExemptionBasis);
//        await _exemptionBasisRepository.AddAsync(exemptionBasis);
//        blExemptionBasis.IDBasis = exemptionBasis.IDBasis;
//    }

//    public async Task UpdateExemptionBasisAsync(BLExemptionBasis blExemptionBasis)
//    {
//        var exemptionBasis = _mapper.Map<ExemptionBasis>(blExemptionBasis);
//        await _exemptionBasisRepository.UpdateAsync(exemptionBasis);
//    }

//    public async Task DeleteExemptionBasisAsync(int id)
//    {
//        await _exemptionBasisRepository.DeleteAsync(id);
//    }

//    public async Task<bool> ExistsAsync(int exemptionId)
//    {
//        return await _exemptionBasisRepository.AnyAsync(e => e.IDBasis == exemptionId);
//    }

//}