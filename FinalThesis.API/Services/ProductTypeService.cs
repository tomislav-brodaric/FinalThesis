using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class ProductTypeService(IRepository<ProductType> productTypeRepository, IMapper mapper)
{
    public async Task<IEnumerable<BLProductType>> GetAllProductTypesAsync()
    {
        var productTypes = await productTypeRepository.GetAllAsync();
        return mapper.Map<IEnumerable<BLProductType>>(productTypes);
    }

    public async Task<BLProductType?> GetProductTypeByIdAsync(int id)
    {
        var productType = await productTypeRepository.GetByIdAsync(id);
        return mapper.Map<BLProductType>(productType);
    }

    public async Task AddProductTypeAsync(BLProductType blProductType)
    {
        var existingProductTypes = await productTypeRepository.GetAllAsync();
        if (existingProductTypes.Any(pt => pt.TypeName == blProductType.TypeName))
        {
            throw new InvalidOperationException("Product type with this name already exists.");
        }

        var productType = mapper.Map<ProductType>(blProductType);
        await productTypeRepository.AddAsync(productType);
        blProductType.IDProductType = productType.IDProductType;
    }

    public async Task UpdateProductTypeAsync(BLProductType blProductType)
    {
        var productType = mapper.Map<ProductType>(blProductType);
        await productTypeRepository.UpdateAsync(productType);
    }

    public async Task DeleteProductTypeAsync(int id)
    {
        await productTypeRepository.DeleteAsync(id);
    }
}
