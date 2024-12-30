//using AutoMapper;
//using FinalThesis.API.BLModels;
//using FinalThesis.DAL.DALModels;
//using FinalThesis.DAL.Repositories;

//namespace FinalThesis.API.Services;

//public class PDVExemptionService(IRepository<PDVExemption> pdvExemptionRepository, IMapper mapper)
//{
//    private readonly IRepository<PDVExemption> _pdvExemptionRepository = pdvExemptionRepository;
//    private readonly IMapper _mapper = mapper;


//    public async Task<IEnumerable<BLPDVExemption>> GetAllPDVExemptionsAsync()
//    {
//        var pdvExemptions = await _pdvExemptionRepository.GetAllAsync();
//        return _mapper.Map<IEnumerable<BLPDVExemption>>(pdvExemptions);
//    }

//    public async Task<BLPDVExemption?> GetPDVExemptionByIdAsync(int id)
//    {
//        var pdvExemption = await _pdvExemptionRepository.GetByIdAsync(id);
//        return _mapper.Map<BLPDVExemption>(pdvExemption);
//    }

//    public async Task AddPDVExemptionAsync(BLPDVExemption blPDVExemptions)
//    {
//        var existingPDVExemptions = await _pdvExemptionRepository.GetAllAsync();
//        if (existingPDVExemptions.Any(b => b.ClauseName == blPDVExemptions.ClauseName))
//        {
//            throw new InvalidOperationException("PDV exemption with this name already exists.");
//        }

//        var pdvExemption = _mapper.Map<PDVExemption>(blPDVExemptions);
//        await _pdvExemptionRepository.AddAsync(pdvExemption);
//        blPDVExemptions.IDExemption = pdvExemption.IDExemption;
//    }

//    public async Task UpdatePDVExemptionAsync(BLPDVExemption blPDVExemption)
//    {
//        var exemptionBasis = _mapper.Map<PDVExemption>(blPDVExemption);
//        await _pdvExemptionRepository.UpdateAsync(exemptionBasis);
//    }

//    public async Task DeletePDVExemptionAsync(int id)
//    {
//        await _pdvExemptionRepository.DeleteAsync(id);
//    }
//}