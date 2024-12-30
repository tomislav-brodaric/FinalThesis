namespace FinalThesis.API.BLModels;

public class BLOfferProduct
{
    public int IDOfferProduct { get; set; }
    public int OfferID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public decimal? Total { get; set; }

    public virtual BLOffer Offer { get; set; } = null!;
    public virtual BLProduct Product { get; set; } = null!;
}