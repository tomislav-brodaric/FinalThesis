namespace FinalThesis.MVC.ViewModels;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class VMInvoiceProduct
{
    public int? IDInvoiceProduct { get; set; }

    [DisplayName("Product")]
    public int ProductID { get; set; }

    [DisplayName("Product name")]
    public string ProductName { get; set; } = string.Empty; 

    [DisplayName("Quantity")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }

    [DisplayName("Price (€)")]
    [DataType(DataType.Currency)]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    [DisplayName("Discount (%)")]
    [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100.")]
    public decimal? Discount { get; set; }

    [DisplayName("Total (€)")]
    [DataType(DataType.Currency)]
    public decimal? Total => CalculateTotal();

    public virtual VMProduct? Product { get; set; }

    public virtual VMInvoice? Invoice { get; set; }

    private decimal? CalculateTotal()
    {
        if (Quantity > 0 && Price > 0)
        {
            var discountMultiplier = (100 - (Discount ?? 0)) / 100;
            return Quantity * Price * discountMultiplier;
        }
        return null;
    }
}