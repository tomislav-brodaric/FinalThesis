using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.MVC.ViewModels;

namespace FinalThesis.MVC.Mapping;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<BLAdvanceInvoice, VMAdvanceInvoice>()
             .ForMember(dest => dest.AdvanceInvoicePayments, opt => opt.MapFrom(src => src.AdvanceInvoicePayments))
             .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
             .ForMember(dest => dest.ExemptionID, opt => opt.MapFrom(src => src.ExemptionID))
             .ReverseMap()
             .ForMember(dest => dest.Exemption, opt => opt.Ignore());

        CreateMap<BLAdvanceInvoicePayment, VMAdvanceInvoicePayment>()
            .ReverseMap();

        CreateMap<BLBank, VMBank>()
            .ForMember(dest => dest.GiroAccounts, opt => opt.MapFrom(src => src.GiroAccounts))
            .ReverseMap();

        CreateMap<BLCity, VMCity>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ReverseMap();

        CreateMap<BLCountry, VMCountry>()
            .ForMember(dest => dest.CurrencyName, opt => opt.MapFrom(src => src.Currency != null ? src.Currency.CurrencyName : "N/A"))
            .ReverseMap();

        CreateMap<BLCurrency, VMCurrency>()
            .ForMember(dest => dest.CountriesUsingCurrency, opt => opt.MapFrom(src => src.Countries.Select(c => c.ShortNameHr)))
            .ReverseMap();

        CreateMap<BLExemptionBasis, VMExemptionBasis>()
            .ForMember(dest => dest.PDVExemptions, opt => opt.MapFrom(src => src.PDVExemptions))
            .ReverseMap();
            
        CreateMap<BLGiroAccount, VMGiroAccount>()
            .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank))
            .ReverseMap();

        CreateMap<BLInvoice, VMInvoice>()
           //.ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
           .ForMember(dest => dest.InvoiceProducts, opt => opt.MapFrom(src => src.InvoiceProducts))
           .ReverseMap();

        CreateMap<BLInvoiceProduct, VMInvoiceProduct>()
             .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
             .ForMember(dest => dest.Product, opt => opt.Ignore())
             .ReverseMap()
             .ForMember(dest => dest.Invoice, opt => opt.Ignore())
             .ForMember(dest => dest.Product, opt => opt.Ignore());

        CreateMap<BLPartner, VMPartner>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country != null ? src.Country.ShortNameHr : null))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City != null ? src.City.CityName : null))
            .ForMember(dest => dest.BillingCityName, opt => opt.MapFrom(src => src.BillingCity != null ? src.BillingCity.CityName : null))
            .ForMember(dest => dest.PartnerTypeName, opt => opt.MapFrom(src => src.PartnerType != null ? src.PartnerType.TypeName : null))
            .ForMember(dest => dest.PartnerTypeID, opt => opt.MapFrom(src => src.PartnerTypeID))
            .ForMember(dest => dest.ConnectionTypeName, opt => opt.MapFrom(src => src.ConnectionType != null ? src.ConnectionType.ConnectionName : null))
            .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.PartnerContacts))
            .ReverseMap();

        CreateMap<BLPartnerContact, VMPartnerContact>()
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
            .ReverseMap();

        CreateMap<VMPartnerSummary, BLPartner>()
            .ReverseMap();

        CreateMap<BLProduct, VMProduct>()
            .ForMember(dest => dest.ProductGroup, opt => opt.MapFrom(src => src.ProductGroup))
            .ForMember(dest => dest.TaxNumber, opt => opt.MapFrom(src => src.TaxNumber))
            .ReverseMap();

        CreateMap<BLProductGroup, VMProductGroup>()
          .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType))
          .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
          .ReverseMap();

        CreateMap<BLProductType, VMProductType>()
            .ForMember(dest => dest.ProductGroups, opt => opt.MapFrom(src => src.ProductGroups))
            .ReverseMap();

        CreateMap<BLPDVExemption, VMPDVExemption>()
            .ForMember(dest => dest.Basis, opt => opt.MapFrom(src => src.Basis))
            .ReverseMap();

        CreateMap<BLTaxNumber, VMTaxNumber>()
            .ForMember(dest => dest.TaxRate, opt => opt.MapFrom(src => src.TaxRate))
            .ReverseMap();

        CreateMap<BLTaxRate, VMTaxRate>()
            .ForMember(dest => dest.TaxNumbers, opt => opt.MapFrom(src => src.TaxNumbers))
            .ReverseMap();

    }
}