using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class ProductGroupService(IRepository<ProductGroup> productGroupRepository, IMapper mapper)
{
    public async Task<IEnumerable<BLProductGroup>> GetAllProductGroupsAsync()
    {
        var productGroups = await productGroupRepository.GetAllAsync();
        return mapper.Map<IEnumerable<BLProductGroup>>(productGroups);
    }

    public async Task<BLProductGroup?> GetProductGroupByIdAsync(int id)
    {
        var productGroup = await productGroupRepository.GetByIdAsync(id);
        return mapper.Map<BLProductGroup>(productGroup);
    }

    public async Task AddProductGroupAsync(BLProductGroup blProductGroup)
    {
        var existingProductGroups = await productGroupRepository.GetAllAsync();
        if (existingProductGroups.Any(pg => pg.GroupName == blProductGroup.GroupName))
        {
            throw new InvalidOperationException("Product group with this name already exists.");
        }

        var productGroup = mapper.Map<ProductGroup>(blProductGroup);
        await productGroupRepository.AddAsync(productGroup);
        blProductGroup.IDProductGroup = productGroup.IDProductGroup;
    }

    public async Task UpdateProductGroupAsync(BLProductGroup blProductGroup)
    {
        var productGroup = mapper.Map<ProductGroup>(blProductGroup);
        await productGroupRepository.UpdateAsync(productGroup);
    }

    public async Task DeleteProductGroupAsync(int id)
    {
        await productGroupRepository.DeleteAsync(id);
    }
}
