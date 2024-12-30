using FinalThesis.API.Services;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<FinalThesisContext>(options =>
        {
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
        });

        builder.Services.AddScoped<BankService>();
        builder.Services.AddScoped<CityService>();
        builder.Services.AddScoped<ConnectionTypeService>();
        builder.Services.AddScoped<CountryService>();
        builder.Services.AddScoped<CurrencyService>();
        //builder.Services.AddScoped<ExemptionBasisService>();
        builder.Services.AddScoped<GiroAccountService>();
        builder.Services.AddScoped<InvoiceService>();
        builder.Services.AddScoped<InvoiceProductService>();
        builder.Services.AddScoped<PartnerContactService>();
        builder.Services.AddScoped<PartnerPriceListService>();
        builder.Services.AddScoped<PartnerService>();
        builder.Services.AddScoped<PartnerTaxDetailService>();
        builder.Services.AddScoped<PartnerTypeService>();
        //builder.Services.AddScoped<PDVExemptionService>();
        builder.Services.AddScoped<PriceListTypeService>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<ProductGroupService>();
        builder.Services.AddScoped<ProductTypeService>();
        builder.Services.AddScoped<TaxNumberService>();
        builder.Services.AddScoped<TaxNumberTypeService>();
        builder.Services.AddScoped<TaxRateService>();
        builder.Services.AddScoped<VATPaymentMethodService>();
        builder.Services.AddScoped<IRepository<Bank>, BankRepository>();
        builder.Services.AddScoped<IRepository<City>, CityRepository>();
        builder.Services.AddScoped<IRepository<ConnectionType>, ConnectionTypeRepository>();
        builder.Services.AddScoped<IRepository<Country>, CountryRepository>();
        builder.Services.AddScoped<IRepository<Currency>, CurrencyRepository>();
        //builder.Services.AddScoped<IRepository<ExemptionBasis>, ExemptionBasisRepository>();
        builder.Services.AddScoped<IRepository<GiroAccount>, GiroAccountRepository>();
        builder.Services.AddScoped<IRepository<Invoice>, InvoiceRepository>();
        builder.Services.AddScoped<IRepository<InvoiceProduct>, InvoiceProductRepository>();
        builder.Services.AddScoped<PartnerContactRepository>();
        builder.Services.AddScoped<IRepository<PartnerPriceList>, PartnerPriceListRepository>();
        builder.Services.AddScoped<IRepository<Partner>, PartnerRepository>();
        builder.Services.AddScoped<IRepository<PartnerTaxDetail>, PartnerTaxDetailRepository>();
        builder.Services.AddScoped<IRepository<PartnerType>, PartnerTypeRepository>();
        //builder.Services.AddScoped<IRepository<PDVExemption>, PDVExemptionRepository>();
        builder.Services.AddScoped<IRepository<PriceListType>, PriceListTypeRepository>();
        builder.Services.AddScoped<ProductRepository>();
        builder.Services.AddScoped<IRepository<ProductGroup>, ProductGroupRepository>();
        builder.Services.AddScoped<IRepository<ProductType>, ProductTypeRepository>();
        builder.Services.AddScoped<IRepository<TaxNumber>, TaxNumberRepository>();
        builder.Services.AddScoped<IRepository<TaxNumberType>, TaxNumberTypeRepository>();
        builder.Services.AddScoped<IRepository<TaxRate>, TaxRateRepository>();
        builder.Services.AddScoped<IRepository<VATPaymentMethod>, VATPaymentMethodRepository>();
        builder.Services.AddAutoMapper(typeof(Mapping.AutomapperProfile));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}