using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalThesis.MVC.ViewModels;

public class VMPartner
{
    public int IDPartner { get; set; }
    public string PartnerName { get; set; } = string.Empty;

    [DisplayName("Country")]
    public int? CountryID { get; set; }

    [DisplayName("Country")]
    public string? CountryName { get; set; } 

    [DisplayName("Partner type")]
    public int PartnerTypeID { get; set; }

    [DisplayName("Partner type")]
    public string? PartnerTypeName { get; set; } 

    public string? Note { get; set; }

    [DisplayName("City")]
    public int? IDCity { get; set; }

    [DisplayName("City")]
    public string? CityName { get; set; } 

    [DisplayName("Address street")]
    public string? AddressStreet { get; set; }

    [DisplayName("Address number")]
    public string? AddressNumber { get; set; }

    [DisplayName("Billing city")]
    public int? BillingCityID { get; set; }

    [DisplayName("Billing city name")]
    public string? BillingCityName { get; set; }  // Novo svojstvo za prikaz naziva grada za naplatu

    [DisplayName("Billing street")]
    public string? BillingStreet { get; set; }

    [DisplayName("Billing number")]
    public string? BillingNumber { get; set; }

    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }

    [DisplayName("Web address")]
    public string? WebAddress { get; set; }

    [DisplayName("Parent GLN")]
    public string? ParentGLN { get; set; }

    [DisplayName("Branch GLN")]
    public string? BranchGLN { get; set; }

    [DisplayName("Branch code")]
    public string? BranchCode { get; set; }

    public List<VMPartnerContact> Contacts { get; set; } = new List<VMPartnerContact>();

    public IEnumerable<SelectListItem> Countries { get; set; } = [];
    public IEnumerable<SelectListItem> Cities { get; set; } = [];
    public IEnumerable<SelectListItem> PartnerTypes { get; set; } = [];

    public int TaxNumberTypeID { get; set; }
    public int VATPaymentMethodID { get; set; }
    public int PriceListTypeID { get; set; }
    public decimal? Discount { get; set; }
    public int? PaymentTerms { get; set; }
    public int? ConnectionTypeID { get; set; }
    public string? ConnectionTypeName { get; set; }

    public IEnumerable<SelectListItem> TaxNumberTypes { get; set; } = [];
    public IEnumerable<SelectListItem> VATPaymentMethods { get; set; } = [];
    public IEnumerable<SelectListItem> PriceListTypes { get; set; } = [];
    public IEnumerable<SelectListItem> ConnectionTypes { get; set; } = [];

    [DisplayName("IBAN")]
    [RegularExpression(@"^[A-Z]{2}\d{2}[A-Z0-9]{11,30}$", ErrorMessage = "Unesite valjan IBAN.")]
    public string? IBAN { get; set; }
}
