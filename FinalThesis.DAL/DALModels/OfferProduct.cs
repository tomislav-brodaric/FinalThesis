namespace FinalThesis.DAL.DALModels;

public partial class OfferProduct
{
    public int IDOfferProduct { get; set; }
    public int OfferID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public decimal? Total { get; set; }
    public virtual Offer Offer { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}