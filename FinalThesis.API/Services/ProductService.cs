using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class ProductService(ProductRepository productRepository, IMapper mapper)
{
    public async Task<IEnumerable<BLProduct>> GetAllProductsAsync()
    {
        var products = await productRepository.GetAllAsync();
        return mapper.Map<IEnumerable<BLProduct>>(products);
    }

    public async Task<BLProduct?> GetProductByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);
        return mapper.Map<BLProduct>(product);
    }

    public async Task AddProductAsync(BLProduct blProduct)
    {
        var existingProducts = await productRepository.GetAllAsync();
        if (existingProducts.Any(b => b.ProductName == blProduct.ProductName))
        {
            throw new InvalidOperationException("Product with this name already exists.");
        }

        var product = mapper.Map<Product>(blProduct);
        await productRepository.AddAsync(product);
        blProduct.IDProduct = product.IDProduct;
    }

    public async Task UpdateProductAsync(BLProduct blProduct)
    {
        var product = mapper.Map<Product>(blProduct);
        await productRepository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await productRepository.DeleteAsync(id);
    }

    public async Task<bool> DoesProductExistAsync(int productId)
    {
        return await productRepository.DoesProductExistAsync(productId);
    }
}
