using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;

namespace FinalThesis.API.Mapping;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<AdvanceInvoice, BLAdvanceInvoice>()
            .ForMember(dest => dest.AdvanceInvoicePayments, opt => opt.MapFrom(src => src.AdvanceInvoicePayments))
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
            .ReverseMap();

        CreateMap<AdvanceInvoicePayment, BLAdvanceInvoicePayment>()
            .ForMember(dest => dest.AdvanceInvoice, opt => opt.MapFrom(src => src.AdvanceInvoice))
            .ReverseMap();

        CreateMap<Bank, BLBank>()
            .ForMember(dest => dest.GiroAccounts, opt => opt.MapFrom(src => src.GiroAccounts))
            .ReverseMap();

        CreateMap<City, BLCity>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ReverseMap();

        CreateMap<Country, BLCountry>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
            .ReverseMap();

        CreateMap<ConnectionType, BLConnectionType>()
            .ForMember(dest => dest.Partners, opt => opt.MapFrom(src => src.Partners))
            .ReverseMap();

        CreateMap<Currency, BLCurrency>()
            .ForMember(dest => dest.Countries, opt => opt.MapFrom(src => src.Countries))
            .ReverseMap();

        CreateMap<GiroAccount, BLGiroAccount>()
            .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank))
            .ReverseMap();

        CreateMap<Invoice, BLInvoice>()
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
            .ForMember(dest => dest.InvoiceProducts, opt => opt.MapFrom(src => src.InvoiceProducts))
            .ReverseMap();

        CreateMap<InvoiceProduct, BLInvoiceProduct>()
            .ForMember(dest => dest.Invoice, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<Offer, BLOffer>()
            .ForMember(dest => dest.OfferProducts, opt => opt.MapFrom(src => src.OfferProducts))
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
            .ReverseMap();

        CreateMap<OfferProduct, BLOfferProduct>()
            .ForMember(dest => dest.Offer, opt => opt.MapFrom(src => src.Offer))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ReverseMap();

        CreateMap<Partner, BLPartner>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.BillingCity, opt => opt.MapFrom(src => src.BillingCity))
            .ForMember(dest => dest.PartnerType, opt => opt.MapFrom(src => src.PartnerType))
            .ForMember(dest => dest.PartnerPriceLists, opt => opt.MapFrom(src => src.PartnerPriceLists))
            .ForMember(dest => dest.PartnerTaxDetails, opt => opt.MapFrom(src => src.PartnerTaxDetails))
            .ForMember(dest => dest.ConnectionType, opt => opt.MapFrom(src => src.ConnectionType))
            .ForMember(dest => dest.PartnerContacts, opt => opt.MapFrom(src => src.PartnerContacts))
            .ReverseMap();

        CreateMap<PartnerContact, BLPartnerContact>()
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
            .ReverseMap();

        CreateMap<PartnerPriceList, BLPartnerPriceList>()
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
            .ForMember(dest => dest.PriceListType, opt => opt.MapFrom(src => src.PriceListType))
            .ReverseMap();

        CreateMap<PartnerTaxDetail, BLPartnerTaxDetail>()
            .ForMember(dest => dest.Partner, opt => opt.MapFrom(src => src.Partner))
            .ForMember(dest => dest.TaxNumberType, opt => opt.MapFrom(src => src.TaxNumberType))
            .ForMember(dest => dest.VATPaymentMethod, opt => opt.MapFrom(src => src.VATPaymentMethod))
            .ReverseMap();

        CreateMap<PartnerType, BLPartnerType>()
            .ForMember(dest => dest.Partners, opt => opt.MapFrom(src => src.Partners))
            .ReverseMap();

        CreateMap<PriceListType, BLPriceListType>()
            .ForMember(dest => dest.PartnerPriceLists, opt => opt.MapFrom(src => src.PartnerPriceLists))
            .ReverseMap();

        CreateMap<Product, BLProduct>()
            .ForMember(dest => dest.ProductGroup, opt => opt.MapFrom(src => src.ProductGroup))
            .ForMember(dest => dest.TaxNumber, opt => opt.MapFrom(src => src.TaxNumber))
            .ReverseMap();

        CreateMap<ProductGroup, BLProductGroup>()
          .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType))
          .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
          .ReverseMap();

        CreateMap<ProductType, BLProductType>()
            .ForMember(dest => dest.ProductGroups, opt => opt.MapFrom(src => src.ProductGroups))
            .ReverseMap();

        CreateMap<TaxNumber, BLTaxNumber>()
            .ForMember(dest => dest.TaxRate, opt => opt.MapFrom(src => src.TaxRate))
            .ReverseMap();

        CreateMap<TaxNumberType, BLTaxNumberType>()
            .ForMember(dest => dest.PartnerTaxDetails, opt => opt.MapFrom(src => src.PartnerTaxDetails))
            .ReverseMap();

        CreateMap<TaxRate, BLTaxRate>()
            .ForMember(dest => dest.TaxNumbers, opt => opt.MapFrom(src => src.TaxNumbers))
            .ReverseMap();

        CreateMap<VATPaymentMethod, BLVATPaymentMethod>()
            .ForMember(dest => dest.PartnerTaxDetails, opt => opt.MapFrom(src => src.PartnerTaxDetails))
            .ReverseMap();
    }
}