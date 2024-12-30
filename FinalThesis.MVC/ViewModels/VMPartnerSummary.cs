using System.ComponentModel;

namespace FinalThesis.MVC.ViewModels;

public class VMPartnerSummary
{
    public int IDPartner { get; set; }

    [DisplayName("Partner Name")]
    public string PartnerName { get; set; } = string.Empty;

    [DisplayName("Address")]
    public string? AddressStreet { get; set; }

    [DisplayName("Address Number")]
    public string? AddressNumber { get; set; }

    [DisplayName("City")]
    public string? CityName { get; set; }

    [DisplayName("Phone")]
    public string? Phone { get; set; }

    [DisplayName("Email")]
    public string? Email { get; set; }
}
